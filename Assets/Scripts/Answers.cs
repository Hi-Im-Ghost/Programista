using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    //Zmienna kt�ra sprawdzi czy przycisk kt�ry nacisneli�my jest poprawny
    public bool isCorrect = false;
    public ExamManager examManager;
    //referencja dla tekstury bez odpowiedzi
    public Sprite start;
    //referencja dla tekstury dobrej odpowiedzi
    public Sprite correct;
    //referencja dla tekstury dobrej odpowiedzi
    public Sprite wrong;

    private void Start()
    {
        start = GetComponent<Image>().sprite;

    }

    //metoda kt�ra zostanie wywo�ana po klikni�ciu przycisku
    public void Answer()
    {
        
        //Sprawdzenie czy poprawna
        if (isCorrect)
        {

            GetComponent<Image>().sprite = correct;
            Debug.Log("Correct Answer");
            examManager.correctA();

        }
        else
        {
            GetComponent<Image>().sprite = wrong;
            Debug.Log("Wrong Answer");

            examManager.wrongA();

        }
    }
}
