using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
	public void quitGame()
	{
		Application.Quit();
		Debug.Log("已退出遊戲");
	}
	public void backToPreviousPage()
	{
		if(GameData.openCalculationMode)
		{
			Destroy(GameObject.FindGameObjectWithTag("sound").gameObject);
			GameData.reset();
			SceneManager.LoadScene(0);
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
			Debug.Log("已回到前一個場景");
			GameData.PlayerPos = new Vector3(-4.5f, 1f, 0);	
		}
	}
}