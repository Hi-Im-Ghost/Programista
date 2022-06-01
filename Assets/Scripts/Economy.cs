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
    //referencja dla tekstu czasu testu
    public TextMeshProUGUI timeText;
    //referencja dla swiatla
    public Light light;
    //licznik czasu
    int timer = 0;
    //kolory
    byte r = 50, g = 50, b = 50;
    //Liczba okreœlaj¹ca iloœæ kasy
    private int gold;
    //Liczba okreœlajaca iloœæ punktów edukacji
    private int edu;
    void Start()
    {
        //Ustawienie pocz¹tkowych zasobów
        setGold(20000);
        setEdu(10);
        InvokeRepeating("Count", 10, 10);
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
            else if (timer >= 3 && timer <= 5)
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
    //Metoda do ustawienia czasu w grze
    public void setTime(int time)
    {
        timer = time;
    }

    //Metoda do ustawiania punktów edukacji
    public void setEdu(int val)
    {
        edu = val;
        eduText.text = "" + edu;
    }
    //Metoda do ustawiania kasy
    public void setGold(int val)
    {
        gold = val;
        goldText.text = "" + gold;
    }
    //Metoda do ustawienia koloru t³a
    public void setColor(byte r, byte g, byte b)
    {
        this.r = r;
        this.g = g;
        this.b = b;
    }

    //Metoda do zwiekszania punktów edukacji
    public void addEdu(int val)
    {
        edu += val;
        eduText.text = "" + edu;
    }
    //Metoda do zwiekszania kasy
    public void addGold(int val)
    {
        gold += val;
        goldText.text = "" + gold;
    }
    //Metoda do zwracania punktów edukacji
    public int getEdu()
    {
        return edu;
    }
    //Metoda do zwracania kasy
    public int getGold()
    {
        return gold;
    }
    //Zwraca czas w grze
    public int getTime()
    {
        return timer;
    }
    //Zwraca kolor t³a gry
    public Color32 getColorLight()
    {
        return light.color;
    }

    //Metoda do zapisu gry
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    //Metoda do wczytania gry
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log("GOLD LOAD " + data.gold);
        setGold(data.gold);
        Debug.Log("EDU LOAD " + data.edu);
        setEdu(data.edu);
        Debug.Log("TIME LOAD " + data.time);
        setTime(data.time);
        Debug.Log("COLOR R LOAD " + data.r);
        Debug.Log("COLOR G LOAD " + data.g);
        Debug.Log("COLOR B LOAD " + data.b);
        setColor(data.r, data.g, data.b);

    }
}
