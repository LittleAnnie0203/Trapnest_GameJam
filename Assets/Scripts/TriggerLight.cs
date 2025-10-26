using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TriggerLight : MonoBehaviour
{
    public Light lamp;
    public GameObject mensajeUI;

    private bool jugadorDentro = false;
    private bool encendida = false;

    void Start()
    {
        if (lamp != null)
            lamp.enabled = false;

        if (mensajeUI != null)
            mensajeUI.SetActive(false);
    }

    void Update()
    {
        bool presionoTeclado = jugadorDentro && Input.GetKeyDown(KeyCode.R);
        bool presionoGamepad = jugadorDentro && Gamepad.current != null && Gamepad.current.yButton.wasPressedThisFrame;

        if (presionoTeclado || presionoGamepad)
        {
            ToggleLamp();
        }
    }

 
    public void ActivarDesdeBoton()
    {
        if (jugadorDentro)
        {
            ToggleLamp();
        }
    }

    private void ToggleLamp()
    {
        encendida = !encendida;
        lamp.enabled = encendida;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
            if (mensajeUI != null)
                mensajeUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
            if (mensajeUI != null)
                mensajeUI.SetActive(false);
        }
    }
}
