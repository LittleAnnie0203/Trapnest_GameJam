using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
