using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_Anime : MonoBehaviour
{
	[Header("UI物件")]
	public GameObject dialogBox;		// 對話框(透明圖片背景)
	public Text dialogBoxText;			// 顯示文字的地方
	public GameObject hint;				// 提示物件(按下Space繼續)
	string showText = "";				// 要顯示的文字
	float charsPerSecond = 0.1f;		// 打字時間間隔
	private bool isActive = false;		// 打字機效果是否動作
	private float timer;				// 計時器
	private int currentPos = 0;			// 當前打字位置
	int currentDialog = 0;				// 當前劇情編號
	int endDialog = 0;					// 結束劇情編號
	List<string> dialogQueue = new List<string>();	// 劇情文字佇列
	
	[Header("文檔")]
	public TextAsset dialogFile;		// 劇情文檔	
	
	void Start()
	{
		timer = 0;
		isActive = true;
		charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
		dialogBoxText.text = "";
		dialogBox.SetActive(true);
		GetDialogText(dialogFile);
		changeDialog();
	}
	
	void Update()
	{
		if(isActive) OnStartWriter();
		else
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if(currentDialog != endDialog)
				{
					dialogBoxText.text = "";
					currentPos = 0;
					timer = 0;
					changeDialog();
					isActive = true;
					hint.SetActive(false);
					OnStartWriter();
				}
				else OnFinish();
			}
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
			showText = dialogQueue[currentDialog];
			currentDialog++;
		}
		else
		{
			wait();
			isActive = false;
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
		SceneManager.LoadScene(3);
	}
	void wait()
	{
		hint.SetActive(true);
	}
}