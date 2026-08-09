using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MateriManager : MonoBehaviour
{
    public TextMeshProUGUI isiMateri;

    private int materiIndex = 0;


    string[] isi =
    {
        @"Descriptive Text

Descriptive text is a text that describes a person, place, animal, or thing.

Structure:
1. Identification
2. Description

Characteristics:
- Uses adjectives
- Uses simple present tense
- Describes characteristics

Example:
My school is big and clean.",

        @"Adjectives

Adjectives are words that describe nouns (people, places, animals, or things).

Examples:
big
small
beautiful
clean
smart

Example sentence:
The school is big.",

        @"School Activities & Environment

School activities are activities done at school.

Examples:
- studying
- reading
- writing
- playing
- discussing

Example sentence:
Students study English in the classroom.",

        @"Preposition of Place

Preposition of place shows the position of something.

Common prepositions:
- in
- on
- under
- behind
- next to

Example sentence:
The book is on the table.",

        @"Simple Present Tense

Simple present tense is used to talk about daily activities or general facts.

Pattern:
Subject + Verb 1

Examples:
I study English.
She reads a book.
They play football.

Example sentence:
She studies English every day."
    };

    void Start()
    {
        TampilkanMateri();
    }

    void TampilkanMateri()
    {
        isiMateri.text = isi[materiIndex];
    }

    public void NextMateri()
    {

        {
            materiIndex++;
            TampilkanMateri();
        }
    }

    public void PreviousMateri()
    {
        if (materiIndex > 0)
        {
            materiIndex--;
            TampilkanMateri();
        }
    }

    public void BackMateri()
    {
       if (materiIndex > 0)
        {
        materiIndex--;
        TampilkanMateri();
        }
    }

    public void QuizMenu()
    {
      SceneManager.LoadScene("mudah");  
    }
}