using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    [Header("Movimiento")]
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public float gravity = 20f;
    public float jumpForce = 8f;

    private float currentSpeed;
    private float yVelocity;
    private CharacterController controller;
    private Camera mainCamera;
    public Animator animator;

    private bool isDancing = false;
    private bool canInteract = false; // se activa en el trigger
    private bool isJumping = false;

    [Header("Audio del Baile")]
    public AudioSource audioSource;
    public AudioClip[] danceSongs; // ← aquí arrastras tus 5 canciones desde el inspector

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        currentSpeed = walkSpeed;

        // Si olvidaste agregar el AudioSource en el inspector, lo busca automáticamente
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        bool isMoving = (x != 0 || y != 0);

        // 🔹 Cancelar animaciones especiales al moverse
        if (isDancing && isMoving)
        {
            StopDance();
        }

        // 🔹 Correr con Shift
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // 🔹 Dirección de cámara
        Vector3 camForward = mainCamera.transform.forward;
        Vector3 camRight = mainCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // 🔹 Movimiento relativo a cámara
        Vector3 move = (camForward * y + camRight * x);
        Vector3 moveDir = move.normalized * currentSpeed;

        // 🔹 Saltar
        if (controller.isGrounded)
        {
            yVelocity = -1f;

            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                yVelocity = jumpForce;
                isJumping = true;
                animator.SetTrigger("Jump");
            }
            else if (!Input.GetButton("Jump"))
            {
                isJumping = false;
            }
        }
        else
        {
            yVelocity -= gravity * Time.deltaTime;
        }

        moveDir.y = yVelocity;

        // 🔹 Orientar al personaje
        if (move.magnitude > 0)
            transform.forward = new Vector3(move.x, 0, move.z);

        // 🔹 Mover
        controller.Move(moveDir * Time.deltaTime);

        // 🔹 Animaciones base (caminar/correr)
        if (animator != null)
        {
            animator.SetFloat("VelX", x);
            animator.SetFloat("VelY", y);
            animator.SetBool("Run", Input.GetKey(KeyCode.LeftShift));
        }

        // 🔹 Interacción con E (solo si hay trigger)
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            animator.SetTrigger("Pickup");
        }

        // 🔹 Baile con R (toggle)
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isDancing)
                StartDance();
            else
                StopDance();
        }
    }

    // 🎶 Iniciar baile + música
    void StartDance()
    {
        isDancing = true;
        animator.SetBool("Dance", true);

        if (danceSongs.Length > 0 && audioSource != null)
        {
            AudioClip clip = danceSongs[Random.Range(0, danceSongs.Length)];
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    // ⛔ Detener baile + música
    void StopDance()
    {
        isDancing = false;
        animator.SetBool("Dance", false);

        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();
    }

    // Detectar triggers de interacción
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interact"))
            canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interact"))
            canInteract = false;
    }
}
