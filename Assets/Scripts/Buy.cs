using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Buy : MonoBehaviour
{
    //Zmienna przechowuj�ca warto�� tekstow� 
    private string select;
    //Referencja do skryptu sklepu
    public Shop shop;

    public void Select()
    {
        select = GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(select);
        shop.Buy(select);
    }
}
