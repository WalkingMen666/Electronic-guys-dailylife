using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plot_Seven : MonoBehaviour
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
	float charsPerSecond = 0.1f;	// 打字時間間隔
	private bool isActive = false;	// 打字機效果是否動作
	private float timer;			// 計時器
	private int currentPos = 0;		// 當前打字位置
	int currentDialog = 0;			// 當前劇情編號
	int endDialog = 0;				// 結束劇情編號
	List<string> dialogQueue = new List<string>();	// 劇情文字佇列
	
	bool finishFirstPlot = false;
	bool finishMeMove = false;
	Vector3 targetPos = new Vector3(-4.5f, 1f, 0);
	Vector3 teacherMoveDis = new Vector3(0.5f, 0, 0);
	Vector3 teacherTargetPos = new Vector3(0.5f, 3.5f, 0);
	Vector3 teacherChangePos = new Vector3(-6.5f, 4, 0);
	bool finishTeacherMove = false;
	float moveTick = 0.3f;
	
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
		GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Stop();
	}
	void Update()
	{
		if(!isActive)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if(!finishFirstPlot && currentDialog == 1)
				{
					hint.SetActive(false);
					dialogBox.SetActive(false);
					isActive = false;
					GameData.openMeMove = true;
					finishFirstPlot = true;
					GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Play();
				}
				else if(currentDialog != endDialog)
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
		else OnStartWriter();
		if(finishFirstPlot && GameObject.Find("我").transform.localPosition == targetPos && Input.GetKeyDown(KeyCode.E))
		{
			GameData.openMeMove = false;
			GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Stop();
			finishMeMove = true;
		}
		if(finishFirstPlot && !finishTeacherMove && finishMeMove)
		{
			moveTeacher();
		}
		if(finishFirstPlot && finishTeacherMove && finishMeMove)
		{
			dialogBoxText.text = "";
			currentPos = 0;
			timer = 0;
			isActive = true;
			finishMeMove = false;
			dialogBox.SetActive(true);
			changeDialog();
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
			showText = dialogQueue[currentDialog];
			currentDialog++;
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
				if(showText[currentPos - 1] == '，')
				{
					charsPerSecond = 0.5f;
				}
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
		Invoke("zoomin", 0.5f);
	}
	void wait()
	{
		hint.SetActive(true);
	}
	void moveTeacher()
	{
		Vector3 Pos = GameObject.Find("師").transform.localPosition;
		if(Pos != teacherTargetPos)
		{
			if(Time.time >= moveTick)
			{
				if(Pos == teacherChangePos) Pos.y -= 0.5f;
				else Pos.x += teacherMoveDis.x;
				moveTick = Time.time + 0.3f;	
			}
		}
		else finishTeacherMove = true;
		GameObject.Find("師").transform.localPosition = Pos;
	}
	void zoomin()
	{
		ZoomIn.zoomActive = true;
	}
}