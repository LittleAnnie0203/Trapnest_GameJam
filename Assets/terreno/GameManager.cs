using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioSource bgm;

    void Start()
    {
        bgm = GetComponent<AudioSource>();

        // Solo se mantiene si quieres usarlo en varias escenas (opcional)
        DontDestroyOnLoad(gameObject);

        // Escuchar los cambios de escena
        SceneManager.activeSceneChanged += OnSceneChanged;

        // Reproducir solo si la escena actual no es el menú
        CheckSceneAndPlay(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        // Salir al menú principal con ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    // 🔹 Se ejecuta cada vez que cambia la escena
    private void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        CheckSceneAndPlay(newScene.name);
    }

    // 🔹 Controla cuándo se reproduce o detiene la música
    private void CheckSceneAndPlay(string sceneName)
    {
        if (sceneName == "MenuPrincipal")
        {
            if (bgm.isPlaying)
                bgm.Stop();
        }
        else
        {
            if (!bgm.isPlaying)
                bgm.Play();
        }
    }

    private void OnDestroy()
    {
        // Eliminar la suscripción para evitar errores
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }
}
