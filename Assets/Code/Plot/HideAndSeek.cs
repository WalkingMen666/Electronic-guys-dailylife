using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideAndSeek : MonoBehaviour
{
	[Header("物件")]
	public GameObject stu;      // "學"物件*4
	public GameObject me;		// "我"物件
	public GameObject tcy;		// "童"物件
	public GameObject ray;		// "瑞"物件
	public GameObject firend;	// "摯"物件
	
	[Header("UI")]
	public GameObject gameIntroduce;						// 遊戲說明
	public GameObject sysHint;								// 系統提示(抵達終點or其他)
	public GameObject pressToContinue;						// 按下空白鍵繼續
	public Text sysHintText;								// 系統提示文字
	public static bool openPressToContinue = false;			// 開啟"按下空白鍵繼續"
	
	
	[Header("變數")]
	Vector3 characterMoveSpeed = new Vector3(2.5f, 0, 0);	// 移動速度
	public static bool openGameIntroduce = true;			// 開啟遊戲說明面板
	Vector3 targetPos = new Vector3(8, 0, 0);				// 目標位置(X軸)
	float moveTick = 3;										// "學"生成間隔時間
	float time = 0;											// 計時器
	bool allPass = false;									// 全過關
	float startDetectLine = -6f;							// 遊戲開始偵測線
	public static List<float> stusPosX = new List<float>();	// 當前的X軸位置
	bool reStart = false;									// 重新再來一遍~~
	
	void Start()
	{
		gameIntroduce.SetActive(true);
		// 生成基礎物件
		Instantiate(me, new Vector3(-8, 1, 0), new Quaternion(0,0,0,0));
		Instantiate(tcy, new Vector3(-8, 1.5f, 0), new Quaternion(0,0,0,0));
		Instantiate(ray, new Vector3(-8, 2, 0), new Quaternion(0,0,0,0));
		Instantiate(firend, new Vector3(-8, 2.5f, 0), new Quaternion(0,0,0,0));
		Instantiate(stu, new Vector3(-11, 0, 0), new Quaternion(0,0,0,0));
		// 設定初始值
		GameData.level = 1;
		changeUsingCharacter();
	}
	
	void Update()
	{
		if(openGameIntroduce && Input.GetKeyDown(KeyCode.Space))
		{
			openGameIntroduce = false;
			gameIntroduce.SetActive(false);
		}
	}
	
	void FixedUpdate()
	{
		if(!openGameIntroduce && !allPass)
		{
			time += Time.deltaTime;
			if(time > moveTick && !openPressToContinue)
			{
				time = 0;
				Instantiate(stu, new Vector3(-11, 0, 0), new Quaternion(0,0,0,0));
			}
			if(GameObject.FindWithTag(GameData.usingName).transform.localPosition.x >= targetPos.x)
			{
				sysHint.SetActive(true);
				if(GameData.level >= 4)
				{
					sysHintText.text = "恭喜完成所有關卡!!";
					GameData.finishHideAndSeek = true;
					GameData.finishPlotSix = false;
				}
				else sysHintText.text = "恭喜完成第"+GameData.level.ToString()+"關卡";
				pressToContinue.SetActive(true);
				openPressToContinue = true;
				GameObject.FindGameObjectWithTag("教官").transform.localPosition = new Vector3(-5.5f, -3, 0);
			}
			if(openPressToContinue)
			{
				if(Input.GetKeyDown(KeyCode.Space))
				{
					pressToContinue.SetActive(false);
					sysHint.SetActive(false);
					openPressToContinue = false;
					if(reStart)
					{
						changeUsingCharacter();
						reStart = false;
					}
					else
					{
						Destroy(GameObject.FindWithTag(GameData.usingName).gameObject);
						GameData.level++;
						print(GameData.level);
						if(GameData.level > 4) 
						{
							allPass = true;
							SystemCall.changeScene_Add();
							return;
						}
						changeUsingCharacter();	
					}
				}
			}
			else
			{
				move();
				checkPos();
			}
		}
	}
	
	void checkPos()
	{
		float currentPos = GameObject.FindWithTag(GameData.usingName).transform.localPosition.x;
		stusPosX.Clear();
		var stuPos = GameObject.FindGameObjectsWithTag("學");
		int count = 0;
		foreach(var pos in stuPos)
		{
			stusPosX.Add(pos.transform.localPosition.x);
			count++;
		}
		if(currentPos > startDetectLine)
		{
			for(int i = 0; i < count; i++)
			{
				if(currentPos > stusPosX[i]-0.25 && currentPos < stusPosX[i] + 1.75f)
				{
					return;
				}
			}
			restart();
		}
	}
	
	void restart()
	{
		reStart = true;
		switch(GameData.level)
		{
			case 1:
				GameObject.Destroy(GameObject.FindWithTag("我").gameObject);
				Instantiate(me, new Vector3(-8, 1, 0), new Quaternion(0,0,0,0));
				break;
			case 2:
				GameObject.Destroy(GameObject.FindWithTag("童").gameObject);
				Instantiate(tcy, new Vector3(-8, 1.5f, 0), new Quaternion(0,0,0,0));
				Instantiate(me, new Vector3(-8, 1, 0), new Quaternion(0,0,0,0));
				break;
			case 3:
				GameObject.Destroy(GameObject.FindWithTag("瑞").gameObject);
				Instantiate(me, new Vector3(-8, 1, 0), new Quaternion(0,0,0,0));
				Instantiate(tcy, new Vector3(-8, 1.5f, 0), new Quaternion(0,0,0,0));
				Instantiate(ray, new Vector3(-8, 2, 0), new Quaternion(0,0,0,0));
				break;
			case 4:
				GameObject.Destroy(GameObject.FindWithTag("摯").gameObject);
				Instantiate(me, new Vector3(-8, 1, 0), new Quaternion(0,0,0,0));
				Instantiate(tcy, new Vector3(-8, 1.5f, 0), new Quaternion(0,0,0,0));
				Instantiate(ray, new Vector3(-8, 2, 0), new Quaternion(0,0,0,0));
				Instantiate(firend, new Vector3(-8, 2.5f, 0), new Quaternion(0,0,0,0));
				break;
		}
		GameData.level = 1;
		GameData.usingName = "我";
		sysHintText.text = "哇~!被教官看到囉~重新開始吧!";
		GameObject.FindGameObjectWithTag("教官").transform.localPosition = new Vector3(-5.5f, -3, 0);
		sysHint.SetActive(true);
		pressToContinue.SetActive(true);
		openPressToContinue = true;
	}
	
	void move()
	{
		Vector3 currentPos = GameObject.FindGameObjectWithTag(GameData.usingName).transform.localPosition;
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			GameObject.FindWithTag(GameData.usingName).transform.localPosition += characterMoveSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			GameObject.FindWithTag(GameData.usingName).transform.localPosition -= characterMoveSpeed * Time.deltaTime;
		}
		if(currentPos.x > startDetectLine + 0.5f)
		{
			GameObject.FindGameObjectWithTag("教官").transform.localPosition = new Vector3(currentPos.x, -3, 0);
		}
		if(currentPos.x < -8.5f)
		{
			GameObject.FindWithTag(GameData.usingName).transform.localPosition = new Vector3(-8.5f, currentPos.y, 0);
		}
	}
	void changeUsingCharacter()
	{
		switch(GameData.level)
		{
			case 1:
				GameData.usingName = "我";
				characterMoveSpeed = new Vector3(3.5f, 0, 0);
				break;
			case 2:
				GameData.usingName = "童";
				characterMoveSpeed = new Vector3(3.5f, 0, 0);
				break;
			case 3:
				GameData.usingName = "瑞";
				characterMoveSpeed = new Vector3(4f, 0, 0);
				break;
			case 4:
				GameData.usingName = "摯";
				characterMoveSpeed = new Vector3(6f, 0, 0);
				break;
			default:
				print("ERROR");
				break;
		}
	}
}