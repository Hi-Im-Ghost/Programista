using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	//Metoda do zmiany sceny przy pomocy podania nazwy
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene("Scenes"+name);
	}
	//Metoda do zmiany sceny przy pomocy przelaczenia na kolejny index
	public void playGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	//Metoda do zmiany sceny przy pomocy przelaczenia na poprzedni index
	public void Back()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
	//Metoda do wy³¹czenia aplikacji
	public void Exit()
	{
		Application.Quit();
	}
}