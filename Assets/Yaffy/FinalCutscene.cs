using System.Collections;
using UnityEngine.UI; // 👈 Necesario para Image y Button
using TMPro; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalCutscene : MonoBehaviour
{
   [SerializeField] private Image fadePanel;
    [SerializeField] private Image endingImage;
    [SerializeField] private TMP_Text endingText;
    [SerializeField] private Button exitButton;

    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private float imageFadeDuration = 1.5f;
    [SerializeField] private float textFadeDuration = 1.5f;
    [SerializeField] private float delayBeforeButton = 1f;

    void Start()
    {
        if (fadePanel != null) fadePanel.color = new Color(0,0,0,1f);
        if (endingImage != null) endingImage.color = new Color(1,1,1,0f);
        if (endingText != null) endingText.color = new Color(1,1,1,0f);
        if (exitButton != null) exitButton.gameObject.SetActive(false);

        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        // Fade out panel (negro -> transparente)
        yield return StartCoroutine(FadeImage(fadePanel, 1f, 0f, fadeDuration));
        yield return new WaitForSecondsRealtime(0.5f);

        // Fade in image
        yield return StartCoroutine(FadeImage(endingImage, 0f, 1f, imageFadeDuration));
        yield return new WaitForSecondsRealtime(0.3f);

        // Fade in text
        yield return StartCoroutine(FadeText(endingText, 0f, 1f, textFadeDuration));
        yield return new WaitForSecondsRealtime(delayBeforeButton);

        if (exitButton != null)
        {
            exitButton.gameObject.SetActive(true);
            exitButton.onClick.AddListener(QuitGame);
        }
    }

    private IEnumerator FadeImage(Image img, float from, float to, float dur)
    {
        if (img == null) yield break;
        float elapsed = 0f;
        Color c = img.color;
        while (elapsed < dur)
        {
            c.a = Mathf.Lerp(from, to, elapsed / dur);
            img.color = c;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        c.a = to; img.color = c;
    }

    private IEnumerator FadeText(TMP_Text txt, float from, float to, float dur)
    {
        if (txt == null) yield break;
        float elapsed = 0f;
        Color c = txt.color;
        while (elapsed < dur)
        {
            c.a = Mathf.Lerp(from, to, elapsed / dur);
            txt.color = c;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        c.a = to; txt.color = c;
    }

    private void QuitGame()
    {
        Debug.Log("Quit requested.");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
