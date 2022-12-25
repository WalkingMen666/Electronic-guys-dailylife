using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_Seven : MonoBehaviour
{
	[Header("劇情")]
	public TextAsset dialogFile;			// 劇情檔案
	public TextAsset dialogFile2;			// 劇情檔案2
	public GameObject hint;					// 提示物件(按下Space繼續)
	public static bool openMeDialog = false;// 開啟"我"的自白
	public static bool finishJump = false;	// 完成跳躍特效
	AsyncOperation async;
	
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
	
	bool finishFirstPlot = false;	// 完成第一段劇情
	bool finishMeMove = false;		// 完成"我"移動
	bool finishTeacherMove = false;	// 完成老師移動
	float moveTick = 0.2f;			// 移動時間間隔
	public SceneFader sceneFader;	// 場景淡出
	Vector3 targetPos = new Vector3(-4.5f, 1f, 0);			// "我"目標位置
	Vector3 teacherMoveDis = new Vector3(0.5f, 0, 0);		// 老師移動距離
	Vector3 teacherTargetPos = new Vector3(0.5f, 3.5f, 0);	// "師"目標位置
	Vector3 teacherChangePos = new Vector3(-6.5f, 4, 0);	// "師"轉換Y軸位置
	
	void Start()
	{
		if(GameData.teacherFinishDialog)
		{
			GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Play();
			GameObject.FindGameObjectWithTag("師").transform.localPosition = teacherTargetPos;
			GameObject.FindGameObjectWithTag("我").transform.localPosition = GameData.PlayerPos;
			finishFirstPlot = true;
		}
		else if (GameData.finishSecondPlotInFactory && !GameData.finishAllQue && !GameData.finishFirstPlotInFactory)
		{
			GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Play();
			GameObject.FindWithTag("師").transform.localPosition = teacherTargetPos;
			GameObject.Find("我").transform.localPosition = targetPos;
			finishFirstPlot = true;
		}
		else if(GameData.finishFirstPlotInFactory)
		{
			GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Play();
			GameObject.FindWithTag("師").transform.localPosition = teacherTargetPos;
			GameObject.FindGameObjectWithTag("我").transform.localPosition = GameData.PlayerPos;
			finishFirstPlot = true;
		}
		else if (!GameData.teacherFinishDialog)
		{
			charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
			dialogBoxText.text = "";
			timer = 0;
			GameData.openMeMove = false;
			GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Stop();
			if (!GameData.finishAllQue) GetDialogText(dialogFile);
			else
			{
				GetDialogText(dialogFile2);
				GameObject.Find("我").transform.localPosition = new Vector3(-4.5f, 1, 0);
			}
			changeDialog();
			dialogBox.SetActive(true);
			isActive = true;
			async = SceneManager.LoadSceneAsync(10);
			async.allowSceneActivation = false;
		}
	}
	void Update()
	{
		if(!isActive)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if(!GameData.finishAllQue && !GameData.finishSecondPlotInFactory)
				{
					if(!finishFirstPlot && currentDialog == 1)
					{
						hint.SetActive(false);
						dialogBox.SetActive(false);
						isActive = false;
						GameData.openMeMove = true;
						GameData.finishFirstPlotInFactory = true;
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
				else
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
					else
					{
						isActive = false;
						hint.SetActive(false);
						dialogBox.SetActive(false);
						GameData.teacherFinishDialog = true;
						StartCoroutine(fadeTest(""));
					}
				}
			}
		}
		else if ((GameData.finishSecondPlotInFactory || GameData.finishAllQue || !finishFirstPlot) || (finishFirstPlot && !GameData.finishSecondPlotInFactory)) OnStartWriter();
		if(finishFirstPlot && GameObject.Find("我").transform.localPosition == targetPos && Input.GetKeyDown(KeyCode.E))
		{
			GameData.openMeMove = false;
			GameObject.Find("粒子特效").GetComponent<ParticleSystem>().Stop();
			finishMeMove = true;
			if(GameData.finishSecondPlotInFactory) Invoke("zoomin", 0.5f);
		}
		if(finishFirstPlot && !finishTeacherMove && finishMeMove && !GameData.finishSecondPlotInFactory)
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
	public IEnumerator fadeTest(string s)
	{	
		SceneFader fade = Instantiate(sceneFader);
		yield return StartCoroutine(fade.FadeOut(2.5f));
		yield return async.allowSceneActivation = true;
		yield return null;
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
		GameData.teacherFinishDialog = true;
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
				moveTick = Time.time + 0.2f;	
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