using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_For_PlotSix : MonoBehaviour
{
	public static bool openMove = false;	// 開啟移動
	string gameObjectName;					// 物件名稱
	Vector3 nowPos = new Vector3();			// 當前位置
	Vector3 endPos = new Vector3();			// 目標位置
	float moveDis = 0.5f;					// 移動距離
	float moveTick = 0.15f;					// 移動時間間隔
	float jumpTimer;						// 跳躍時間
	int jumpCount = 2;						// 跳躍次數
	public static bool openJumpEffect = false;		// 開啟"摯"與"童"跳跳動畫
	Vector3 jumpSpeed = new Vector3(0, 0.01f, 0);	// 跳躍速度
	bool jumping = false;							// 正在跳躍
	
	void Start()
	{
		if(!GameData.finishPlotSix)
		{
			gameObjectName = gameObject.transform.tag;
			nowPos = gameObject.transform.localPosition;
			changePos();	
		}
	}
	
	void Update()
	{
		if(!GameData.finishPlotSix)
		{
			if(openMove && Time.time >= moveTick)
			{
				nowPos = this.gameObject.transform.localPosition;
				move();
				moveTick = Time.time + 0.15f;
			}
			if(openJumpEffect && !openMove && !jumping)
			{
				if(gameObjectName == "童") jumpTimer = Time.time + 0.05f;
				if(gameObjectName == "瑞") jumpTimer = Time.time + 0.1f;
				else jumpTimer = Time.time;
				nowPos = this.gameObject.transform.localPosition;
				jumping = true;
				jump();
			}
			if(jumping) jump();
			if(!openMove && nowPos.y == endPos.y) Destroy(gameObject);
		}
	}
	
	void move()
	{
		if(nowPos.x != endPos.x) nowPos.x += moveDis;
		else if(nowPos.y != endPos.y) nowPos.y -= moveDis;
		else
		{
			openMove = false;
			GameData.allDone_PlotSix++;
			GameData.openMeMove = true;
			GameData.finishPlotSix = true;
		}
		this.gameObject.transform.localPosition = nowPos;
	}
	
	void changePos()
	{
		switch(gameObjectName)
		{
			case "摯":
				endPos = new Vector3(7.5f, -5.5f, 0);
				break;
			case "童":
				endPos = new Vector3(7.5f, -6f, 0);
				break;
			case "瑞":
				endPos = new Vector3(7.5f, -6.5f, 0);
				break;
			default:
				break;
		}
	}
	void jump()
	{
		if(openJumpEffect && jumpCount > 0 && Time.time >= jumpTimer)
		{
			if(Time.time <= jumpTimer + 0.2f)
			{
				this.gameObject.transform.localPosition += jumpSpeed;
			}
			else if(Time.time <= jumpTimer + 0.4f)
			{
				this.gameObject.transform.localPosition -= jumpSpeed;
			}
			else
			{
				this.gameObject.transform.localPosition = nowPos;
				jumpTimer += 0.7f;
				jumpCount--;
			}
		}
		else if(jumpCount <= 0)
		{
			Invoke("endJump",0.5f);
		}
	}
	void endJump()
	{
		openJumpEffect = false;
		jumping = false;
		Plot_Six.finishJump = true;
	}
}