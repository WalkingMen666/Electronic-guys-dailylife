using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddScenes : MonoBehaviour
{
	public static bool goToNextScene = false;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("我") && GameData.closeHint)
		{	
			if(SceneManager.GetActiveScene().buildIndex == 3)
			{
				if(goToNextScene)
				{
					changeMePos();
					SystemCall.changeScene_Add();
				}
			}
			else
			{
				changeMePos();
				SystemCall.changeScene_Add();
			}
		}
	}
	void changeMePos()
	{
		Vector3 Pos = GameObject.Find("我").transform.position;
		switch (SceneManager.GetActiveScene().buildIndex)
		{
			case 2:
				if (Pos.y > 0)
				{
					GameData.PlayerPos = new Vector3(3.5f, -5, 0);
				}
				if (Pos.y < 0)
				{
					GameData.PlayerPos = new Vector3(3.5f, -14, 0);
				}
				break;
			case 5:
				GameData.PlayerPos = new Vector3(-8f, Pos.y, 0);
				break;
			case 6:
				GameData.PlayerPos = new Vector3(-7.5f, 0, 0);
				break;
			case 7:
				GameData.PlayerPos = new Vector3(-6.5f, Pos.x - 4, 0);
				break;
		}
	}
}