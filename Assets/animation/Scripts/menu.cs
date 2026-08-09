using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public void PlayBtn()
    {
        SceneManager.LoadScene("menu");
    }

     public void info()
    {
        SceneManager.LoadScene("informasi");
    }

     public void setting()
    {
        SceneManager.LoadScene("setting");
    }

     public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed"); // hanya terlihat di editor
    }

     
}
