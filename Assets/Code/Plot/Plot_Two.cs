using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_Two : MonoBehaviour
{
	[Header("劇情")]
	public TextAsset dialogFile;	// 劇情文件檔
	public GameObject hint;			// 提示物件(按下Space繼續)
	
	[Header("UI物件")]
	public GameObject a1;  //你
	public GameObject a2;  //們
	public GameObject a3;  //真
	public GameObject a4;  //的
	public GameObject a5;  //太
	public GameObject a6;  //誇
	public GameObject a7;  //張
	public GameObject a8;  //了
	public GameObject a9;  //，
	public GameObject a10;  //不
	public GameObject a11;  //是
	public GameObject a12;  //睡
	public GameObject a13;  //覺
	public GameObject a14;  //就
	public GameObject a15;  //聊
	public GameObject a16;  //天
	public GameObject a17;  //能
	public GameObject a18;  //好
	public GameObject a19;  //上
	public GameObject a20;  //課
	public GameObject a21;  //?
	public GameObject a22;  //算
	public GameObject a23;  //快
	public GameObject a24;  //去
	public GameObject a25;  //實
	public GameObject a26;  //習
	public GameObject a27;  //工
	public GameObject a28;  //廠
	public GameObject a29;  //等
	public GameObject a30;  //下
	public GameObject a31;  //要
	public GameObject a32;  //考
	public GameObject a33;  //試
	public GameObject a34;  //遲
	public GameObject a35;  //到
	public GameObject a36;  //!
	
	float wordGap_X = 0.5f;
	float wordGap_Y = -0.5f;
	float wordTick = 0.17f;             // 字出現時間
	float wordTickNum = 0.17f;          // 字延遲時間
	int queueCount = 0;                 // 物件佇列位置
	bool openDialog = true;             // 開啟對話
	int dialogCount = 0;                // 第幾個對話
	int endDialog;                      // 結束對話編號
	string pSpace = "/p";               // 按下空白鍵繼續
	bool pGoDown = true;                // 偵測到/p
	bool monologueING = false;			// 正在獨白
	bool afterMonologue = false;		// 獨白完了
	Vector3 startPos = new Vector3(-6.5f, 2f, 0);
	List<GameObject> showQueue = new List<GameObject>();    // 對話物件list
	List<string> dialogQueue = new List<string>();          // 對話文字list
	
	[Header("打字機")]
	public GameObject dialogBox; // 對話框(透明圖片背景)
	public Text dialogBoxText; // 顯示文字的地方
	string showText = ""; // 要顯示的文字
	float charsPerSecond = 0.2f; // 打字時間間隔
	private bool isActive = false; // 打字機效果是否動作
	private float timer; // 計時器
	private int currentPos = 0; // 當前打字位置
	
	void Start()
	{
		GameData.openMeMove = false;
		GetDialogText(dialogFile);
		changewords();
		timer = 0;
		isActive = false;
		charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
		dialogBoxText.text = "";
	}
	
	void Update()
	{
		if(!GameData.openMeMove) // 主角可以移動後就停止執行此程式
		{
			if(dialogCount == endDialog + 1) GameData.openMeMove = true;
			if(Time.time >= wordTick && openDialog)
			{
				showdialog();
				wordTick = Time.time + wordTickNum;
			}
			else if(!openDialog && !pGoDown)
			{
				if(Input.GetKeyDown(KeyCode.Space))
				{
					hint.SetActive(false);
					openDialog = true;
					pGoDown = true;
					var clones = GameObject.FindGameObjectsWithTag("clone");
					foreach (var clone in clones) Destroy(clone);

					if(dialogCount + 1 > endDialog) 
					{
						openDialog = false;
						GameData.waitTeacher = false;
						openMonologue();
						return;
					}
					else changewords();
				}
			}
			if (isActive)
			{
				OnStartWriter();
			}
		}
		if(afterMonologue)
		{
			if(Input.GetKeyDown(KeyCode.Space)) 
			{
				OnFinish();
			}
			else
			{
				hint.SetActive(true);
				dialogBox.SetActive(true);
				dialogBoxText.text = "我擦掉嘴角的口水還在回憶剛剛那充滿色彩的奇幻世界...不過還是先去找我的摯友一起去實習工廠吧!";
			}
		}
	}
	void openMonologue() // 主角獨白
	{
		showText="我擦掉嘴角的口水還在回憶剛剛那充滿色彩的奇幻世界...不過還是先去找我的摯友一起去實習工廠吧!";
		isActive = true;
		dialogBox.SetActive(true);
		OnStartWriter();
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
					afterMonologue = true;
					isActive = false;
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
		afterMonologue = false;
	}
	void GetDialogText(TextAsset file)
	{
		dialogQueue.Clear();
		dialogCount = 0;
		var dialogText = file.text.Split('\n');
		foreach(var s in dialogText)
		{
			dialogQueue.Add(s);
		}
		endDialog = dialogQueue.Count;
	}
	void changewords()
	{
		char[] c = convertDialog(dialogQueue[dialogCount]);
		showQueue.Clear();
		foreach(char c1 in c)
		{
			switch(c1)
			{
				case '你':
					showQueue.Add(a1);
					break;
				case '們':
					showQueue.Add(a2);
					break;
				case '真':
					showQueue.Add(a3);
					break;
				case '的':
					showQueue.Add(a4);
					break;
				case '太':
					showQueue.Add(a5);
					break;
				case '誇':
					showQueue.Add(a6);
					break;
				case '張':
					showQueue.Add(a7);
					break;
				case '了':
					showQueue.Add(a8);
					break;
				case '，':
					showQueue.Add(a9);
					break;
				case '不':
					showQueue.Add(a10);
					break;
				case '是':
					showQueue.Add(a11);
					break;
				case '睡':
					showQueue.Add(a12);
					break;
				case '覺':
					showQueue.Add(a13);
					break;
				case '就':
					showQueue.Add(a14);
					break;
				case '聊':
					showQueue.Add(a15);
					break;
				case '天':
					showQueue.Add(a16);
					break;
				case '能':
					showQueue.Add(a17);
					break;
				case '好':
					showQueue.Add(a18);
					break;
				case '上':
					showQueue.Add(a19);
					break;
				case '課':
					showQueue.Add(a20);
					break;
				case '?':
					showQueue.Add(a21);
					break;
				case '算':
					showQueue.Add(a22);
					break;
				case '快':
					showQueue.Add(a23);
					break;
				case '去':
					showQueue.Add(a24);
					break;
				case '實':
					showQueue.Add(a25);
					break;
				case '習':
					showQueue.Add(a26);
					break;
				case '工':
					showQueue.Add(a27);
					break;
				case '廠':
					showQueue.Add(a28);
					break;
				case '等':
					showQueue.Add(a29);
					break;
				case '下':
					showQueue.Add(a30);
					break;
				case '要':
					showQueue.Add(a31);
					break;
				case '考':
					showQueue.Add(a32);
					break;
				case '試':
					showQueue.Add(a33);
					break;
				case '遲':
					showQueue.Add(a34);
					break;
				case '到':
					showQueue.Add(a35);
					break;
				case '!':
					showQueue.Add(a36);
					break;
			}
		}
		queueCount = showQueue.Count;
	}
	char[] convertDialog(string s)
	{   
		if(s.Contains(pSpace)) 
		{
			pGoDown = false;
			s.Replace(pSpace,"");
		}
		char[] dialog_char = s.ToCharArray();
		dialogCount++;
		return dialog_char;
	}
	void showdialog()
	{
		if(openDialog)
		{
			GameObject clone = Instantiate(showQueue[showQueue.Count - queueCount], startPos, Quaternion.Euler(0, 0, 0));
			clone.tag = "clone";
			startPos.x += wordGap_X;
			queueCount--;
		}
		if(queueCount == 0) 
		{
			if(!pGoDown) 
			{
				openDialog = false;
				startPos.y = 3f;
				startPos.x = -6.5f;
				Invoke("wait",0.5f);
			}
			else
			{
				openDialog = false;
				startPos.y += wordGap_Y;
				startPos.x = -6.5f;
				openDialog = true;
				changewords();
			}
		}
	}
	void wait()
	{
		hint.SetActive(true);
	}
}