using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Economy : MonoBehaviour
{
    //referencja dla tekstu ilo�ci og�lnych punkt�w
    public TextMeshProUGUI eduText;
    //referencja dla tekstu ilo�ci og�lnej kasy
    public TextMeshProUGUI goldText;
    //Liczba okre�laj�ca ilo�� kasy
    private int gold;
    //Liczba okre�lajaca ilo�� punkt�w edukacji
    private int edu;
    void Start()
    {
        //Ustawienie pocz�tkowych zasob�w
        setGold(20000);
        setEdu(10);
    }
    //Metoda do ustawiania punkt�w edukacji
    public void setEdu(int val)
    {
        edu += val;
        eduText.text = "" + edu;
    }
    //Metoda do ustawiania kasy
    public void setGold(int val)
    {
        gold += val;
        goldText.text = "" + gold;
    }
    //Metoda do zwracania punkt�w edukacji
    public int getEdu()
    {
        return edu;
    }
    //Metoda do zwracania kasy
    public int getGold()
    {
        return gold;
    }
}
