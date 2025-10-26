using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HornoController : MonoBehaviour
{
    public Light luzHorno;
    public ParticleSystem vapor;
    public KeyCode teclaPrender = KeyCode.F;
    public GameObject mensajeUI;
    public float distanciaTrigger = 3f;
    private Transform player;
    private bool encendido = false;
    private bool cerca = false;

    void Start()
    {
        if (luzHorno != null)
            luzHorno.enabled = false;

        if (vapor != null)
            vapor.Stop();

        if (mensajeUI != null)
            mensajeUI.SetActive(false);

        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            float distancia = Vector3.Distance(transform.position, player.position);
            cerca = distancia <= distanciaTrigger;

            if (mensajeUI != null)
                mensajeUI.SetActive(cerca);
        }

        if (cerca)
        {
            if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
                ToggleHorno();

            if (Gamepad.current != null && Gamepad.current.rightShoulder.wasPressedThisFrame)
                ToggleHorno();
        }
    }

    public void ActivarDesdeBoton()
    {
        if (cerca)
            ToggleHorno();
    }

    private void ToggleHorno()
    {
        encendido = !encendido;

        if (luzHorno != null)
            luzHorno.enabled = encendido;

        if (vapor != null)
        {
            if (encendido && !vapor.isPlaying)
                vapor.Play();
            else if (!encendido && vapor.isPlaying)
                vapor.Stop();
        }
    }
}
