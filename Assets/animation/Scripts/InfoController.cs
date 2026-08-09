using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoController : MonoBehaviour
{
    public GameObject bg;
    public GameObject Panel;
   
    void Start()
    {
         // Kondisi awal
        bg.SetActive(true);
        Panel.SetActive(false);
        
    }

    public void ShowInfo()
    {
        bg.SetActive(false);
        Panel.SetActive(true);
        
    }

    public void HideInfo()
    {
        bg.SetActive(false);
        Panel.SetActive(true);
        
    }

}
