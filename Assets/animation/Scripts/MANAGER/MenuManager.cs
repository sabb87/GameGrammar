using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Animator")]
    public Animator anim;

    [Header("Panels")]
    public GameObject infoPanel;
    public GameObject settingPanel;
    public GameObject quizSelectPanel;

    //================================================
    // PLAY MENU (Animasi + Masuk Menu)
    //================================================
    public void KlikTombolMenu()
    {
        if (anim != null)
        {
            anim.SetTrigger("PlayAnim");
            Invoke(nameof(BukaMenu), 1.5f);
        }
        else
        {
            BukaMenu();
        }
    }

    void BukaMenu()
    {
        SceneManager.LoadScene("menu");
    }

    //================================================
    // INFO PANEL
    //================================================
    public void BukaInfo()
    {
        if (infoPanel != null)
            infoPanel.SetActive(true);
    }

    public void TutupInfo()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }

    //================================================
    // SETTING PANEL
    //================================================
    public void BukaSettingScene()
    {
        SceneManager.LoadScene("setting");
    }

    public void BukaSetting()
    {
        if (settingPanel != null)
            settingPanel.SetActive(true);
    }

    public void TutupSetting()
    {
        if (settingPanel != null)
            settingPanel.SetActive(false);
    }

    //================================================
    // QUIZ SELECT PANEL
    //================================================
    public void BukaQuizPanel()
    {
        Debug.Log("Buka Quiz Panel");

        if (quizSelectPanel != null)
        {
            quizSelectPanel.SetActive(true);
            Debug.Log("Panel Aktif");
        }
        else
        {
            Debug.LogError("Quiz Select Panel masih NULL");
        }
    }

    public void TutupQuizPanel()
    {
        if (quizSelectPanel != null)
            quizSelectPanel.SetActive(false);
    }

    //================================================
    // SCENE MATERI
    //================================================
    public void BukaMateri()
    {
        SceneManager.LoadScene("materi");
    }

    //================================================
    // QUIZ
    //================================================
    public void QuizMudah()
    {
        SceneManager.LoadScene("mudah");
    }

    public void QuizSedang()
    {
        SceneManager.LoadScene("sedang");
    }

    public void QuizSulit()
    {
        SceneManager.LoadScene("hard");
    }

    //================================================
    // KEMBALI KE MENU UTAMA
    //================================================
    public void KembaliMenu()
    {
        SceneManager.LoadScene("menuutama");
    }

    //================================================
    // EXIT GAME
    //================================================
    public void KeluarGame()
    {
        Debug.Log("Keluar Game");
        Application.Quit();
    }
}