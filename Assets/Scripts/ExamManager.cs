using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ExamManager : MonoBehaviour
{
    //Obiekt odpowiadajacy za ekonomie
    public Economy economy;
    //Lista pytan i odpowiedzi
    public List<question_answer> questionAnswerList;
    //publicza tablica obiekt�w gry
    public GameObject[] options;
    //liczba przechowuj�ce bie�ace pytanie
    int currentQuestion;
    
    //referencja dla tekstu pytania
    public TextMeshProUGUI questionText;
    //referencja dla tekstu punkt�w
    public TextMeshProUGUI scoreText;
    //referencja dla tekstu czasu testu
    public TextMeshProUGUI timeText;
    //referencja dla tekstu punkt�w przeliczonych testu
    public TextMeshProUGUI pointsText;

    //referencja dla panelu testu
    public GameObject testPanel;
    //referencja dla panelu wyniku testu
    public GameObject endPanel;
    //referencja dla panelu niemozliwosci wlaczenia testu
    public GameObject cantPanel;
    //referencja dla panelu konca czasu
    public GameObject timePanel;

    //liczba pyta�
    int maxScore = 0;
    //nasz wynik
    int score;
    //og�lna ilo�� punkt�w
    int overallScore;
    //czas do ko�ca testu
    int duration = 60;
    //licznik czasu
    int timer = 0;
    //punkty przeliczone
    int points;
    //zmienna ktora steruje licznikiem
    bool check = true;
    //zmienna ktora mowi ze test sie skonczyl
    bool end = false;
    //publicza tablica obiekt�w gwiaz
    public GameObject[] star;

    void Start()
    {
        check = true;
        maxScore = questionAnswerList.Count;
        endPanel.SetActive(false);
        generateQuestion();
    }

    
    void Update()
    {
        if (testPanel.activeSelf == true && duration <= timer)
        {
            timePanel.SetActive(true);
            endTest();
        }
    }

    //Metoda do sprawdzenia czy rozwi�zali�my test
    public void Check()
    {
        if (questionAnswerList.Count <= 0)
        {
            if (testPanel.activeSelf == true && endPanel.activeSelf == false)
            {
                testPanel.SetActive(false);
                cantPanel.SetActive(true);
            }
        }
        else if (end == true)
        {
            testPanel.SetActive(false);
            cantPanel.SetActive(true);
        }

    }

    //Metoda do zwi�kszania licznika
    public void Count()
    {
        if (testPanel.activeSelf == true)
        {
            timer++;
            Debug.Log(timer);
        }
    }

    //Metoda do resetowania testu
    public void resetTest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        testPanel.SetActive(true);
        timer = 0;
    }

    //Metoda dla ko�ca testu
    public void endTest()
    {
        //W��cz panel z wynikiem a wy��cz panel z testem
        testPanel.SetActive(false);
        endPanel.SetActive(true);

        //Dodaj do og�lnej ilo�ci zdobytych punkt�w edukacji zdobyta warto��
        economy.addEdu(score);

        //Wy�wietlanie wynik�w, punkt�w i czasu
        scoreText.text = ""+score;
        overallScore += score;
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
        timer = 0;
        check = true;
        end = true;
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
        
        if (check == true)
        {
            //Odliczaj czas
            InvokeRepeating("Count", 1, 1);
        }
        check = false;
        //Pobieramy komponent tekstu z przycisku i ustawiamy tekst na dowoln� odpowiedz umieszczona w skrypcie
        //przechodzi po wszystkich przyciskach i przypisuje odpowiedni� odpowied�
        for (int i = 0; i < options.Length; i++)
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
