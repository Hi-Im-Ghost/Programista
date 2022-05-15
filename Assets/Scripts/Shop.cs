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
    //referencja dla obiektu mówi¹cego ¿e nie mamy kasy by kupiæ
    public GameObject noMoney;
    //wartosc reprezentuj¹ca koszt
    private int val;

    //Metoda s³u¿aca do kupienia produktu i zmiany kasy
    public void Buy(string select)
    {
        val = Convert.ToInt32(select);
        Debug.Log(val);
        if (val <= economy.getGold())
        {
            economy.setGold(-val);
            shopText.text = "" + economy.getGold();
        }
        else
        {
            noMoney.SetActive(true);
        }
    }

}
