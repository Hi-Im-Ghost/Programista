using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Filter : MonoBehaviour
{
    
    TMP_Dropdown m_Dropdown;
    int m_DropdownValue;
    public List<Tests> testsList;

    void Start()
    {
        m_Dropdown = GetComponent<TMP_Dropdown>();
    }

    void Update()
    {
        m_DropdownValue = m_Dropdown.value;
        if(m_DropdownValue == 0)
        {
            foreach (GameObject obj in testsList[0].objects)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in testsList[1].objects)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in testsList[2].objects)
            {
                obj.SetActive(true);
            }
        }
        else if(m_DropdownValue == 1)
        {
            foreach (GameObject obj in testsList[0].objects)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in testsList[1].objects)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in testsList[2].objects)
            {
                obj.SetActive(false);
            }
        }
        else if (m_DropdownValue == 2)
        {
            foreach (GameObject obj in testsList[0].objects)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in testsList[1].objects)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in testsList[2].objects)
            {
                obj.SetActive(false);
            }
        }
        else if(m_DropdownValue == 3)
        {
            foreach (GameObject obj in testsList[0].objects)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in testsList[1].objects)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in testsList[2].objects)
            {
                obj.SetActive(true);
            }
        }
        else
        {

        }
    }
}
