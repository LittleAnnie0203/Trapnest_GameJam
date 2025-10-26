using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ConsolaAudio : MonoBehaviour
{
    public AudioSource pacmanSong;
    public GameObject mensajeUI;
    public float distanciaMax = 2f;

    private Transform jugador;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        if (pacmanSong != null)
            pacmanSong.playOnAwake = false;

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

            bool presionoTeclado = Input.GetKeyDown(KeyCode.T);
            bool presionoGamepad = Gamepad.current != null && Gamepad.current.xButton.wasPressedThisFrame;

            if (presionoTeclado || presionoGamepad)
            {
                ToggleAudio();
            }
        }
        else
        {
            if (mensajeUI != null)
                mensajeUI.SetActive(false);
        }
    }

  
    public void ActivarDesdeBoton()
    {
        float distancia = Vector3.Distance(jugador.position, transform.position);

        if (distancia <= distanciaMax)
        {
            ToggleAudio();
        }
    }

   
    private void ToggleAudio()
    {
        if (pacmanSong != null)
        {
            if (!pacmanSong.isPlaying)
                pacmanSong.Play();
            else
                pacmanSong.Stop();
        }
    }
}
