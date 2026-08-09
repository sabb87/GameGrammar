using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public int correct;
    public int wrong;   // ← INI YANG HILANG DI KAMU

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetData()
    {
        score = 0;
        correct = 0;
        wrong = 0; // ← ERROR MU ADA DI SINI
    }
}

