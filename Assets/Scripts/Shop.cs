using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Shop : MonoBehaviour
{
    //Obiekt odpowiadajacy za ekonomie
    public Economy economy;
    //referencja dla tekstu iloœci ogólnej kasy w sklepie
    public TextMeshProUGUI shopText;
    //wartosc reprezentuj¹ca koszt
    private int val;
    public void Buy()
    {
        //TO NAPRAWIÆ
        TextMeshProUGUI select = GetComponent<TextMeshProUGUI>();
        Debug.Log(select.text);
        val = Convert.ToInt32(select.text);
        Debug.Log(val);
        economy.setGold(-val);
        shopText.text = "" + economy.getGold();
    }

}
