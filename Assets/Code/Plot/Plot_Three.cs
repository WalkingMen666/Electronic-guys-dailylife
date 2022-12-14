using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_Three : MonoBehaviour
{
	[Header("提示框")]
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
	float moveWaitTime = 0.15f;		// 摯友移動間隔時間
	float meJumpTimer ;				// 我的跳躍計時器
	Vector3 meJumpPos;				// 我的原位置
	bool openMeJump = false;		// 開啟我的跳躍
	Vector3 meJumpSpeed = new Vector3(0, 0.01f, 0);		// 我的跳躍速度
	Vector3 friendMoveSpeed = new Vector3(0, 0.5f, 0);	// 摯友移動速度
	Vector3 firendTargetPos = new Vector3(3, -4.5f, 0);	// 摯友移動目標位置
	
	void Start()
	{
		if(!GameData.Plot2_CloseDialog)
		{
			timer = 0;
			isActive = false;
			charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
			dialogBoxText.text = "";
			GameData.openMeMove = false;	
			GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Stop();
			if(GameData.PlayerPos.y > -6) 
			{
				firendTargetPos.y = GameData.PlayerPos.y + 5.5f;
				bestFriend.transform.localPosition = new Vector3(3, -5, 0);
				bestFriend = GameObject.Find("摯");
				Destroy(GameObject.Find("摯 (1)").gameObject);
			}
			else 
			{
				firendTargetPos.y = GameData.PlayerPos.y + 9.5f;
				bestFriend.transform.localPosition = new Vector3(3, -14, 0);
				bestFriend = GameObject.Find("摯 (1)");
				Destroy(GameObject.Find("摯").gameObject);
			}
			Invoke("dialog",0.5f);
		}
		else
		{
			Destroy(GameObject.Find("摯 (1)").gameObject);
			GameObject.Find("摯").transform.position = new Vector3(8, 20f, 0);
			GameData.openMeMove = true;
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
					moveWaitTime = Time.time + 0.15f;
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
					meJumpTimer = Time.time;
					meJumpPos = GameObject.Find("我").transform.localPosition;
					jumpHint();
					openMeJump = true;
					GameData.openMeMove = true;
					bestFriend.transform.localPosition = new Vector3(8, 20f, 0);
					GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Play();
					GameData.Plot2_CloseDialog = true;
				}
				else
				{
					bestFriend.transform.localPosition += friendMoveSpeed;
					moveWaitTime = Time.time + 0.15f;
				}
			}
		}
		else bestFriend.transform.localPosition = new Vector3(8, 20f, 0);
		if(openMeJump)
		{
			jumpHint();
		}
	}
	
	void jumpHint()
	{
		if (Time.time > meJumpTimer)
		{
			if (Time.time <= meJumpTimer + 0.2f)
			{
				GameObject.Find("我").transform.localPosition += meJumpSpeed;
			}
			else if (Time.time <= meJumpTimer + 0.4f)
			{
				GameObject.Find("我").transform.localPosition -= meJumpSpeed;
			}
			else
			{
				GameObject.Find("我").transform.localPosition = meJumpPos;
				meJumpTimer = Time.time + 2f;
				openMeJump = false;
			}
		}
	}
	
	void dialog()
	{
		showText = "摯：等等到電梯的路上會經過製圖和室設，你這色鬼別一直偷看其他班的女生阿~ 我要先去電梯那邊的廁所，不要讓我等";
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
}