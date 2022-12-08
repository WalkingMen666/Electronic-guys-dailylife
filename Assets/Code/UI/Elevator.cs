using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
	float moveTick = 0.001f;
	Vector3 moveSpeed = new Vector3(0, 0f, 0);
	Vector3 fastPos = new Vector3(0, 18, 0);
	Vector3 slowPos = new Vector3(0, -16f, 0);
	Vector3 targetPos = new Vector3(0, -18f, 0);
	bool move = true;
	int count = 0;
	int doorCount = 0;
	float doorTimeTick = 0.5f;
	AudioSource dingSound;
	[Header("淡出特效")]
	float fadeTime = 1.5f;		// 轉場時間
	Color color;				// 轉場圖片顏色
	public SceneFader sceneFader;
	
	void Start()
	{
		dingSound = GameObject.Find("Main Camera").GetComponent<AudioSource>();
	}

	void Update()
	{
		elevator(Time.time);
		delDoor(Time.time);
	}
	void elevator(float currentTime)
	{
		if(move && currentTime > moveTick)
		{
			if(GameObject.Find("ME").transform.localPosition.y <= targetPos.y)
			{
				dingSound.Play();
				move = false;
				doorTimeTick += currentTime + 1;
			}
			else if(GameObject.Find("ME").transform.localPosition.y >= fastPos.y)
			{
				if(moveSpeed.y != -0.02f && count < 200)
				{
					moveSpeed.y -= 0.0001f;
					count++;
				}
				else 
				{
					moveSpeed.y = -0.02f;
				}
			}
			else if(GameObject.Find("ME").transform.localPosition.y <= slowPos.y)
			{
				if(moveSpeed.y != 0f && count > 0)
				{
					moveSpeed.y += 0.0001f;
					count--;
				}
				else 
				{
					moveSpeed.y = 0;
				}
			}
			this.gameObject.transform.localPosition += moveSpeed;
			moveTick = currentTime + 0.001f;
		}
	}
	void delDoor(float currentTime)
	{
		if(!move && doorCount <= 3 && currentTime >= doorTimeTick)
		{
			switch(doorCount)
			{
				case 0:
					Destroy(GameObject.Find("門"));
					doorCount++;
					doorTimeTick = currentTime + 0.5f;
					break;
				case 1:
					Destroy(GameObject.Find("門 (1)"));
					doorCount++;
					doorTimeTick = currentTime + 0.5f;
					break;
				case 2:
					Destroy(GameObject.Find("門 (2)"));
					doorCount++;
					doorTimeTick = currentTime + 0.5f;
					break;
				case 3:
					if(gameObject.tag == "我")
					{
						StartCoroutine(fadeTest(""));
						doorCount++;	
					}
					break;
				default:
					return;
			}
		}
	}
	public IEnumerator fadeTest(string s)
	{	
		SceneFader fade = Instantiate(sceneFader);
		yield return StartCoroutine(fade.FadeOut(2.5f));
		yield return Plot_Four.async.allowSceneActivation = true;
		yield return null;
	}
}