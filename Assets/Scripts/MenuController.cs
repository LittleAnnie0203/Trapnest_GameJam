using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public GameObject sobrePanel;
    public GameObject botonInicial;

    void Start()
    {
        if (botonInicial != null)
            EventSystem.current.SetSelectedGameObject(botonInicial);
    }

    public void SalirApp()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void MostrarSobrePanel()
    {
        if (sobrePanel != null)
            sobrePanel.SetActive(true);
    }

    public void CerrarSobrePanel()
    {
        if (sobrePanel != null)
            sobrePanel.SetActive(false);
        if (botonInicial != null)
            EventSystem.current.SetSelectedGameObject(botonInicial);
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene("terreno");
    }
}
