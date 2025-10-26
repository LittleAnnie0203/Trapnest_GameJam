using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController2 : MonoBehaviour
{
    public float anguloApertura = 90f;
    public float velocidad = 2f;
    public KeyCode teclaAbrir = KeyCode.E;
    public float distanciaMax = 2f;
    public GameObject mensajeUI;

    private bool abierta = false;
    private Quaternion rotacionCerrada;
    private Quaternion rotacionAbierta;
    private Transform jugador;

    void Start()
    {
        rotacionCerrada = transform.rotation;
        rotacionAbierta = Quaternion.Euler(transform.eulerAngles + new Vector3(0, anguloApertura, 0));
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        if (mensajeUI != null)
            mensajeUI.SetActive(false);
    }

    void Update()
    {
        float distancia = Vector3.Distance(jugador.position, transform.position);

        if (distancia <= distanciaMax)
        {
            if (mensajeUI != null)
                mensajeUI.SetActive(true);

            bool presionoTeclado = Input.GetKeyDown(teclaAbrir);
            bool presionoGamepad = Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame;

            if (presionoTeclado || presionoGamepad)
                ToggleDoor();
        }
        else
        {
            if (mensajeUI != null)
                mensajeUI.SetActive(false);
        }

        if (abierta)
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionAbierta, Time.deltaTime * velocidad);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionCerrada, Time.deltaTime * velocidad);
    }

    public void ActivarDesdeBoton()
    {
        float distancia = Vector3.Distance(jugador.position, transform.position);
        if (distancia <= distanciaMax)
            ToggleDoor();
    }

    private void ToggleDoor()
    {
        abierta = !abierta;
    }
}
