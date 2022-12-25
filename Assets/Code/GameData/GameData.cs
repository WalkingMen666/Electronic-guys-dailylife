using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
static class GameData
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
	/// 劇情六角色全部完成移動
	public static int allDone_PlotSix = 0;
	/// 劇情六(工廠外走廊)完成劇情
	public static bool finishPlotSix = false;
	/// 電阻關卡編號
	public static int resLevel = 1;
	/// 電阻限用數量
	public static string resLimit;
	/// 完成所有電阻題目
	public static bool finishAllQue = false;
	/// 工廠內第一段劇情完成
	public static bool finishFirstPlotInFactory = false;
	///工廠內第二段劇情完成
	public static bool finishSecondPlotInFactory = false;
	/// 工廠最後老師說完話
	public static bool teacherFinishDialog = false;
	/// 開啟電阻計算機模式
	public static bool openCalculationMode = false;
	/// 躲教官遊戲關卡
	public static int level = 1;
	/// 躲教官遊戲使用角色名稱
	public static string usingName = "";
	/// 進入走廊二
	public static bool enterHallway2 = false;
	/// 完成躲教官遊戲
	public static bool finishHideAndSeek = false;
	
	
	public static void reset()
	{
		maxPosX = GameData_Backup.maxPosX;
		minPosX = GameData_Backup.minPosX;
		maxPosY = GameData_Backup.maxPosY;
		minPosY = GameData_Backup.minPosY;
		notTouching = GameData_Backup.notTouching;
		textTouching = GameData_Backup.textTouching;
		textPlayerPos = GameData_Backup.textPlayerPos;
		textTouchName = GameData_Backup.textTouchName;
		PlayerPos = GameData_Backup.PlayerPos;
		hintPos = GameData_Backup.hintPos;
		closeHint = GameData_Backup.closeHint;
		openMeMove = GameData_Backup.openMeMove;
		allDone = GameData_Backup.allDone;
		countCharacter = GameData_Backup.countCharacter;
		waitTeacher = GameData_Backup.waitTeacher;
		exitClassroom = GameData_Backup.exitClassroom;
		Plot2_CloseDialog = GameData_Backup.Plot2_CloseDialog;
		allDone_PlotSix = GameData_Backup.allDone_PlotSix;
		resLimit = GameData_Backup.resLimit;
		resLevel = GameData_Backup.resLevel;
		finishAllQue = GameData_Backup.finishAllQue;
		teacherFinishDialog = GameData_Backup.teacherFinishDialog;
		openCalculationMode = GameData_Backup.openCalculationMode;
		level = GameData_Backup.level;
		usingName = GameData_Backup.usingName;
		finishSecondPlotInFactory = GameData_Backup.finishSecondPlotInFactory;
		finishHideAndSeek = GameData_Backup.finishHideAndSeek;
		finishFirstPlotInFactory = GameData_Backup.finishFirstPlotInFactory;
	}

}