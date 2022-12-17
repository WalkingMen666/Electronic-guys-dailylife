using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_Nine : MonoBehaviour
{
	[Header("劇情")]
	public TextAsset dialogFile;
	public Text hint;
	
	[Header("UI物件")]
	public GameObject a1;  //逗號
	public GameObject a2;  //美
	public GameObject a3;  //我
	public GameObject a4;  //的
	public GameObject a5;  //屎
	public GameObject a6;  //臭
	public GameObject a7;  //操
	
	
	float wordGap_X = 0.5f;				// X軸間隔
	float wordGap_Y = -2f;				// Y軸間隔
	float wordTick = 0.1f;             	// 字出現時間
	float wordTickNum = 0.1f;          	// 字延遲時間
	int queueCount = 0;                 // 物件佇列位置
	bool openDialog = true;             // 開啟對話
	int dialogCount = 0;                // 第幾個對話
	int endDialog;                      // 結束對話編號
	string pSpace = "/p";               // 按下空白鍵繼續
	bool pGoDown = true;                // 偵測到/p
	AsyncOperation async;				// 轉換場景
	Vector3 startPos = new Vector3(-6.5f, 3, 0);
	List<GameObject> showQueue = new List<GameObject>();    // 對話物件list
	List<string> dialogQueue = new List<string>();          // 對話文字list
	
	void Start()
	{
		GameData.openMeMove = false;
		GetDialogText(dialogFile);
		changewords();
		async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		async.allowSceneActivation = false;
	}

	void Update()
	{
		if(dialogCount + 1 == endDialog) GameData.openMeMove = true;
		if(Time.time >= wordTick && openDialog)
		{
			showdialog();
			wordTick = Time.time + wordTickNum;
		}
		else if(!openDialog && !pGoDown)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				hint.text = "";
				openDialog = true;
				pGoDown = true;
				var clones = GameObject.FindGameObjectsWithTag("clone");
				foreach (var clone in clones) Destroy(clone);

				if(dialogCount + 1 > endDialog) 
				{
					openDialog = false;
					wait();
					if(Input.GetKeyDown(KeyCode.Space)) async.allowSceneActivation = true;
					return;
				}
				else changewords();
			}
		}
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
				case '，':
					showQueue.Add(a1);
					break;
				case '美':
					showQueue.Add(a2);
					break;
				case '我':
					showQueue.Add(a3);
					break;
				case '的':
					showQueue.Add(a4);
					break;
				case '屎':
					showQueue.Add(a5);
					break;
				case '臭':
					showQueue.Add(a6);
					break;
				case '操':
					showQueue.Add(a7);
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
			if(showQueue[showQueue.Count - queueCount] == a1) wordTickNum = 0.3f;
			else wordTickNum = 0.1f;
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
				wait();
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
		hint.text = "按下Space繼續";
	}
}