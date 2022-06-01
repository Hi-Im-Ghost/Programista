using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int gold;
    public int edu;
    public int time;
    public byte r, g, b;
    public PlayerData(Economy economy)
    { 
        gold = economy.getGold();
        edu = economy.getEdu();
        time = economy.getTime();
        r = economy.getColorLight().r;
        g = economy.getColorLight().g;
        b = economy.getColorLight().b;
    }

}
