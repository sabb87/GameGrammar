using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResultData
{
    public static int score = 0;
    public static int correct = 0;
    public static int wrong = 0;

    public static int stars = 0;
    public static float timeRemaining = 0f;

    public static string levelName = "";

    public static void ResetData()
    {
        score = 0;
        correct = 0;
        wrong = 0;
        stars = 0;
        timeRemaining = 0f;
        levelName = "";
    }
}
