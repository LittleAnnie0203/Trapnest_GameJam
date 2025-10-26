using UnityEngine;

public class DrumTrigger : MonoBehaviour
{
    public AudioSource drumAudio;
    public GameObject mensajeUI;
    public float distanciaMax = 3.5f; // distancia para activar audio y mensaje

    private Transform jugador;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        if (mensajeUI != null)
            mensajeUI.SetActive(false);

        if (drumAudio != null)
            drumAudio.playOnAwake = false;
    }

    void Update()
    {
        float distancia = Vector3.Distance(jugador.position, transform.position);

        if (mensajeUI != null)
            mensajeUI.SetActive(distancia <= distanciaMax);

        if (drumAudio != null)
        {
            if (distancia <= distanciaMax)
            {
                if (!drumAudio.isPlaying)
                    drumAudio.Play();
            }
            else
            {
                if (drumAudio.isPlaying)
                    drumAudio.Stop();
            }
        }
    }
}
