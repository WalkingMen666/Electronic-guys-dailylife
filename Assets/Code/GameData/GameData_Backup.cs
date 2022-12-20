using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameData_Backup : MonoBehaviour
{
	///移動鏡頭最大X值
	public static float maxPosX = 8.5f;
	///移動鏡頭最小X值
	public static float minPosX = -10.5f;
	///移動鏡頭最大Y值
	public static float maxPosY = 4.5f;
	///移動鏡頭最小Y值
	public static float minPosY = -4.5f;
	///PreFeb沒有觸碰到東西
	public static bool notTouching = true;
	///文字觸碰
	public static bool textTouching = true;
	///角色碰到物件位置
	public static Vector3 textPlayerPos;
	///觸碰到的打字機文字訊息內容
	public static string textTouchName  = "";
	///切換場景時對齊角色位置用
	public static Vector3 PlayerPos = new Vector3(1, -1.5f, 0);
	///音量調整
	public static float gameVolume = 0.5f;
	///場景提示物件位置
	public static Vector3 hintPos;
	/// 開關提示
	public static bool closeHint = false;
	/// 開關劇情"我"的移動
	public static bool openMeMove = false;
	/// 判斷何時教室的"我"可以移動(所有角色都完成移動)
	public static int allDone = 0;
	/// 可以移動的角色總數
	public static int countCharacter = 11;
	/// 等教室老師說完話下課才可移動
	public static bool waitTeacher = true;
	/// 已經離開教室
	public static bool exitClassroom = false;
	/// 已經結束對話二
	public static bool Plot2_CloseDialog = false;
	///劇情六角色全部完成移動
	public static int allDone_PlotSix = 0;
	/// 電阻關卡編號
	public static int resLevel = 1;
	/// 電阻限用數量
	public static string resLimit;
	///工廠內第二段劇情完成
	public static bool finishSecondPlotInFactory = false;
	/// 完成所有電阻題目
	public static bool finishAllQue = false;
	/// 工廠最後老師說完話
	public static bool teacherFinishDialog = false;
	/// 開啟電阻計算機模式
	public static bool openCalculationMode = false;
	/// 躲教官遊戲關卡
	public static int level;
	/// 躲教官遊戲使用角色名稱
	public static string usingName;
}