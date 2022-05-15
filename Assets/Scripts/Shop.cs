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
    //referencja dla tekstu ilo�ci og�lnej kasy w sklepie
    public TextMeshProUGUI shopText;
    //referencja dla obiektu m�wi�cego �e nie mamy kasy by kupi�
    public GameObject noMoney;
    //wartosc reprezentuj�ca koszt
    private int val;
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
