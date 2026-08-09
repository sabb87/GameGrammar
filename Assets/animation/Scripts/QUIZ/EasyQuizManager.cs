using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI soalText;
    public TextMeshProUGUI nomorText;
    public Button[] buttons;
    public TextMeshProUGUI[] textJawaban;

    private string[] soal;
    private string[,] pilihan;
    private int[] jawabanBenar;

    private int indexSoal = 0;
    private bool sudahJawab = false;

    void Start()
    {
        soal = new string[]
        {
            "___ is my sister. She is very kind.",
            "___ are students in SMP Negeri 1.",
            "___ is my cat. It is very cute.",
            "My father ___ a teacher.",
            "They ___ playing football now.",
            "We ___ happy today.",
            "This is ___ book. I bought it yesterday.",
            "Andi has a bike. ___ bike is new.",
            "They have a house. ___ house is big.",
            "___ is my pencil (near).",
            "___ are my shoes (near).",
            "___ is your bag (far).",
            "___ is raining today.",
            "___ are my parents.",
            "___ am in grade eight."
        };

        jawabanBenar = new int[]
        {
            1, 2, 2, 1, 2,
            2, 0, 2, 3, 3,
            2, 3, 2, 3, 2
        };

        pilihan = new string[,]
        {
            { "He", "She", "It", "They" },
            { "I", "She", "We", "It" },
            { "He", "She", "It", "They" },
            { "am", "is", "are", "be" },
            { "am", "is", "are", "be" },
            { "am", "is", "are", "be" },
            { "my", "his", "her", "their" },
            { "my", "her", "his", "their" },
            { "my", "her", "his", "their" },
            { "That", "These", "Those", "This" },
            { "This", "That", "These", "Those" },
            { "This", "These", "Those", "That" },
            { "He", "She", "It", "They" },
            { "He", "She", "It", "They" },
            { "You", "He", "I", "They" }
        };

        TampilkanSoal();
    }

    void TampilkanSoal()
    {
        soalText.text = soal[indexSoal];
        nomorText.text = "QUESTION " + (indexSoal + 1);

        for (int i = 0; i < 4; i++)
        {
            textJawaban[i].text = pilihan[indexSoal, i];
            buttons[i].interactable = true;
            buttons[i].image.color = Color.white;
        }

        sudahJawab = false;
    }

    public void PilihJawaban(int index)
    {
        if (sudahJawab) return;
        sudahJawab = true;

        if (index == jawabanBenar[indexSoal])
        {
            buttons[index].image.color = Color.green;
        }
        else
        {
            buttons[index].image.color = Color.red;
            buttons[jawabanBenar[indexSoal]].image.color = Color.green;
        }

        foreach (Button b in buttons)
            b.interactable = false;
    }

    public void NextSoal()
    {
        if (!sudahJawab) return;

        indexSoal++;

        if (indexSoal < soal.Length)
        {
            TampilkanSoal();
        }
        else
        {
            soalText.text = "QUIZ SELESAI!";
            Debug.Log("QUIZ SELESAI");
        }
    }
}
