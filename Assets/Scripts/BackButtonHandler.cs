using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonHandler : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string escenaActual = SceneManager.GetActiveScene().name;

            if (escenaActual == "House Interior")
            {
                SceneManager.LoadScene("MenuPrincipal");
            }
            else if (escenaActual == "MenuPrincipal")
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
    }
}
