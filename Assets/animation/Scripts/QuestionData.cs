using System;

[Serializable]
public class QuestionData
{
    // =========================
    // QUESTION
    // =========================
    public string question;

    // =========================
    // OPTIONS
    // =========================
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;

    // =========================
    // CORRECT ANSWER
    // =========================
    public int correctAnswer;
}