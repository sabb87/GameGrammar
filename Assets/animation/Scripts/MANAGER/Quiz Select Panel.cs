using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizSelectPanel : MonoBehaviour
{
    [Header("Panel Quiz Select")]
    public GameObject quizSelectPanel;

    // buka panel
    public void OpenQuizPanel()
    {
        quizSelectPanel.SetActive(true);
    }

    // tutup panel
    public void CloseQuizPanel()
    {
        quizSelectPanel.SetActive(false);
    }

    // quiz level mudah
    public void LoadEasyQuiz()
    {
        SceneManager.LoadScene("mudah");
    }

    // quiz level sedang
    public void LoadMediumQuiz()
    {
        SceneManager.LoadScene("sedang");
    }

    // quiz level sulit
    public void LoadHardQuiz()
    {
        SceneManager.LoadScene("hard");
    }
}