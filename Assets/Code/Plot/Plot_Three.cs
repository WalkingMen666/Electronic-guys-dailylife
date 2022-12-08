using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_Three : MonoBehaviour
{
	[Header("提示框")]
	public GameObject hintBox;		// 我!圖案
	public GameObject bestFriend;	// 摯
	public GameObject hint;			// 提示物件(按下Space繼續)
	
	[Header("打字機")]
	public GameObject dialogBox;	// 對話框(透明圖片背景)
	public Text dialogBoxText;		// 顯示文字的地方
	string showText = "";			// 要顯示的文字
	float charsPerSecond = 0.2f;	// 打字時間間隔
	private bool isActive = false;	// 打字機效果是否動作
	private float timer; 			// 計時器
	private int currentPos = 0; 	// 當前打字位置
	bool afterDialog = false;		// 結束對話
	
	
	bool friendMove = false;		// 開啟摯友移動
	Vector3 friendMoveSpeed = new Vector3(0, 0.5f, 0);	// 摯友移動速度
	Vector3 firendTargetPos = new Vector3(3, -4.5f, 0);	// 摯友移動目標位置
	float moveWaitTime = 0.3f;		// 摯友移動間隔時間
	
	void Start()
	{
		if(!GameData.Plot2_CloseDialog)
		{
			bestFriend.transform.localPosition = GameObject.Find("我").transform.localPosition - new Vector3(0.5f, 0, 0);
			firendTargetPos.y = GameObject.Find("我").transform.localPosition.y + 9.5f;
			hintBox.transform.position = GameObject.Find("我").transform.position + new Vector3(-0.35f, 0.11f, 0);
			timer = 0;
			isActive = false;
			charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
			dialogBoxText.text = "";
			Invoke("dialog",0.5f);
			GameData.openMeMove = false;	
			GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Stop();
		}
	}

	void Update()
	{
		if(!GameData.Plot2_CloseDialog)
		{
			if(isActive)
			{
				OnStartWriter();
			}
			else if(afterDialog)
			{
				if(Input.GetKeyDown(KeyCode.Space))
				{
					dialogBox.SetActive(false);
					hint.SetActive(false);
					showText = "";
					friendMove = true;
					afterDialog = false;
					moveWaitTime = Time.time + 0.5f;
				}
				else
				{
					dialogBox.SetActive(true);
					hint.SetActive(true);
					GameData.closeHint = true;
				}
			}
			if(friendMove && Time.time >= moveWaitTime)
			{
				if(bestFriend.transform.localPosition.y >= firendTargetPos.y)
				{
					friendMove = false;
					hintBox.SetActive(true);
					Invoke("waitClose",2f);
					GameData.openMeMove = true;
					bestFriend.transform.localPosition = new Vector3(8, 20f, 0);
					GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Play();
					GameData.Plot2_CloseDialog = true;
				}
				else
				{
					bestFriend.transform.localPosition += friendMoveSpeed;
					moveWaitTime = Time.time + 0.3f;
				}
			}
		}
		else bestFriend.transform.localPosition = new Vector3(8, 20f, 0);
	}
	
	void dialog()
	{
		showText = "摯：等等到電梯的路上會經過製圖和室設，你這色鬼別一直偷看其他班的女生阿~ 我要先去電梯那邊的廁所，不要讓我等你喔";
		isActive = true;
		dialogBox.SetActive(true);
		OnStartWriter();
	}
	void OnStartWriter()
	{
		if (isActive)
		{
			timer += Time.deltaTime;
			if (timer >= charsPerSecond)
			{   //判斷計時器時間是否到達
				timer = 0;
				currentPos++;
				if(showText[currentPos - 1] == '，') charsPerSecond = 0.5f;
				else charsPerSecond = 0.1f;
				dialogBoxText.text = showText.Substring(0, currentPos);//刷新文本顯示內容
				if (currentPos >= showText.Length)
				{
					OnFinish();
				}
			}
		}
	}
	void OnFinish()
	{
		isActive = false;
		timer = 0;
		currentPos = 0;
		afterDialog = true;
	}
	void waitClose()
	{
		hintBox.SetActive(false);
	}
}
