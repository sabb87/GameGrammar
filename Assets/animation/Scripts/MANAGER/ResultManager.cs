using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text correctText;
    public TMP_Text wrongText;

    private void Start()
    {
        scoreText.text = "SCORE : " + ResultData.score;
        correctText.text = "✔ Correct : " + ResultData.correct;
        wrongText.text = "✖ Wrong : " + ResultData.wrong;
    }
}
