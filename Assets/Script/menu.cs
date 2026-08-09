using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayBtn()
    {
        SceneManager.LoadScene("menu");
    }

     public void info()
    {
        SceneManager.LoadScene("informasi");
    }

     public void pengaturan()
    {
        SceneManager.LoadScene("setting");
    }

     public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed"); // hanya terlihat di editor
        
        Application.Quit();
    }

     
}
