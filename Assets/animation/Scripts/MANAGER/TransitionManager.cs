using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransitionManager : MonoBehaviour
{
    // =========================
    // FADE PANEL
    // =========================
    public Image fadeImage;

    // =========================
    // FADE SPEED
    // =========================
    public float fadeSpeed = 2f;

    // =========================
    // START
    // =========================
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // =========================
    // FADE IN
    // =========================
    IEnumerator FadeIn()
    {
        Color color = fadeImage.color;

        while(color.a > 0)
        {
            color.a -= Time.deltaTime * fadeSpeed;

            fadeImage.color = color;

            yield return null;
        }

        color.a = 0;

        fadeImage.color = color;
    }

    // =========================
    // FADE OUT
    // =========================
    public IEnumerator FadeOut(string sceneName)
    {
        Color color = fadeImage.color;

        while(color.a < 1)
        {
            color.a += Time.deltaTime * fadeSpeed;

            fadeImage.color = color;

            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}