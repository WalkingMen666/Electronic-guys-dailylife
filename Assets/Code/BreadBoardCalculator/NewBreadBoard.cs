using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NewBreadBoard : MonoBehaviour
{	
	public static float answer = 0;	// 答案
	public static string show = "";	// 運算式
	
	[Header("UI")]
	public Text targetText;			// 目標
	public Text tipText;			// 提示
	public Text res0;				// 電阻一圖示
	public Text res1;				// 電阻二圖示
	public Text res2;				// 電阻三圖示
	public Text res3;				// 電阻四圖示
	public Text sysText;			// 系統提示文字
	public Text resLimitText;		// 電阻限用數量文字
	public Text resInputText;		// 電阻輸入文字
	public Canvas canvas;			// 畫布
	public GameObject ResObject;	// 電阻物件
	public GameObject chooseArrow;	// 電阻選擇箭頭
	public GameObject sysHint;		// 系統提示
	public GameObject spaceHint;	// 按下Space關閉提示
	public GameObject resInput;		// 電阻輸入視窗
	public GameObject showResPut;	// 電阻大小放置顯示物件
	bool openSysHint;				// 開啟系統提示
	bool firstSetRes = true;		// 第一次設定電阻
	
	
	[Header("麵包板變數")]
	int click = 0;					// 點擊次數
	int tempClick = 0;				// 暫存點擊位置
	int chooseRes = 1;				// 選擇的電阻編號
	float resSize;					// 電阻大小
	int resAnswer = 0;				// 電阻答案
	bool achieveResLimit = false;	// 確認達到電阻限制(按下提交後)
	bool correctAnswer = false;		// 判斷是否為正確答案並繼續
	string hintText;				// 提示文字
	bool openHint;					// 開啟提示
	bool openSetResWindows = false;	// 開啟設定電阻視窗
	float tempResPutX1;				// 暫存電阻放置X1
	float tempResPutX2;				// 暫存電阻放置X2
	AsyncOperation async;			// 轉換場景
	float[] tempResArray = new float[4]{0,0,0,0};								// 暫存電阻選擇陣列
	List<float> breadBoardRes = new List<float>();								// 麵包板電阻列表
	List<float> resArray = new List<float>();									// 電阻儲存列表
	List<float> backUpBreadBoardRes = new List<float>();						// 計算模式儲存原麵包板電阻列表
	Dictionary<float, float> resNeedToPut = new Dictionary<float, float>();		// 需要放的電阻(電阻大小,電阻數量)
	Dictionary<float, float> resHadPut = new Dictionary<float, float>();		// 已經放的電阻(電阻大小,電阻數量)
	List<Dictionary<List<float>,List<float>>> tb = new List<Dictionary<List<float>, List<float>>>();	// 淘寶
	
	void Start()
	{
		resInput.SetActive(false);
		if(!GameData.openCalculationMode)
		{
			changeResLimit();
			changeAvailableRes();
			for(int i = 0; i < 5; i++)
			{
				tb.Add(new Dictionary<List<float>, List<float>>());
			}
			async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
			async.allowSceneActivation = false;	
		}
		else
		{
			GameObject.Find("提示按鈕").gameObject.SetActive(false);
			resInputText.text = "00";
			for(int i = 0; i < 5; i++)
			{
				tb.Add(new Dictionary<List<float>, List<float>>());
			}
			targetText.text = "任意輸入想要算的電路圖吧!";
			resArray.Clear();
			for(int i  = 0; i < 4; i++) resArray.Add(0);
			// 改變電阻選擇的文字
			res0.text = resArray[0].ToString() + "Ω";
			res1.text = resArray[1].ToString() + "Ω";
			res2.text = resArray[2].ToString() + "Ω";
			res3.text = resArray[3].ToString() + "Ω";
			openHint = true;
			resLimitText.text = "等您輸入電路";
		}
	}
	void Update()
	{
		changeChooseRes();
		if(!GameData.openCalculationMode)
		{
			if(openSysHint && Input.GetKeyDown(KeyCode.Escape))
			{
				if(GameData.finishAllQue)
				{
					async.allowSceneActivation = true;
				}
				else if(correctAnswer)
				{
					GameData.resLevel++;
					changeAvailableRes();
					changeResLimit();
				}
				openSysHint = false;
				spaceHint.SetActive(false);
				correctAnswer = false;
				GameObject.Find("Pause").GetComponent<PopBox>().hidePop(sysHint);
				PopBox.sysBoardIsOpen = false;
				clear();
			}	
		}
		else
		{
			if(Input.anyKeyDown)
			{
				changeRes("");
			}
		}
	}
	
	public void clickToChangeRes()
	{
		String buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		switch(buttonName)
		{
			case "Res":
				chooseRes = 1;
				chooseArrow.transform.localPosition = new Vector3(-450, -510, 0);
				break;
			case "Res (1)":
				chooseRes = 2;
				chooseArrow.transform.localPosition = new Vector3(-150, -510, 0);
				break;
			case "Res (2)":
				chooseRes = 3;
				chooseArrow.transform.localPosition = new Vector3(150, -510, 0);
				break;
			case "Res (3)":
				chooseRes = 4;
				chooseArrow.transform.localPosition = new Vector3(450, -510, 0);
				break;
		}
	}
	
	public void changeRes(string s)
	{
		if(s == "AllClear")
		{
			resInputText.text = "00";
			firstSetRes = true;
		}
		else if(openSetResWindows && s == "Confirm")
		{	
			int count = 0;
			foreach(char c in resInputText.text) if(c == '.') count++;
			if(count>=2) 
			{
				resInputText.text = "Error";
				return;
			}
			tempResArray[chooseRes - 1] = float.Parse(resInputText.text);
			resArray.Clear();
			for(int i = 0; i < 4; i++)
			{
				resArray.Add(tempResArray[i]);
			}
			// 改變電阻選擇的文字
			res0.text = resArray[0].ToString() + "Ω";
			res1.text = resArray[1].ToString() + "Ω";
			res2.text = resArray[2].ToString() + "Ω";
			res3.text = resArray[3].ToString() + "Ω";
			resInput.SetActive(false);
			openSetResWindows = false;
			resInputText.text = "00";
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)) s = "0";
			else if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) s = "1";
			else if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) s = "2";
			else if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) s = "3";
			else if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) s = "4";
			else if(Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) s = "5";
			else if(Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) s = "6";
			else if(Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)) s = "7";
			else if(Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)) s = "8";
			else if(Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)) s = "9";
			if(firstSetRes) 
			{
				resInputText.text = s;
				firstSetRes = false;
			}
			else resInputText.text += s;
		}
	}
	public void showHint()
	{
		if(!openHint)
		{
			sysText.text = hintText;
			showSysBoard();
			openHint = true;
		}
		else
		{
			openSysHint = false;
			spaceHint.SetActive(false);
			GameObject.Find("Pause").GetComponent<PopBox>().hidePop(sysHint);
			PopBox.sysBoardIsOpen = false;
			openHint = false;
		}
	}
	// 放置電阻
	public void putRes()
	{
		float Posx = EventSystem.current.currentSelectedGameObject.transform.localPosition.x;
		float Posy = EventSystem.current.currentSelectedGameObject.transform.localPosition.y;
		int front = (int)(2 - (Posy / 100));
		int back = (int)((Posx / 100) + 7);
		int resDis = 0;	//電阻生成距離誤差參數
		Vector3 resScale = ResObject.gameObject.transform.localScale;	//改變電阻物件比例
		resSize = resArray[chooseRes - 1];
		if(click == 0)
		{	
			tempResPutX1 = Posx;
			if(!GameData.openCalculationMode)
			{
				if(resHadPut.ContainsKey(resSize))
				{
					if(resHadPut[resSize] == resNeedToPut[resSize]) 
					{
						sysText.text = "已經達到限用數量囉";
						return;
					}
					else
					{
						click++;
						tempClick = back;
					}
				}
				else
				{
					click++;
					tempClick = back;
				}
			}
			else
			{
				click++;
				tempClick = back;
			}
		}
		else
		{
			tempResPutX2 = Posx;
			click = 0;
			if(resSize != 0 || GameData.openCalculationMode)
			{
				if(back > tempClick)
				{
					breadBoardRes.Add(resSize);
					breadBoardRes.Add(tempClick);
					breadBoardRes.Add(back);
					resDis = back - tempClick;
				}
				else if(tempClick > back)
				{
					breadBoardRes.Add(resSize);
					breadBoardRes.Add(back);
					breadBoardRes.Add(tempClick);
					resDis = back - tempClick;
				}
				else return;
			}
			else
			{
				sysText.text = "別想給我搞短路!";
				openSysHint = true;
				spaceHint.SetActive(true);
				GameObject.Find("Pause").GetComponent<PopBox>().showPop(sysHint);
				correctAnswer = false;
				clear();
				return;
			}
			// 新增電阻
			GameObject clone = Instantiate(ResObject, new Vector3((Posx - 50 * resDis) / 108, Posy / 108, 0), Quaternion.identity, canvas.transform);
			GameObject resText = Instantiate(showResPut, new Vector3(clone.transform.position.x, clone.transform.position.y + 0.35f, 0), Quaternion.identity, canvas.transform);
			resText.gameObject.GetComponentInChildren<Text>().text = resSize.ToString()+"Ω";
			resText.tag = "ResTextClone";
			Vector3 cloneScale = new Vector3(resScale.x * resDis * 1.5f, resScale.y, 0); // 1.5是大概
			clone.transform.localScale = cloneScale;
			clone.tag = "clone";
			if(!resHadPut.ContainsKey(resSize))
			{
				resHadPut.Add(resSize,1);
			}
			else
			{
				resHadPut[resSize]++;
			}
		}
	}

	// 檢查放置的電阻是否達到要求數量
	void checkOutOfLimit()
	{
		int check = 0;
		if(resHadPut.Count != 0)
		{
			for(int i = 0; i < resNeedToPut.Count; i++)
			{
				if(resNeedToPut[resArray[i]] == resHadPut[resArray[i]])
				{
					check++;
				}
			}
			if(check != resNeedToPut.Count) achieveResLimit = false;
			else achieveResLimit = true;
		}
	}
	// 當玩家按下"提交"後會執行
	public void calculate()
	{
		if(!GameData.openCalculationMode)
		{
			checkOutOfLimit();
			if(achieveResLimit)
			{
				Calculation(breadBoardRes, tb);		// 處理計算
				if(resAnswer == breadBoardRes[0])
				{
					if(GameData.resLevel != 5)
					{
						sysText.text = "正確答案!!加油~剩" + (5-GameData.resLevel).ToString() + "題了!";
						correctAnswer = true;
						showSysBoard();
					}
					else
					{
						sysText.text = "恭喜!!您已完成所有題目";
						correctAnswer = true;
						GameData.finishAllQue = true;
						showSysBoard();
					}				
				}
				else
				{
					sysText.text = "杯~杯~答錯囉~再試一次吧";
					correctAnswer = false;
					showSysBoard();
				}
			}
			else
			{
				if(resHadPut.Count != 0) sysText.text = "要用到指定數量喔";
				else sysText.text = "先放幾個電阻再交答案吧";
				correctAnswer = false;
				showSysBoard();
			}
			clear();
		}
		else
		{	
			backUpBreadBoardRes.Clear();
			foreach(var f in breadBoardRes) backUpBreadBoardRes.Add(f);
			Calculation(breadBoardRes, tb);		// 處理計算
			StringProcess(breadBoardRes, tb);	// 處理算式
			targetText.text = "答案為：" + breadBoardRes[0];
			if(show.Equals("")) show += breadBoardRes[0];	// 如果只有一顆電阻，直接回傳答案
			resLimitText.text = "運算式為：" + show;
			show = "";
			breadBoardRes.Clear();
			foreach(var f in backUpBreadBoardRes) breadBoardRes.Add(f);
		}
	}
	void showSysBoard()
	{
		PopBox.sysBoardIsOpen = true;
		GameObject.Find("Pause").GetComponent<PopBox>().showPop(sysHint);
		spaceHint.SetActive(true);
		openSysHint = true;
	}
	// 清除麵包板
	public void clear()
	{
		breadBoardRes.Clear();// 清除麵包板上的電阻
		click = 0;
		var clones = GameObject.FindGameObjectsWithTag("clone");
		foreach (var clone in clones) Destroy(clone);
		clones = GameObject.FindGameObjectsWithTag("ResTextClone");
		foreach (var clone in clones) Destroy(clone);
		answer = 0;
		tb = new List<Dictionary<List<float>, List<float>>>();
		for(int i = 0; i < 5; i++)
		{
			tb.Add(new Dictionary<List<float>, List<float>>());
		}
		resHadPut.Clear();
	}
	// 改變要使用的電阻
	void changeChooseRes()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if(chooseRes != 1)
			{
				chooseRes--;
				chooseArrow.transform.localPosition -= new Vector3(300, 0, 0);
			}
			else
			{
				chooseRes = 4;
				chooseArrow.transform.localPosition = new Vector3(450, -510, 0);
			}
			
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if(chooseRes != resArray.Count)
			{
				chooseRes++;
				chooseArrow.transform.localPosition += new Vector3(300, 0, 0);
			}
			else
			{
				chooseRes = 1;
				chooseArrow.transform.localPosition = new Vector3(-450, -510, 0);
			}
		}
		if(GameData.openCalculationMode && Input.GetKeyDown(KeyCode.LeftControl))
		{
			resInput.SetActive(true);
			openSetResWindows = true;
			firstSetRes = true;
		}
	}
	// 改變可使用的電阻
	void changeAvailableRes()
	{
		resArray.Clear();
		switch(GameData.resLevel)
		{
			case 1:
				resArray.Add(8);
				resArray.Add(0);
				resArray.Add(0);
				resArray.Add(0);
				break;
			case 2:
				resArray.Add(20);
				resArray.Add(0);
				resArray.Add(0);
				resArray.Add(0);
				break;
			case 3:
				resArray.Add(12);
				resArray.Add(3);
				resArray.Add(0);
				resArray.Add(0);
				break;
			case 4:
				resArray.Add(10);
				resArray.Add(0);
				resArray.Add(0);
				resArray.Add(0);
				break;
			case 5:
				resArray.Add(20);
				resArray.Add(30);
				resArray.Add(50);
				resArray.Add(0);
				break;
		}
		// 改變電阻選擇的文字
		res0.text = resArray[0].ToString() + "Ω";
		res1.text = resArray[1].ToString() + "Ω";
		res2.text = resArray[2].ToString() + "Ω";
		res3.text = resArray[3].ToString() + "Ω";
	}
	// 改變電阻限用數量並顯示出來；新增電阻限制到哈希表
	void changeResLimit()
	{
		resNeedToPut.Clear();
		switch(GameData.resLevel)
		{
			case 1:
				GameData.resLimit = "用3個8Ω的電阻組成24Ω";
				hintText = "這都要用提示?請好好善用串聯，你的基電老師再哭泣";
				resNeedToPut.Add(8,3);
				resAnswer = 24;
				break;
			case 2:
				GameData.resLimit = "用5個20Ω的電阻組成4Ω";
				hintText = "這都要用提示?請好好善用並聯，你的基電老師再哭泣";
				resNeedToPut.Add(20,5);
				resAnswer = 4;
				break;
			case 3:
				GameData.resLimit = "用7個12Ω，一個3Ω的電阻組成10Ω";
				hintText = "【並串並】之歌~欸?你沒聽過嗎?";
				resNeedToPut.Add(12,7);
				resNeedToPut.Add(3,1);
				resAnswer = 10;
				break;
			case 4:
				GameData.resLimit = "用6個10Ω的電阻組成10Ω";
				hintText = "兩個並、兩個串，排列組合";
				resNeedToPut.Add(10,6);
				resAnswer = 10;
				break;
			case 5:
				GameData.resLimit = "用2個20Ω，2個30Ω，1個50Ω的電阻組成24Ω";
				hintText = "用電橋阿!還是說你沒學過?抱歉我的錯，出太難了";
				resNeedToPut.Add(20,2);
				resNeedToPut.Add(30,2);
				resNeedToPut.Add(50,1);
				resAnswer = 24;
				break;
		}
		resLimitText.text = GameData.resLimit;
		targetText.text = "目標： " + resAnswer.ToString() + "Ω";
	}
	
	public static void Calculation(List<float> list, List<Dictionary<List<float>, List<float>>> tb)
	{
		int abnormal;
		bool except1, except2, except3;
		Electronic.sort(list);
		while(list.Count > 3)	//whileLoop -> debug -- list.size()沒變->無法計算
		{
			except1 = except2 = except3 = true;
			abnormal = list.Count;
			Electronic.seriesMerge(list, tb);

			if(abnormal != list.Count)
			{
				Electronic.sort(list);
				abnormal = list.Count;
				except2 = false;
			}
			Electronic.parallelMerge(list, tb);
			if(abnormal != list.Count)
			{
				Electronic.sort(list);
				abnormal = list.Count;
				except1 = false;
			}
			Electronic.bridge(list,tb);
			if(abnormal != list.Count)
			{
				Electronic.sort(list);
				abnormal = list.Count;
				except3 = false;
			}
			if(except1 && except2 && except3)
			{
				print("Error");
				break;
			}
		}
	}
	public static void StringProcess(List<float> list, List<Dictionary<List<float>, List<float>>> tb)
	{	
	
		List<float> temp = new List<float>();	//暫存 end list
		List<float> fsp = new List<float>();	//串並聯的前項
		List<float> lsp = new List<float>();	//串並聯的後項
		bool deal = false;
		int check = 0;
		
		foreach(List<float> l in tb[0].Keys)
		{
			check = 0;
			for(int i = 0; i < 3; i++)
			{
				if(list[i].Equals(l[i])) 
				{
					check++;
				}
			}
			if(check == 3)
			{
				for(int i = 0; i < tb[0][l].Count; i++)
				{
					temp.Add(tb[0][l][i]);
				}
				break;
			}
		}
		if(check != 3)
		{
			return;
		}
		foreach(List<float> l in tb[0].Keys)
		{
			check = 0;
			for(int i = 0; i < 3; i++)
			{
				if(list[i].Equals(l[i])) 
				{
					check++;
				}
			}
			if(check == 3) 
			{
				tb[0].Remove(l);
				break;
			}
		}
		for(int i = 0; i < 4; i++)
		{
			if(!tb[i+1].ContainsKey(list)) continue;
			tb[i].Add(list,tb[i+1][list]);
			tb[i+1].Remove(list);
		}
		show += "(";
		//電橋
		if(temp.Count == 15)
		{
			float sum = temp[0]+temp[3]+temp[9];
			float delta1 = temp[0]*temp[3]/sum;
			float delta2 = temp[3]*temp[9]/sum;
			float delta3 = temp[0]*temp[9]/sum;
			show += delta1 + "+(" + delta2 + "+" + temp[6] + ")//(" + delta3 + "+" + temp[12] + ")";
		}
		//終點不同 串聯
		else if(!temp[2].Equals(temp[5]))
		{
			for(int i = 0; i < 3; i++) fsp.Add(temp[i]);
			for(int i = 3; i < 6; i++) lsp.Add(temp[i]);
			string method = "+";
			foreach(List<float> l in tb[0].Keys)
			{
				check = 0;
				for(int i = 0; i < 3; i++)
				{
					if(fsp[i].Equals(l[i])) 
					{
						check++;
					}
				}
				if(check == 3)
				{
					StringProcess(fsp, tb);
					deal = true;
					break;
				}
			}
			if(!deal) 
			{
				show += fsp[0];
			}
			deal = false;
			show += method;
			foreach(List<float> l in tb[0].Keys)
			{
				check = 0;
				for(int i = 0; i < 3; i++)
				{
					if(lsp[i].Equals(l[i])) 
					{
						check++;
					}
				}
				if(check == 3)
				{
					StringProcess(lsp, tb);
					deal = true;
					break;
				}
			}
			if(!deal) 
			{
				show += lsp[0];
			}
			deal = false;
		}
		//並聯
		else
		{
			for(int i = 0; i < 3; i++) fsp.Add(temp[i]);
			for(int i = 3; i < 6; i++) lsp.Add(temp[i]);
			string method = "//";
			foreach(List<float> l in tb[0].Keys)
			{
				check = 0;
				for(int i = 0; i < 3; i++)
				{
					if(fsp[i].Equals(l[i])) 
					{
						check++;
					}
				}
				if(check == 3)
				{
					StringProcess(fsp, tb);
					deal = true;
					break;
				}
			}
			if(!deal) 
			{
				show += fsp[0];
			}
			deal = false;
			show += method;
			foreach(List<float> l in tb[0].Keys)
			{
				check = 0;
				for(int i = 0; i < 3; i++)
				{
					if(lsp[i].Equals(l[i])) 
					{
						check++;
					}
				}
				if(check == 3)
				{
					StringProcess(lsp, tb);
					deal = true;
					break;
				}
			}
			if(!deal) 
			{
				show += lsp[0];
			}
			deal = false;
		}
		show += ")";
		return;
	}
}