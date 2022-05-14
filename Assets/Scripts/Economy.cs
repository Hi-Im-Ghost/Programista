using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Economy : MonoBehaviour
{
    //referencja dla tekstu iloœci ogólnych punktów
    public TextMeshProUGUI eduText;
    //referencja dla tekstu iloœci ogólnej kasy
    public TextMeshProUGUI goldText;
    //Liczba okreœlaj¹ca iloœæ kasy
    private int gold;
    //Liczba okreœlajaca iloœæ punktów edukacji
    private int edu;
    void Start()
    {
        setGold(20000);
        setEdu(10);
    }

    public void setEdu(int val)
    {
        edu += val;
        eduText.text = "" + edu;
    }

    public void setGold(int val)
    {
        gold += val;
        goldText.text = "" + gold;
    }

    public int getEdu()
    {
        return edu;
    }

    public int getGold()
    {
        return gold;
    }
}
