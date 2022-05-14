using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    //referencja dla tekstu czasu testu
    public TextMeshProUGUI timeText;
    //referencja dla swiatla
    public Light light;
    //licznik czasu
    int timer = 0;
    //kolory
    byte r = 50, g = 50, b = 50;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Count", 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Metoda do zwiêkszania licznika
    public void Count()
    {
        if (timer >= 24)
        {
            timer = 0;
            r = 50;
            g = 50;
            b = 50;
            timer++;
            light.color = new Color32(r, g, b, 255);
            timeText.text = timer + ":00";
        }
        else if (timer < 24)
        {
            if (timer > 0 && timer <= 2)
            {
                r -= 25;
                g -= 25;
                b -= 25;
            }
            else if(timer >= 3 && timer <= 5)
            {
                r += 15;
                g += 15;
                b += 15;
            }
            else if (timer > 5 && timer <= 12)
            {
                r += 30;
                g += 30;
                b += 30;
            }
            else if (timer > 12 && timer <= 15)
            {
                r -= 5;
                g -= 5;
                b -= 5;
            }
            else if (timer > 15 && timer <= 19)
            {
                r -= 15;
                g -= 15;
                b -= 15;
            }
            else if (timer > 19 && timer <= 23)
            {
                r -= 35;
                g -= 35;
                b -= 35;
            }
            timer++;
            light.color = new Color32(r, g, b, 255);
            timeText.text = timer + ":00";
        }
        

    }


}
