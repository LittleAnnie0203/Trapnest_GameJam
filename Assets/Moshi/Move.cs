using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    [Header("Movimiento")]
    public float runSpeed = 7f;
    public float gravity = 20f;
    public float jumpForce = 8f;

    private float yVelocity;
    private CharacterController controller;
    private Camera mainCamera;

    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Dirección de cámara
        Vector3 camForward = mainCamera.transform.forward;
        Vector3 camRight = mainCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Movimiento relativo a la cámara
        Vector3 move = (camForward * y + camRight * x);
        Vector3 moveDir = move.normalized * runSpeed;

        // Aplicar gravedad
        if (controller.isGrounded)
        {
            yVelocity = -1f; // Mantiene al jugador en el suelo

            // (Salto lo añadiremos más adelante)
            // if (Input.GetButtonDown("Jump"))
            //     yVelocity = jumpForce;
        }
        else
        {
            yVelocity -= gravity * Time.deltaTime;
        }

        moveDir.y = yVelocity;

        // Orientar al personaje
        if (move.magnitude > 0)
            transform.forward = new Vector3(move.x, 0, move.z);

        // Mover al jugador
        controller.Move(moveDir * Time.deltaTime);

        // 🔹 Animaciones
        if (animator != null)
        {
            // Para control con blend tree 2D
            animator.SetFloat("VelX", x);
            animator.SetFloat("VelY", y);

            // Si además usás un parámetro de velocidad total (opcional)
            animator.SetFloat("Speed", new Vector2(x, y).magnitude);
        }
    }
}
