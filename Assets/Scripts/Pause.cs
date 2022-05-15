using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //Metoda do zatrzymywania czasu gry
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    //Metoda do wznawania czasu gry
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    //Metoda do resetowania gry
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
