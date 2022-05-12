using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ExamManager : MonoBehaviour
{
    //Lista pytan i odpowiedzi
    public List<question_answer> questionAnswerList;
    //publicza tablica obiekt�w gry
    public GameObject[] options;
    //liczba przechowuj�ce bie�ace pytanie
    public int currentQuestion;
    
    //referencja dla tekstu pytania
    public TextMeshProUGUI questionText;
    //referencja dla tekstu punkt�w
    public TextMeshProUGUI scoreText;
    //referencja dla tekstu czasu testu
    public TextMeshProUGUI timeText;
    //referencja dla tekstu punkt�w przeliczonych testu
    public TextMeshProUGUI pointsText;
    //referencja dla tekstu ilo�ci og�lnych punkt�w
    public TextMeshProUGUI overallText;

    //referencja dla panelu testu
    public GameObject testPanel;
    //referencja dla panelu wyniku testu
    public GameObject endPanel;

    //liczba pyta�
    int maxScore = 0;
    //nasz wynik
    public int score;
    //og�lna ilo�� punkt�w
    int overallScore;
    //czas do ko�ca testu
    int duration = 540;
    //licznik czasu
    int timer = 0;
    //punkty przeliczone
    int points;

    //publicza tablica obiekt�w gwiaz
    public GameObject[] star;

    void Start()
    {
        maxScore = questionAnswerList.Count;
        endPanel.SetActive(false);
        generateQuestion();
    }

    
    void Update()
    {

    }

    
    public void Count()
    {
        timer++;
    }

    //Metoda do resetowania testu
    public void resetTest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        testPanel.SetActive(true);
    }

    //Metoda dla ko�ca testu
    public void endTest()
    {
        //W��cz panel z wynikiem a wy��cz panel z testem
        testPanel.SetActive(false);
        endPanel.SetActive(true);

        //Wy�wietlanie wynik�w, punkt�w i czasu
        scoreText.text = ""+score;
        overallScore += score;
        overallText.text = "" + overallScore;
        timeText.text = timer+"s";
        pointsText.text = ""+(score * 1000) / (timer * maxScore);

        //W zale�no�ci od poprawnych odpowiedzi wy�wietl dany kolor gwiazdek
        for (int i = 0; i < star.Length; i++)
        {
            if (score >= maxScore * 0.8)
            {
                star[i].GetComponent<Image>().sprite = star[i].GetComponent<Stars>().gold;
            }
            else if (score >= maxScore * 0.5)
            {
                star[i].GetComponent<Image>().sprite = star[i].GetComponent<Stars>().silver;
            }
            else
            {
                star[i].GetComponent<Image>().sprite = star[i].GetComponent<Stars>().bronze;
            }
        }
    }

    //Metoda gdy odpowiemy poprawnie na pytanie
    public void correctA()
    {

        //Zwi�kszmay ilo�� punkt�w
        score += 1;
        //Usuwamy pytanie kt�re zosta�o ju� wy�wietlone 
        questionAnswerList.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    //Metoda gdy odpowiemy �le
    public void wrongA()
    {
        //Usuwamy pytanie kt�re zosta�o ju� wy�wietlone 
        questionAnswerList.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    //generuj kolejne pytanie po up�ywie danego czasu
    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    //Metoda do generowania odpowiedzi na pytania
    void generateAnswers()
    {
        //Pobieramy komponent tekstu z przycisku i ustawiamy tekst na dowoln� odpowiedz umieszczona w skrypcie
        //przechodzi po wszystkich przyciskach i przypisuje odpowiedni� odpowied�
        for(int i = 0; i < options.Length; i++)
        {
            //Ustawienie na pocz�tku wszystkich odpowiedzi jako nieprawid�owe
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questionAnswerList[currentQuestion].answers[i];
            //Przywr�cenie poczatkowego obrazka dla guzika odpowiedzi
            options[i].GetComponent<Image>().sprite = options[i].GetComponent<Answers>().start;
            //Gdy p�tla osi�gnie prawid�owy indeks dla odpowiedzi ustawiamy prawid�ow� odpowied�
            if (questionAnswerList[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    //Metoda do generowania pyta�
    void generateQuestion()
    {
        //Sprawdzamy czy mamy wi�cej pyta�
        if (questionAnswerList.Count > 0)
        {
            //Odliczaj czas je�li jest aktywny panel z testem
            if (testPanel.activeSelf == true)
            {
                InvokeRepeating("Count", 1, 1);

            }
            //pobieranie losowego pytania z listy
            currentQuestion = Random.Range(0, questionAnswerList.Count);
            //ustawiamy �e tekst jest r�wny wylosowanemu pytaniu
            questionText.text = questionAnswerList[currentQuestion].question;

            generateAnswers();
        }
        else
        {
            Debug.Log("end question");
            endTest();
        }
    }
}
