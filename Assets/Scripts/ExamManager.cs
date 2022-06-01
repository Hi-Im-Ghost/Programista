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
    //publicza tablica obiektów gry
    public GameObject[] options;
    //liczba przechowuj¹ce bie¿ace pytanie
    int currentQuestion;
    
    //referencja dla tekstu pytania
    public TextMeshProUGUI questionText;
    //referencja dla tekstu punktów
    public TextMeshProUGUI scoreText;
    //referencja dla tekstu czasu testu
    public TextMeshProUGUI timeText;
    //referencja dla tekstu punktów przeliczonych testu
    public TextMeshProUGUI pointsText;

    //referencja dla panelu testu
    public GameObject testPanel;
    //referencja dla panelu wyniku testu
    public GameObject endPanel;
    //referencja dla panelu niemozliwosci wlaczenia testu
    public GameObject cantPanel;
    //referencja dla panelu konca czasu
    public GameObject timePanel;

    //liczba pytañ
    int maxScore = 0;
    //nasz wynik
    int score;
    //ogólna iloœæ punktów
    int overallScore;
    //czas do koñca testu
    int duration = 60;
    //licznik czasu
    int timer = 0;
    //punkty przeliczone
    int points;
    //zmienna ktora steruje licznikiem
    bool check = true;
    //zmienna ktora mowi ze test sie skonczyl
    bool end = false;
    //publicza tablica obiektów gwiaz
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

    //Metoda do sprawdzenia czy rozwi¹zaliœmy test
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

    //Metoda do zwiêkszania licznika
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

    //Metoda dla koñca testu
    public void endTest()
    {
        //W³¹cz panel z wynikiem a wy³¹cz panel z testem
        testPanel.SetActive(false);
        endPanel.SetActive(true);

        //Dodaj do ogólnej iloœci zdobytych punktów edukacji zdobyta wartoœæ
        economy.addEdu(score);

        //Wyœwietlanie wyników, punktów i czasu
        scoreText.text = ""+score;
        overallScore += score;
        timeText.text = timer+"s";
        pointsText.text = ""+(score * 1000) / (timer * maxScore);

        //W zale¿noœci od poprawnych odpowiedzi wyœwietl dany kolor gwiazdek
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

        //Zwiêkszmay iloœæ punktów
        score += 1;
        //Usuwamy pytanie które zosta³o ju¿ wyœwietlone 
        questionAnswerList.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    //Metoda gdy odpowiemy Ÿle
    public void wrongA()
    {
        //Usuwamy pytanie które zosta³o ju¿ wyœwietlone 
        questionAnswerList.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    //generuj kolejne pytanie po up³ywie danego czasu
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
        //Pobieramy komponent tekstu z przycisku i ustawiamy tekst na dowoln¹ odpowiedz umieszczona w skrypcie
        //przechodzi po wszystkich przyciskach i przypisuje odpowiedni¹ odpowiedŸ
        for (int i = 0; i < options.Length; i++)
        {
            //Ustawienie na pocz¹tku wszystkich odpowiedzi jako nieprawid³owe
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questionAnswerList[currentQuestion].answers[i];
            //Przywrócenie poczatkowego obrazka dla guzika odpowiedzi
            options[i].GetComponent<Image>().sprite = options[i].GetComponent<Answers>().start;
            //Gdy pêtla osi¹gnie prawid³owy indeks dla odpowiedzi ustawiamy prawid³ow¹ odpowiedŸ
            if (questionAnswerList[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    //Metoda do generowania pytañ
    void generateQuestion()
    {
        //Sprawdzamy czy mamy wiêcej pytañ
        if (questionAnswerList.Count > 0)
        {
            //pobieranie losowego pytania z listy
            currentQuestion = Random.Range(0, questionAnswerList.Count);
            //ustawiamy ¿e tekst jest równy wylosowanemu pytaniu
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
