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
	Ray2D detect;
	
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
		if(openGameIntroduce && Input.GetKeyDown(KeyCode.Escape))
		{
			openGameIntroduce = false;
			gameIntroduce.SetActive(false);
		}
		int lay = LayerMask.NameToLayer("Stage");
		// RaycastHit2D detect = Physics2D.Raycast(GameObject.FindWithTag("教官").transform.localPosition, GameObject.FindWithTag(GameData.usingName).transform.localPosition, Mathf.Infinity, lay);
		// if(detect.collider != null)
		// {
		// 	print("Work!!");
		// 	print("Name：" + detect.collider.tag);
		// }
		detect = new Ray2D(GameObject.FindWithTag("教官").transform.localPosition,GameObject.FindWithTag(GameData.usingName).transform.localPosition);
		RaycastHit2D info = Physics2D.Raycast(detect.origin, detect.direction, Mathf.Infinity, 1 << lay);
		Debug.DrawLine(detect.origin, detect.direction, Color.blue);
		if(info.collider != null)
		{
			print(info.collider.transform.gameObject.tag);
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
				}
				else sysHintText.text = "恭喜完成第"+GameData.level.ToString()+"關卡";
				pressToContinue.SetActive(true);
				openPressToContinue = true;
			}
			if(openPressToContinue)
			{
				if(Input.GetKeyDown(KeyCode.Space))
				{
					pressToContinue.SetActive(false);
					sysHint.SetActive(false);
					openPressToContinue = false;
					Destroy(GameObject.FindWithTag(GameData.usingName).gameObject);
					GameData.level++;
					print(GameData.level);
					if(GameData.level > 4) 
					{
						allPass = true;
						return;
					}
					changeUsingCharacter();
				}
			}
			if(!openPressToContinue) move();
		}
	}
	void move()
	{
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			GameObject.FindWithTag(GameData.usingName).transform.localPosition += characterMoveSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			GameObject.FindWithTag(GameData.usingName).transform.localPosition -= characterMoveSpeed * Time.deltaTime;
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