using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HardQuizManager : MonoBehaviour
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

    [Header("Button Text")]

    public TextMeshProUGUI buttonAText;
    public TextMeshProUGUI buttonBText;
    public TextMeshProUGUI buttonCText;
    public TextMeshProUGUI buttonDText;

    // =====================================
    // BUTTONS
    // =====================================

    [Header("Buttons")]

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
    public TextMeshProUGUI lifeText;

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
    [Header("Life")]

    public int maxLife = 5;

    private int currentLife;

    private int currentQuestion = 0;
    private int score = 0;

    // Menghitung jawaban
    private int correctAnswerCount = 0;
    private int wrongAnswerCount = 0;

    // Menandakan Quiz sudah selesai
    private bool isAnswered = false;
    private bool gameFinished = false;

    [Header("Timer")]

    public float timeLeft = 120f;

    // =====================================
    // START
    // =====================================

    void Start()
    {
        resultPanel.SetActive(false);

        currentLife = maxLife;
        
        UpdateLifeUI();

        CreateQuestions();

        ShowQuestion();

        UpdateScoreUI();

        UpdateProgressUI();
        
        EnableButtons();

        answerResultText.text = "";
    }

    // =====================================
    // UPDATE
    // =====================================

    void Update()
    {
        // Jika game selesai, hentikan semua proses timer
        if (gameFinished)
            return;

        timeLeft -= Time.deltaTime;

        // Mencegah timer menjadi minus
        if (timeLeft < 0)
            timeLeft = 0;

        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(timeLeft).ToString();
        }

        // Waktu habis
        if (timeLeft <= 0)
        {
            FinishQuiz();
        }
    }

    void UpdateLifeUI()
    {
        if (lifeText != null)
        {
            lifeText.text = "❤ LIFE : " + currentLife;
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
            question = "The library is very ______ and comfortable for students.",

            optionA = "noisy",
            optionB = "clean",
            optionC = "lazy",
            optionD = "slow",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 2
        // =====================================

        questions[1] = new QuestionData
        {
            question = "My classroom is ______ the laboratory and the library.",

            optionA = "between",
            optionB = "under",
            optionC = "behind",
            optionD = "inside",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 3
        // =====================================

        questions[2] = new QuestionData
        {
            question = "She always ______ English homework after dinner.",

            optionA = "do",
            optionB = "does",
            optionC = "doing",
            optionD = "did",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 4
        // =====================================

        questions[3] = new QuestionData
        {
            question = "Which sentence is a descriptive text?",

            optionA = "I am studying now.",
            optionB = "The school garden is beautiful and colorful.",
            optionC = "She went to school yesterday.",
            optionD = "Open your book page 10.",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 5
        // =====================================

        questions[4] = new QuestionData
        {
            question = "Rina and Sinta ______ basketball every Saturday.",

            optionA = "plays",
            optionB = "play",
            optionC = "playing",
            optionD = "played",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 6
        // =====================================

        questions[5] = new QuestionData
        {
            question = "The teacher's desk is ______ the whiteboard.",

            optionA = "in front of",
            optionB = "between",
            optionC = "inside",
            optionD = "under",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 7
        // =====================================

        questions[6] = new QuestionData
        {
            question = "Our principal is very ______ and friendly.",

            optionA = "kind",
            optionB = "dirty",
            optionC = "weak",
            optionD = "small",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 8
        // =====================================

        questions[7] = new QuestionData
        {
            question = "Students usually ______ flag ceremony every Monday.",

            optionA = "attends",
            optionB = "attend",
            optionC = "attending",
            optionD = "attended",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 9
        // =====================================

        questions[8] = new QuestionData
        {
            question = "The sentence 'My school has a large library.' belongs to ______.",

            optionA = "Descriptive Text",
            optionB = "Procedure Text",
            optionC = "Narrative Text",
            optionD = "Dialogue",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 10
        // =====================================

        questions[9] = new QuestionData
        {
            question = "The bag is ______ the chair.",

            optionA = "on",
            optionB = "under",
            optionC = "beside",
            optionD = "behind",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 11
        // =====================================

        questions[10] = new QuestionData
        {
            question = "Doni always ______ his classroom before studying.",

            optionA = "clean",
            optionB = "cleans",
            optionC = "cleaning",
            optionD = "cleaned",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 12
        // =====================================

        questions[11] = new QuestionData
        {
            question = "Which adjective describes a classroom?",

            optionA = "Beautiful",
            optionB = "Run",
            optionC = "Write",
            optionD = "Study",

            correctAnswer = 0
        };

        // =====================================
        // QUESTION 13
        // =====================================

        questions[12] = new QuestionData
        {
            question = "The science laboratory is ______ the second floor.",

            optionA = "at",
            optionB = "on",
            optionC = "inside",
            optionD = "between",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 14
        // =====================================

        questions[13] = new QuestionData
        {
            question = "My friends and I ______ English together every afternoon.",

            optionA = "studies",
            optionB = "study",
            optionC = "studying",
            optionD = "studied",

            correctAnswer = 1
        };

        // =====================================
        // QUESTION 15
        // =====================================

        questions[14] = new QuestionData
        {
            question = "The canteen is always ______ during break time.",

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
         // Jika game sudah selesai, tidak bisa menjawab lagi
        if (gameFinished)
            return;
        // Mencegah klik dua kali
        if (isAnswered)
            return;

        Debug.Log("Button Clicked : " + answerIndex);

        isAnswered = true;

        Button clickedButton = null;

        // Ambil button sesuai index
        switch(answerIndex)
        {
            case 0:
                clickedButton = buttonA;
                break;

            case 1:
                clickedButton = buttonB;
                break;

            case 2:
                clickedButton = buttonC;
                break;

            case 3:
                clickedButton = buttonD;
                break;
        }

    // Cegah error null
    if(clickedButton == null)
    {
        Debug.LogError("Button belum dihubungkan di Inspector!");
        return;
    }

    // =========================
    // JAWABAN BENAR
    // =========================

    if(answerIndex == questions[currentQuestion].correctAnswer)
    {
        score += 10;
        
        correctAnswerCount++;

        clickedButton.image.color = Color.green;

        if(answerResultText != null)
        {
            answerResultText.text = "✔ CORRECT!";
        }

        Debug.Log("Correct Answer");
    }

    // =========================
    // JAWABAN SALAH
    // =========================

    else
    {
        wrongAnswerCount++;
        
        currentLife--;

        UpdateLifeUI();
        
        clickedButton.image.color = Color.red;

        if(answerResultText != null)
        {
            answerResultText.text = "✘ WRONG!";
        }

        ShowCorrectAnswer();

        Debug.Log("Wrong Answer");
        
        // Jika nyawa habis langsung selesai
        if(currentLife <= 0)
        {
            FinishQuiz();
            return;
        }
    }

    // Update score
    UpdateScoreUI();

    // Pindah soal
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
        scoreText.text = "⭐ " + score;
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

    void DisableButtons()
    {
        buttonA.interactable = false;
        buttonB.interactable = false;
        buttonC.interactable = false;
        buttonD.interactable = false;
    }

    void EnableButtons()
    {
        buttonA.interactable = true;
        buttonB.interactable = true;
        buttonC.interactable = true;
        buttonD.interactable = true;
    }

    // =====================================
    // FINISH QUIZ
    // =====================================

    void FinishQuiz()
    {
        // Mencegah FinishQuiz dipanggil lebih dari sekali
        if (gameFinished)
            return;

        gameFinished = true;

        // Hentikan timer
        timeLeft = 0;

        // Nonaktifkan semua tombol jawaban
        DisableButtons();

        // Tampilkan Result Panel
        resultPanel.SetActive(true);

        // Tampilkan skor
        finalScoreText.text = "FINAL SCORE : " + score;

        // Menentukan alasan quiz selesai
        if (currentLife <= 0)
        {
            feedbackText.text = "GAME OVER!";
        }
        else if (timeLeft <= 0)
        {
            feedbackText.text = "TIME'S UP!";
        }
        else
        {
            feedbackText.text = "QUIZ COMPLETED!";
        }
    }

    // =====================================
    // RETRY GAME
    // =====================================

    public void RetryGame()
    {
        SceneManager.LoadScene(
        SceneManager.GetActiveScene().name);

        gameFinished = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // =====================================
    // NEXT LEVEL
    // =====================================

    public void NextLevel()
    {
        SceneManager.LoadScene("Result");
    }

    // =====================================
    // HOME BUTTON
    // =====================================

    public void HomeButton()
    {
        SceneManager.LoadScene("menu");
    }

    // =====================================
    // EXIT GAME
    // =====================================

    public void ExitGame()
    {
        Application.Quit();
    }
}