using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderChange : MonoBehaviour
{
    //Referencja do obiektu slidera
    public Slider slider;
    //Referencje do poszczeg�lnych punkt�w
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    private bool fullsreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Metoda s�u�aca do zmiany rozdzielczo�ci w zale�no�ci od warto�ci slidera
    public void Resolution()
    {
        if (slider.value == 2)
        {
            point3.SetActive(true);
            Screen.SetResolution(2560, 1440, fullsreen, 60);
        }
        else if (slider.value >= 1)
        {
            point2.SetActive(true);
            point3.SetActive(false);
            Screen.SetResolution(1920, 1080, fullsreen, 60);
        }
        else if (slider.value < 1)
        {
            point1.SetActive(true);
            point2.SetActive(false);
            point3.SetActive(false);
            Screen.SetResolution(1280, 720, fullsreen, 60);
        }
    }
    //Metoda s�u�aca do wy�aczenia full screena
    public void OffFullScreen()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false, 60);
        fullsreen = false;
    }
    //Metoda s�u�aca do w��czenia full screena
    public void OnFullScreen()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true, 60);
        fullsreen = true;
    }
}
