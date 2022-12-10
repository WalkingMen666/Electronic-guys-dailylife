using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_MoveCharacter : MonoBehaviour
{
	Vector3 origionalPos;		// 當前位置
	Vector3 targetPos;			// 目標位置
	string characterName = "";	// 角色tag
	bool pointTo = true;		// 決定先動X軸orY軸 true=>X; false=>Y
	float dis_X;				// 距離目標的X軸位置
	float dis_Y;				// 距離目標的X軸位置
	float step_X;				// 移動的X軸距離
	float step_Y;				// 移動的Y軸距離
	float timeTick = 0.3f;		// 移動間隔時間
	bool done = false;			// 此物件完成移動
	bool touch = false;			// 接觸到物件
	bool moveLeft = false;		// 目標位置是否在初始位置的左方
	bool moveUp = false;		// 目標位置是否在初始位置的上方
	bool firstActive = true;	// 第一次移動
	int waitBox = 0;			// 等待改變colliderBox
	bool waitOpenMove = false;	// 等0.5s再開始移動
	
	void Awake() 
	{
		if(!GameData.exitClassroom) 
		{
			origionalPos = this.gameObject.transform.localPosition;
			characterName = this.gameObject.tag;
			targetPos = origionalPos;
			changePos();
			changeDis();
			changeBoxSize();	
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(!done && (other.tag == "桌" || other.tag == "椅" || other.tag == "講" || other.tag == "示" || other.tag == "訊" || other.tag == "源" || other.tag == "櫃" || other.tag == "滅" || other.tag == "緊"))
		{
			touch = true;
			pointTo = !pointTo; // 先反向一次
			move();
			pointTo = !pointTo; // 移動一次後再變回原本的
			touch = false;
			waitBox = 0;
		}
	}

	void Update()
	{
		if(!GameData.waitTeacher)
		{
			if(!waitOpenMove)
			{
				timeTick += (Time.time+0.3f);
				waitOpenMove = true;
			}
			if(!done && GameData.allDone != GameData.countCharacter && Time.time >= timeTick) // allDone的數量為所有需要移動的角色數量
			{
				origionalPos = this.gameObject.transform.localPosition;
				changeDis();
				timeTick = Time.time + 0.3f;
			}
			if(GameData.allDone == GameData.countCharacter)
			{
				GameData.openMeMove = true;
			}
		}
	}
	
	void changeDis()
	{
		dis_X = targetPos.x - origionalPos.x;	// 改變目標距離當前的X軸位置
		dis_Y = targetPos.y - origionalPos.y;	// 改變目標距離當前的Y軸位置
		
		// 決定走向(向右走or向左、向上走or向下)
		if(firstActive)
		{
			if(dis_X < 0) moveLeft = true;
			else moveLeft = false;
			if(dis_Y < 0) moveUp = false;
			else moveUp = true;
			firstActive = false;
		}
		else
		{
			// 由距離目標的位置判斷要走的距離
			if(dis_X < 0) step_X = -0.5f;
			else if(dis_X > 0) step_X = 0.5f;
			else if(dis_X == 0)
			{
				pointTo = false;
				step_X = 0;
				changeBoxSize();
				waitBox++;
			}
			if(dis_Y < 0) step_Y = -0.5f;
			else if(dis_Y > 0) step_Y = 0.5f;
			else if(dis_Y == 0)
			{
				pointTo = true;
				step_Y = 0;
				changeBoxSize();
				waitBox++;
			}
			if(waitBox != 1) // 讓ontrigger在動的時候不要move
			{
				move();
			}
		}
	}
	
	void move()
	{
		if(origionalPos == targetPos)
		{
			done = true;
			GameData.allDone++;
			changeBoxSize();
		}
		if(!done)
		{
			if(pointTo)
			{
				if(step_X == 0 && touch) origionalPos.x += 0.5f;
				this.gameObject.transform.localPosition = new Vector3(origionalPos.x + step_X, origionalPos.y, 0);
			}
			else
			{
				if(step_Y == 0 && touch) origionalPos.y += 0.5f;
				this.gameObject.transform.localPosition = new Vector3(origionalPos.x, origionalPos.y + step_Y, 0);
			}
		}
	}
	
	void changeBoxSize()
	{
		var collider = GetComponent<BoxCollider2D>();
		if(!done)
		{
			if(pointTo)
			{
				if(moveLeft) collider.offset = new Vector2(-0.4f,0);
				else collider.offset = new Vector2(0.4f,0);
				collider.size = new Vector3(0.6f, 0.5f, 0);
			}
			else if(!pointTo)
			{
				if(moveUp) collider.offset = new Vector2(0f,0.4f);
				else collider.offset = new Vector2(0f,-0.4f);
				collider.size = new Vector3(0.5f, 0.6f, 0);
			}
		}
		else
		{
			collider.size = new Vector3(1, 1, 0);
			collider.offset = new Vector2(0f, 0f);
			print("Origional Size");
		}
	}
	
	void changePos() // 決定最終位置
	{
		if(SceneManager.GetActiveScene().buildIndex != 8)
		{
			switch(characterName)
			{
				case "童":
					targetPos = new Vector3(-8f, -3.5f, 0);
					break;
				case "摯":
					targetPos = new Vector3(-8f, -4f, 0);
					break;
				case "矮":
					targetPos = new Vector3(0f, -4f, 0);
					break;
				case "畢":
					targetPos = new Vector3(0.5f, -4f, 0);
					break;
				case "彭":
					targetPos = new Vector3(8f, 4.5f, 0);
					break;
				case "劉":
					targetPos = new Vector3(-4.5f, -1.5f, 0);
					break;
				case "美":
					targetPos = new Vector3(-8f, -3f, 0);
					break;
				case "臭":
					targetPos = new Vector3(-8f, -2.5f, 0);
					break;
				case "學1":
					targetPos = new Vector3(-1f, 2f, 0);
					break;
				case "學2":
					targetPos = new Vector3(-0.5f, 2f, 0);
					break;
				case "學3":
					targetPos = new Vector3(-0.5f, -4, 0);
					break;
				case "師":
					targetPos = new Vector3(-8, 5.5f, 0);
					break;
				default:
					done = true;
					break;
			}
		}
	}
}