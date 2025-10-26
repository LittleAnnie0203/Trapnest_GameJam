using UnityEngine;
using TMPro;

public class MensajeInteractivo : MonoBehaviour
{
    public GameObject mensajeUI; 
    public KeyCode teclaInteractuar; 

    private bool jugadorDentro = false;

    void Start()
    {
        if (mensajeUI != null)
            mensajeUI.SetActive(false);
    }

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(teclaInteractuar))
        {
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
            if (mensajeUI != null)
                mensajeUI.SetActive(true);

         
            if (mensajeUI.TryGetComponent<TMP_Text>(out TMP_Text texto))
            {
                texto.text = "Presione " + teclaInteractuar.ToString();
            }
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
