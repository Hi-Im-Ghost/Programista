using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Buy : MonoBehaviour
{
    private string select;
    public Shop shop;

    public void Select()
    {
        select = GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(select);
        shop.Buy(select);
    }
}
