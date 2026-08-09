using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MediumQuizManager : MonoBehaviour
{
    // =====================================
    // QUESTION DATA
    // =====================================

    [System.Serializable]
    public class QuestionData
    {
        [TextArea(2,5)]
        public string question;

        public string optionA;
        public string optionB;
        public string optionC;
        public string optionD;

        // 0 = A
        // 1 = B
        // 2 = C
        // 3 = D

        public int correctAnswer;
    }

    // =====================================
    // QUESTION UI
    // =====================================

    [Header("Question UI")]

    public TextMeshProUGUI questionText;

    [Header("Answer Text")]

    public TextMeshProUGUI buttonAText;
    public TextMeshProUGUI buttonBText;
    public TextMeshProUGUI buttonCText;
    public TextMeshProUGUI buttonDText;

    // =====================================
    // BUTTONS
    // =====================================

    [Header("Answer Buttons")]

    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;

    // =====================================
    // TOP PANEL
    // =====================================

    [Header("Top Panel")]

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI progressText;

    // =====================================
    // ANSWER RESULT
    // =====================================

    [Header("Answer Feedback")]

    public TextMeshProUGUI answerResultText;

    // =====================================
    // RESULT PANEL
    // =====================================

    [Header("Result Panel")]

    public GameObject resultPanel;

    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI feedbackText;

    // =====================================
    // QUESTIONS
    // =====================================

    [Header("Quiz Questions")]

    public QuestionData[] questions;

    // =====================================
    // GAME VARIABLES
    // =====================================

    private int currentQuestion = 0;
    private int score = 0;

    private bool isAnswered = false;
    private bool quizFinished = false;

    // =====================================
    // TIMER
    // =====================================

    [Header("Timer")]

    public float timeLeft = 90f;

    // =====================================
    // START
    // =====================================

    void Start()
    {
        Debug.Log("MEDIUM QUIZ STARTED");

        resultPanel.SetActive(false);
        CreateQuestions();

        currentQuestion = 0; // paksa reset
        ShowQuestion();

        UpdateScoreUI();
        UpdateProgressUI();
        answerResultText.text = "";
    }

    // =====================================
    // UPDATE
    // =====================================

    void Update()
    {
        if (quizFinished) return;

        timeLeft -= Time.deltaTime;
        timerText.text = "TIME : " + Mathf.Ceil(timeLeft);

        if (timeLeft <= 0)
        {
            FinishQuiz();
        }
    }

    // =====================================
    // CREATE QUESTIONS
    // =====================================

    void CreateQuestions()
    {
        questions = new QuestionData[15];

        // =====================================
        // QUESTION 1
        // =====================================

        questions[0] = new QuestionData
        {
            question = "My classroom is very ______ and comfortable.",

            optionA = "clean",
            optionB = "lazy",
            optionC = "weak",
            optionD = "dirty",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 2
        // =====================================

        questions[1] = new QuestionData
        {
            question = "The bag is ______ the table.",

            optionA = "under",
            optionB = "run",
            optionC = "beautiful",
            optionD = "study",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 3
        // =====================================

        questions[2] = new QuestionData
        {
            question = "She ______ English every day.",

            optionA = "study",
            optionB = "studies",
            optionC = "studying",
            optionD = "studied",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 4
        // =====================================

        questions[3] = new QuestionData
        {
            question = "Which one is adjective?",

            optionA = "Beautiful",
            optionB = "Write",
            optionC = "Study",
            optionD = "Read",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 5
        // =====================================

        questions[4] = new QuestionData
        {
            question = "The library is ______ the classroom.",

            optionA = "beside",
            optionB = "eat",
            optionC = "clean",
            optionD = "run",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 6
        // =====================================

        questions[5] = new QuestionData
        {
            question = "Students usually ______ flag ceremony every Monday.",

            optionA = "attend",
            optionB = "attends",
            optionC = "attending",
            optionD = "attended",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 7
        // =====================================

        questions[6] = new QuestionData
        {
            question = "The school garden is very ______.",

            optionA = "beautiful",
            optionB = "study",
            optionC = "write",
            optionD = "sleep",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 8
        // =====================================

        questions[7] = new QuestionData
        {
            question = "My teacher ______ English every morning.",

            optionA = "teach",
            optionB = "teaches",
            optionC = "teaching",
            optionD = "taught",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 9
        // =====================================

        questions[8] = new QuestionData
        {
            question = "The chair is ______ the table.",

            optionA = "under",
            optionB = "beautiful",
            optionC = "write",
            optionD = "study",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 10
        // =====================================

        questions[9] = new QuestionData
        {
            question = "Which sentence is descriptive text?",

            optionA = "My school has a large library.",
            optionB = "Open your book.",
            optionC = "Sit down please.",
            optionD = "Close the door.",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 11
        // =====================================

        questions[10] = new QuestionData
        {
            question = "We ______ basketball after school.",

            optionA = "plays",
            optionB = "play",
            optionC = "playing",
            optionD = "played",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 12
        // =====================================

        questions[11] = new QuestionData
        {
            question = "The principal is very ______ and friendly.",

            optionA = "kind",
            optionB = "dirty",
            optionC = "small",
            optionD = "weak",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 13
        // =====================================

        questions[12] = new QuestionData
        {
            question = "The laboratory is ______ the second floor.",

            optionA = "on",
            optionB = "inside",
            optionC = "under",
            optionD = "behind",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 14
        // =====================================

        questions[13] = new QuestionData
        {
            question = "Rina always ______ her homework at night.",

            optionA = "do",
            optionB = "does",
            optionC = "doing",
            optionD = "did",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 15
        // =====================================

        questions[14] = new QuestionData
        {
            question = "The canteen is usually ______ during break time.",

            optionA = "crowded",
            optionB = "silent",
            optionC = "empty",
            optionD = "weak",

            correctAnswer = 0
        };
    }

    // =====================================
    // SHOW QUESTION
    // =====================================

    void ShowQuestion()
    {
        Debug.Log("SHOW QUESTION: " + currentQuestion);
        
        ResetButtonColor();
        isAnswered = false;

        questionText.text = questions[currentQuestion].question;

        buttonAText.text = questions[currentQuestion].optionA;
        buttonBText.text = questions[currentQuestion].optionB;
        buttonCText.text = questions[currentQuestion].optionC;
        buttonDText.text = questions[currentQuestion].optionD;
    }

    // =====================================
    // CHECK ANSWER
    // =====================================

    public void CheckAnswer(int answerIndex)
    {
        if(isAnswered) return;

        isAnswered = true;

        Button clickedButton = null;

        if(answerIndex == 0)
            clickedButton = buttonA;

        else if(answerIndex == 1)
            clickedButton = buttonB;

        else if(answerIndex == 2)
            clickedButton = buttonC;

        else if(answerIndex == 3)
            clickedButton = buttonD;

        // =====================================
        // CORRECT ANSWER
        // =====================================

        if(answerIndex == questions[currentQuestion].correctAnswer)
        {
            score += 10;

            clickedButton.image.color = Color.green;

            answerResultText.text = "CORRECT!";
        }
        else
        {
            clickedButton.image.color = Color.red;

            answerResultText.text = "WRONG!";

            ShowCorrectAnswer();
        }

        UpdateScoreUI();

        Invoke("NextQuestion", 1.2f);
    }

    // =====================================
    // SHOW CORRECT ANSWER
    // =====================================

    void ShowCorrectAnswer()
    {
        int correct = questions[currentQuestion].correctAnswer;

        if(correct == 0)
            buttonA.image.color = Color.green;

        else if(correct == 1)
            buttonB.image.color = Color.green;

        else if(correct == 2)
            buttonC.image.color = Color.green;

        else if(correct == 3)
            buttonD.image.color = Color.green;
    }

    // =====================================
    // NEXT QUESTION
    // =====================================

    void NextQuestion()
    {
        currentQuestion++;

        UpdateProgressUI();

        if(currentQuestion < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            FinishQuiz();
        }
    }

    // =====================================
    // SCORE UI
    // =====================================

    void UpdateScoreUI()
    {
        scoreText.text = "⭐ Score : " + score;
    }

    // =====================================
    // PROGRESS UI
    // =====================================

    void UpdateProgressUI()
    {
        progressText.text =
        (currentQuestion + 1) + "/15";
    }

    // =====================================
    // RESET BUTTON COLOR
    // =====================================

    void ResetButtonColor()
    {
        buttonA.image.color = Color.white;
        buttonB.image.color = Color.white;
        buttonC.image.color = Color.white;
        buttonD.image.color = Color.white;

        answerResultText.text = "";
    }

    // =====================================
    // FINISH QUIZ
    // =====================================

    void FinishQuiz()
    {
        if (quizFinished) return;

        quizFinished = true;
        
        resultPanel.SetActive(true);

        finalScoreText.text =
        "FINAL SCORE : " + score;

        if(score >= 130)
        {
            feedbackText.text = "🏆 EXCELLENT!";
        }
        else if(score >= 90)
        {
            feedbackText.text = "😊 GOOD JOB!";
        }
        else
        {
            feedbackText.text = "📚 KEEP LEARNING!";
        }
    }

    // =====================================
    // RETRY GAME
    // =====================================

    public void RestartGame()
    {
        SceneManager.LoadScene(
        SceneManager.GetActiveScene().buildIndex);
    }

    // =====================================
    // NEXT LEVEL
    // =====================================

    public void NextLevel()
    {
        SceneManager.LoadScene("HardLevel");
    }

    // =====================================
    // HOME BUTTON
    // =====================================

    public void HomeButton()
    {
        SceneManager.LoadScene("Menu");
    }

    // =====================================
    // EXIT GAME
    // =====================================

    public void ExitGame()
    {
        Application.Quit();
    }
}