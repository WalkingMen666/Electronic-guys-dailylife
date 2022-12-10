using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddScenes : MonoBehaviour
{
	/* 初始進入場景 => 0
	 * 教室 => 1
	 * 到工廠走廊 => 2
	 * 走廊 => 3
	 * 工廠 => 4
	 * 電阻區 => 5
	 */
	public static bool goToNextScene = false;
	void Start()
	{
		
	}
	void Update()
	{
		
	}
	
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
			case 3:
				GameData.PlayerPos = new Vector3(-10f, -0.5f, 0);
				break;
			case 5:
				// 之後要把ME裡的changePlayerPos case7 的 GameData.PlayerPos = new Vector3(-8, 0, 0); 刪掉
				GameData.PlayerPos = new Vector3(-8f, Pos.y, 0);
				break;
			case 7:
				if(Pos.x > 0)
				{
					GameData.PlayerPos = new Vector3(-6.5f, Pos.x - 4, 0);
				}
				if(Pos.x < 0)
				{
					GameData.PlayerPos = new Vector3(-6.5f, Pos.x + 3.5f, 0);
				}
				break;
		}
	}
}