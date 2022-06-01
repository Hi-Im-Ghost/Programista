using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Static poniewa¿ chcemy mieæ tylko jedna wersje
public static class SaveSystem
{
    public static void SavePlayer(Economy economy)
    {
        //Tworzymy format binarny
        BinaryFormatter formatter = new BinaryFormatter();
        //Sciezka do zapisu
        string path = Application.persistentDataPath + "player.save";
        //Tworzymy plik
        FileStream fs = new FileStream(path, FileMode.Create);
        //Przygotowujemy dane do zapisu
        PlayerData data = new PlayerData(economy);
        //Zapis danych do pliku
        formatter.Serialize(fs, data);
        //Zamykamy strumien danych
        fs.Close();
    }

    //Metoda do wczytywania danych
    public static PlayerData LoadPlayer()
    {
        //Bierzemy sciezke do pliku
        string path = Application.persistentDataPath + "player.save";
        //Sprawdzamy czy istnieje
        if(File.Exists(path))
        {
            //Tworzymy format binarny
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //Otwieramy plik
            FileStream fs = new FileStream(path, FileMode.Open);
            //Konwertujemy format danych i wczytujemy
            PlayerData data = binaryFormatter.Deserialize(fs) as PlayerData;
            //Zamykamy strumien danych
            fs.Close();
            return data;
        }
        else
        {
            Debug.LogError("Nie znaleziono pliku zapisu");
            return null;
        }
    }
}
