using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plot_Six : MonoBehaviour
{
	[Header("劇情")]
	public TextAsset dialogFile;			// 劇情檔案
	public GameObject hint;					// 提示物件(按下Space繼續)
	public static bool openMeDialog = false;// 開啟"我"的自白
	public static bool finishJump = false;	// 完成跳躍特效
	
	[Header("打字機")]
	public GameObject dialogBox;	// 對話框(透明圖片背景)
	public Text dialogBoxText;		// 顯示文字的地方
	string showText = "";			// 要顯示的文字
	float charsPerSecond = 0.2f;	// 打字時間間隔
	private bool isActive = false;	// 打字機效果是否動作
	private float timer;			// 計時器
	private int currentPos = 0;		// 當前打字位置
	int currentDialog = 1;			// 當前劇情編號
	int endDialog = 0;				// 結束劇情編號
	List<string> dialogQueue = new List<string>();	// 劇情文字佇列
	
	void Start()
	{
		charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
		dialogBoxText.text = "";
		timer = 0;
		GameData.openMeMove = false;
		GetDialogText(dialogFile);
		changeDialog();
		dialogBox.SetActive(true);
		isActive = true;
	}
	void Update()
	{
		if(!isActive)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if(currentDialog != endDialog + 1)
				{
					hint.SetActive(false);
					dialogBoxText.text = "";
					currentPos = 0;
					timer = 0;
					changeDialog();
					isActive = true;
					OnStartWriter();
				}
				else OnFinish();
			}
		}
		else
		{
			OnStartWriter();
		}
		if(finishJump && currentDialog - 1 == 3)
		{
			dialogBoxText.text = "";
			changeDialog();
			dialogBox.SetActive(true);
			isActive = true;
			OnStartWriter();
		}
	}
	
	void GetDialogText(TextAsset file)
	{
		var dialogText = file.text.Split('\n');
		foreach(var s in dialogText)
		{
			dialogQueue.Add(s);
		}
		endDialog = dialogQueue.Count;
	}
	void changeDialog()
	{
		if (currentDialog != endDialog + 1)
		{
			if(currentDialog - 1 != 3 || finishJump)
			{
				showText = dialogQueue[currentDialog - 1];
				currentDialog++;
			}
			else
			{
				hint.SetActive(false);
				dialogBox.SetActive(false);
				isActive = false;
				Move_For_PlotSix.openJumpEffect = true;
			}
			if(currentDialog == endDialog + 1) Move_For_PlotSix.openMove = true;
		}
		else
		{
			wait();
			isActive = false;
		}
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
					isActive = false;
					wait();
					return;
				}
			}
		}
	}
	void OnFinish()
	{
		isActive = false;
		timer = 0;
		currentPos = 0;
		showText = "";
		hint.SetActive(false);
		dialogBox.SetActive(false);
	}
	void wait()
	{
		hint.SetActive(true);
	}
}