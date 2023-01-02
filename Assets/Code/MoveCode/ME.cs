using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ME : MonoBehaviour
{
	//控制圖層用
	SpriteRenderer sprite;
	public static int sortingOrder = 2;

	bool NowCanMove = true;
	bool nowUp = false;
	bool nowDown = false;
	bool nowLeft = false;
	bool nowRight = false;
	bool firstTime = true;
	bool highSpeed = false;
	bool high = true;
	bool enAble = true;
	Vector3 move;
	Vector3 last;
	Collider2D reach;

	[Header("UI物件")]
	public GameObject dialogBox;		// 對話框(透明圖片背景)
	public Text dialogBoxText;			// 顯示文字的地方
	string showText = "";				// 要顯示的文字
	float charsPerSecond = 0.1f;		// 打字時間間隔
	private bool isActive = false;		// 打字機效果是否動作
	private float timer;				// 計時器
	private int currentPos = 0;			// 當前打字位置
	public Text thingsToDo;				//目標提示
	float hintTimer = 30f;				// 提示觸發計時器
	string hintName = "摯";				// 提示觸發物件
	int openHint = 0;					// 開啟提示時間計時
	float meJumpTimer;					// "我"的提示計時
	Vector3 hintMoveSpeed = new Vector3(0, 0.01f, 0); // 提示物件跳躍速度
	Vector3 meJumpSpeed = new Vector3(0.01f, 0, 0);	  // 我跳躍速度

	void Start()
	{
		GameData.openMeMove = false; // 此時所有角色都在位置上不能移動
		GameData.closeHint = false;
		timer = 0;
		isActive = false;
		charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
		dialogBoxText.text = "";//獲取Text的文本信息，保存到words中，然後動態更新文本顯示內容，實現打字機的效果
		changePlayerPos();
	}
	void OnTriggerEnter2D(Collider2D other)  //colliderTrigger2D接觸判斷 要先將物件的觸發器打勾
	{
		if(other.tag == hintName) 
		{
			GameData.closeHint = true;
			if(SceneManager.GetActiveScene().buildIndex == 3) AddScenes.goToNextScene = true;
			if(SceneManager.GetActiveScene().buildIndex == 2) GameObject.FindGameObjectWithTag("摯").transform.localPosition = new Vector3(-8, -4, 0);
		}
		if (other.tag != "台" && other.tag != "門1" && other.tag != "垃" &&　other.tag != "蟲")
		{
			reset();
			this.gameObject.transform.position = last;
			reach = other;
			GameData.textTouching = false;
			GameData.textTouchName = other.tag;
		}
		else  //覆蓋
		{
			sprite = other.gameObject.GetComponent<SpriteRenderer>();
			sprite.sortingOrder = 0;
		}
	}
	//覆蓋
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "台" || other.tag == "門1" || other.tag == "垃" || other.tag == "蟲")
		{
			sprite.sortingOrder = 2;
		}
	}
	void Update()
	{
		if(GameData.openMeMove) 
		{
			goPlotFive();
			Movement();
			OnStartWriter();
			if (Input.GetKeyDown(KeyCode.E) && !GameData.textTouching)
			{
				typeWritterEffect(GameData.textTouchName);
			}
			if (isActive || timer == 0)
			{
				if(this.gameObject.transform.position != GameData.textPlayerPos)
				{
					isActive = false;
					dialogBox.SetActive(false);
					dialogBoxText.text = "";
					OnFinish();
				}
			}
		}
		if(GameData.allDone == GameData.countCharacter && Plot_Two.pressSpace)
		{
			leaveClassRoomOrNot();
		}
	}
	void Movement()
	{
		Vector3 Pos = gameObject.transform.localPosition;
		var up = Input.GetKeyDown(KeyCode.W);
		var down = Input.GetKeyDown(KeyCode.S);
		var left = Input.GetKeyDown(KeyCode.A);
		var right = Input.GetKeyDown(KeyCode.D);
		if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && (Pos.x == GameData.maxPosX + 0.5f || Pos.x == GameData.minPosX - 0.5f || Pos.y == GameData.maxPosY + 0.5f || Pos.y == GameData.minPosY - 0.5f))
		{
			reset();
			this.gameObject.transform.position = last;
		}
		else
		{
			if ((up && NowCanMove) || nowUp)
			{
				NowCanMove = false;
				nowUp = true;
				MoveUp();
			}
			if ((down && NowCanMove) || nowDown)
			{
				NowCanMove = false;
				nowDown = true;
				MoveDown();
			}
			if ((left && NowCanMove) || nowLeft)
			{
				NowCanMove = false;
				nowLeft = true;
				MoveLeft();
			}
			if ((right && NowCanMove) || nowRight)
			{
				NowCanMove = false;
				nowRight = true;
				MoveRight();
			}
		}
	}
	void MoveUp()
	{
		move = new Vector3(0, 0.5f, 0);
		if (firstTime)
		{
			last = this.gameObject.transform.position;
			firstTime = false;
			this.gameObject.transform.position += move;
			highSpeed = false;
			Invoke("delay", 0.3f);
		}
		if (highSpeed)
		{
			if (high)
			{
				if (GameData.notTouching)
				{
					highMove();
					Invoke("change", 0.1f);
				}
			}
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			reset();
			GameData.textPlayerPos = this.gameObject.transform.position;
		}
	}
	void MoveDown()
	{
		move = new Vector3(0, -0.5f, 0);
		if (firstTime)
		{
			last = this.gameObject.transform.position;
			this.gameObject.transform.position += move;
			firstTime = false;
			highSpeed = false;
			Invoke("delay", 0.3f);
		}
		if (highSpeed)
		{
			if (high)
			{
				highMove();
				Invoke("change", 0.1f);
			}
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			reset();
			GameData.textPlayerPos = this.gameObject.transform.position;
		}
	}
	void MoveLeft()
	{
		move = new Vector3(-0.5f, 0, 0);
		if (firstTime)
		{
			last = this.gameObject.transform.position;
			this.gameObject.transform.position += move;
			firstTime = false;
			highSpeed = false;
			Invoke("delay", 0.3f);
		}
		if (highSpeed)
		{
			if (high)
			{
				highMove();
				Invoke("change", 0.1f);
			}
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			reset();
			GameData.textPlayerPos = this.gameObject.transform.position;
		}
	}
	void MoveRight()
	{
		move = new Vector3(0.5f, 0, 0);
		if (firstTime)
		{
			last = this.gameObject.transform.position;
			this.gameObject.transform.position += move;
			firstTime = false;
			highSpeed = false;
			Invoke("delay", 0.3f);
		}
		if (highSpeed)
		{
			if (high)
			{
				highMove();
				Invoke("change", 0.1f);
			}
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			reset();
			GameData.textPlayerPos = this.gameObject.transform.position;
		}
	}
	void reset()
	{
		nowUp = false;
		nowDown = false;
		nowLeft = false;
		nowRight = false;
		NowCanMove = true;
		firstTime = true;
		highSpeed = false;
		enAble = false;
	}
	void delay()
	{
		if (!enAble)
		{
			enAble = true;
			highSpeed = true;
		}
	}
	void highMove()
	{
		last = this.gameObject.transform.position;
		this.gameObject.transform.position += move;
		high = false;
	}
	void change()
	{
		high = true;
	}
	void leaveClassRoomOrNot()
	{
		if(SceneManager.GetActiveScene().buildIndex > 2) GameData.exitClassroom = true;
		else if(SceneManager.GetActiveScene().buildIndex == 2)
		{	
			if(!GameData.exitClassroom)
			{
				if(openHint == 0)
				{
					openHint++;
					meJumpTimer = Time.time;
					meJump();
				}
				else if(openHint == 1) meJump();
				else if(openHint == 2)
				{
					hintTimer += Time.time;
					openHint++;
					jumpHint();
				}
				else if(openHint == 3) jumpHint();
			}
			else GameData.closeHint = true;
		}
	}
	void meJump()
	{
		Vector3 Pos = GameObject.Find("我").transform.localPosition;
		if(Time.time <= meJumpTimer + 0.2f)
		{
			Pos += meJumpSpeed;
		}
		else if(Time.time <= meJumpTimer + 0.6f)
		{
			Pos -= meJumpSpeed;
		}
		else
		{
			Pos = new Vector3(1, -1.5f, 0);
			openHint++;
			if(openHint == 2) 
			{
				GameData.openMeMove = true;
			}
		}
		GameObject.Find("我").transform.localPosition = Pos;
	}
	void jumpHint()
	{
		GameData.hintPos = GameObject.Find(hintName).transform.localPosition;
		if (Time.time > hintTimer)
		{
			if (!GameData.closeHint)
			{
				if (Time.time <= hintTimer + 0.2f)
				{
					GameObject.Find(hintName).transform.localPosition += hintMoveSpeed;
				}
				else if (Time.time <= hintTimer + 0.4f)
				{
					GameObject.Find(hintName).transform.localPosition -= hintMoveSpeed;
				}
				else
				{
					GameObject.Find(hintName).transform.localPosition = GameData.hintPos;
					hintTimer = Time.time + 2f;
				}
			}
			else GameObject.Find(hintName).transform.localPosition = GameData.hintPos;
		}
	}
	void goPlotFive()
	{
		if(SceneManager.GetActiveScene().buildIndex == 5 && !GameData.finishHideAndSeek)
		{
			if(this.gameObject.transform.position.x >= -6)
			{
				GameData.openMeMove = false;
				Plot_Five.openDialog = true;
			}
		}
	}
	void changePlayerPos()
	{
		switch (SceneManager.GetActiveScene().buildIndex)
		{
			case 2:
				GameData.maxPosX = 8.5f;
				GameData.minPosX = -8.5f;
				GameData.maxPosY = 4.5f;
				GameData.minPosY = -4.5f;
				thingsToDo.text = "去找一下摯友說話唄!";
				hintName = "摯";
				GameData.closeHint = false;
				if(GameData.exitClassroom) 
				{
					GameData.openMeMove = true;
					GameData.closeHint = true;
				}
				break;
			case 3:
				GameData.maxPosX = 8.5f;
				GameData.minPosX = -8.5f;
				GameData.maxPosY = 23f;
				GameData.minPosY = -14.5f;
				hintName = "摯";
				thingsToDo.text = "去搭電梯吧~";
				GameData.closeHint = false;
				if(GameData.Plot2_CloseDialog) GameData.openMeMove = true;
				break;
			case 4:
				hintName = "";
				thingsToDo.text = "";
				GameData.closeHint = true;
				break;
			case 5:
				GameData.maxPosX = 8.5f;
				GameData.minPosX = -10.5f;
				GameData.maxPosY = 4.5f;
				GameData.minPosY = -4.5f;
				if(!GameData.finishHideAndSeek) GameData.PlayerPos = new Vector3(-10, -0.5f, 0);
				GameData.closeHint = true;
				GameData.openMeMove = true;
				hintName = "";
				thingsToDo.text = "繼續前進~!";
				break;
			case 7:
				GameData.maxPosX = 8.5f;
				GameData.minPosX = -8.5f;
				GameData.maxPosY = 4.5f;
				GameData.minPosY = -4.5f;
				GameData.closeHint = true;
				if(!GameData.finishPlotSix) 
				{
					GameData.openMeMove = false;
					GameData.PlayerPos = new Vector3(-7.5f, 0, 0);
				}
				else GameData.openMeMove = true;
				hintName = "";
				thingsToDo.text = "進工廠準備考試吧!";
				break;
			case 8:
				GameData.maxPosX = 8.5f;
				GameData.minPosX = -8.5f;
				GameData.maxPosY = 4.5f;
				GameData.minPosY = -4.5f;
				GameData.closeHint = true;
				hintName = "";
				thingsToDo.text = "到座位上準備考試吧";
				if (!GameData.finishFirstPlotInFactory) GameData.PlayerPos = new Vector3(-6.5f, 3.5f, 0);
				else if(GameData.finishFirstPlotInFactory) GameData.openMeMove = true;
				else if(GameData.finishAllQue)
				{
					GameData.openMeMove = false;
					GameData.PlayerPos = new Vector3(-4.5f, 1f, 0);
				}
				else GameData.openMeMove = false;
				break;
			default:
				GameData.closeHint = true;
				break;
		}
		if(!GameData.closeHint) GameData.hintPos = GameObject.Find(hintName).transform.localPosition;
		GameObject.Find("我").transform.position = GameData.PlayerPos;
	}
	void typeWritterEffect(string tag)
	{
		switch (tag)
		{
			case "講":
				showText = "粉筆的聚集地，上面有些口水，可能是來自前面那位的......";
				break;
			case "桌":
				showText = "e04su3su;6…塗鴉因某些原因顯示亂碼，可以自己打打看。";
				break;
			case "師":
				showText = "閉嘴閉嘴閉嘴，吵死了!!!還不快去實習教室!";
				break;
			case "板":
				showText = "看起來明明是綠的，但大家都說他黑，真是奇怪。";
				break;
			case "椅":
				showText = "一張椅子，又晃又硬，坐起來不怎麼舒服。";
				break;
			case "學":
				showText = "欸欸欸，誰有電梯卡阿?  Ray有？  等我等我！！";
				break;
			case "牆":
				showText = "白白淨淨的，多虧了那幾位愛乾淨的（強迫症的）同學。";
				break;
			case "窗":
				showText = "為了遮擋陽光，底下一半被貼上了霧面貼紙。";
				break;
			case "臭":
				showText = "屁之呼吸，第貳式：水屁！！噗~啵~噗滋~~(散發噁心臭味)";
				break;
			case "美":
				showText = "我怎麼這麼好看~~~這麼好看怎麼辦！";
				break;
			case "梁":
				showText = "人家有傘,我有大頭!";
				break;
			case "劉":
				showText = "嗚嗚嗚...我的水煎包皮掉了...嗚嗚嗚...";
				break;
			case "童":
				showText = "呵^________^";
				break;
			case "畢":
				showText = "立志成為音樂宅男oh my gosh~~";
				break;
			case "彭":
				showText = "人類是一株會思考的蘆葦";
				break;
			case "摯":
				if(GameData.Plot2_CloseDialog) showText = "進去電梯阿!你不是有電梯卡";
				else showText = "欸,走啊走啊,等等是班導的基本電學實習ㄟ~";
				break;
			case "垃":
				showText = "垃圾不會說話";
				break;
			case "欄":
				showText = "冷冰冰的鐵欄杆，上面覆蓋著一層髒汙。";
				break;
			case "矮":
				showText = "我很好奇一百五以上的空氣是不是比較新鮮？";
				break;
			case "滅":
				showText = "火災類型ABCD普油電金，實習工廠必備用品。";
				break;
			case "緊":
				showText = "二年級的工業配線，每日一響是常態。";
				break;
			case "源":
				showText = "電壓電流產生器，雖然老師阻止，但我們都活線作業。";
				break;
			case "示":
				showText = "圖像遇到問題AUTO SET就好，有什麼難的。";
				break;
			case "訊":
				showText = "訊號產生器，高阻抗模式害我被扣了好多分。";
				break;
			case "表":
				showText = "有萬用和三用，我個人認為萬用比較方便。 ";
				break;
			case "櫃":
				showText = "一般的櫃子，介於生鏽與不生鏽之間。 ";
				break;
			case "二":
				showText = "老師說，發光二極體的顏色取於材質，亮度跟電流正比。";
				break;
			case "感":
				showText = "一個電感。";
				break;
			case "容":
				showText = "一個電容。";
				break;
			case "阻":
				showText = "一堆電阻。";
				break;
			case "晶":
				showText = "BJT FET NPN PNP 各式各樣的電晶體。";
				break;
			case "學1":
				showText = "我其實姓顏，偷偷跟你說......有一個好看的學妹在化一甲！";
				break;
			case "學2":
				showText = "ㄟㄟ晚點告訴我你剛剛做了甚麼夢，到底要怎麼樣才可以踢到別人";
				break;
			case "學3":
				showText = "欸你知道這題怎麼解嗎......你都不會那我也不用會了啦哈哈";
				break;	
			case "學4":
				showText = "跟你說個好消息，聽說隔壁班那個很正的好像對你有興趣(¬‿¬ )";
				break;
			case "學5":
				showText = "走開啦~學霸!上課睡覺成績還那麼好，勸你走路注意一點，小心半路遇到教官";
				break;
			case "電":
				showText = "滋~滋~滋~";
				break;
			case "機":
				showText = "歐金ㄐ，阿不對，晚上還是乖乖睡覺好了";
				break;
			case "化":
				showText = "...這裡甚麼都沒有";
				break;
			case "工":
				showText = "兩橫一豎，簡單暴力";
				break;
			case "製":
				showText = "看到這個字總會讓人想做些有趣的東西呢~ 欸?沒有嗎?";
				break;
			case "圖":
				showText = "...這裡甚麼都沒有";
				break;
			case "板2":
				showText = "...這裡甚麼都沒有";
				break;
			case "金":
				showText = "...這裡甚麼都沒有";
				break;
			case "室":
				showText = "聽說這裡妹~妹~很多喔";
				break;
			case "設2":
				showText = "...這裡甚麼都沒有";
				break;
			case "械":
				showText = "...這裡甚麼都沒有";
				break;
			case "洗":
				showText = "拿來洗東西的地方，欸欸欸，可別在這洗澡欸";
				break;
			case "梯":
				showText = "電梯?樓梯??手扶梯???";
				break;
			case "彭1":
				showText = "我的一切都給你，讓我干涉妳的人生吧!";
				break;
			case "瑞":
				showText = "嗯?你問我的特色是什麼?我特色阿!";
				break;
		}
		if(GameData.textTouchName != "Untagged")
		{
			isActive = true;
			dialogBox.SetActive(true);
			OnStartWriter();	
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
					OnFinish();
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
		GameData.textTouching = true;
	}
}