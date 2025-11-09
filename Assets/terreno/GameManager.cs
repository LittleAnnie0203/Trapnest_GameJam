using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioSource bgm;

    void Start()
    {
        bgm = GetComponent<AudioSource>();

        // Esto hace que el objeto no se destruya al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Salir al menú principal con ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
