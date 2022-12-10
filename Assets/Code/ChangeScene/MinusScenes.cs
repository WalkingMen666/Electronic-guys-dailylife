using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinusScenes : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("我"))
		{
			changeMePos();
			SystemCall.changeScene_Sub();
		}
	}
	void changeMePos()
	{
		Vector3 Pos = GameObject.Find("我").transform.position;
		switch (SceneManager.GetActiveScene().buildIndex)
		{
			case 3:
				if (Pos.y > -6)
				{
					GameData.PlayerPos = new Vector3(-8f, 4.5f, 0);
				}
				if (Pos.y < -6)
				{
					GameData.PlayerPos = new Vector3(-8f, -4.5f, 0);
				}
				break;
			case 4:
				GameData.PlayerPos = new Vector3(8, Pos.y + 11.5f, 0);
				break;
			case 5:
				GameData.PlayerPos = new Vector3(8, Pos.y, 0);
				break;
			case 6:
				if(Pos.y > 0)
				{
					GameData.PlayerPos = new Vector3(Pos.y + 4, -2.5f, 0);
				}
				if(Pos.y < 0)
				{
					GameData.PlayerPos = new Vector3(Pos.y - 3.5f, -2.5f, 0);
				}
				break;
		}
	}
}
