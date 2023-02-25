using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_Anime : MonoBehaviour
{
	[Header("UI物件")]
	public GameObject bigTeacher;		// 大老師物件
	public GameObject snow;				// 雪乃物件
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
	float delayTimer = 0.5f;			// 劇情播放延遲時間
	float plotTimer = 0;				// 劇情計時器
	bool end = false;					// 結束劇情
	bool openMove = false;				// 開啟貼貼移動
	List<string> dialogQueue = new List<string>();	// 劇情文字佇列
	public AudioSource music;			// 重點音樂
	public AudioSource music0;			// 前置BGM
	
	[Header("文檔")]
	public TextAsset dialogFile;		// 劇情文檔	
	void Start()
	{
		GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>().Pause();
		timer = 0;
		isActive = true;
		charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
		dialogBoxText.text = "";
		dialogBox.SetActive(true);
		GetDialogText(dialogFile);
		changeDialog();
		music0 = GameObject.Find("幡").GetComponent<AudioSource>();
		music0.Play();
		StartCoroutine(FadeMusic(music0, 10f, 1));
		music = GetComponent<AudioSource>();
	}
	void Update()
	{
		if(isActive) OnStartWriter();
		else
		{
			plotTimer += Time.deltaTime;
			if(plotTimer >= delayTimer)
			{
				plotTimer = 0;
				delayDisplay();
			}
			if(end && Input.GetKeyDown(KeyCode.Space))
			{
				OnFinish();
			}
		}
		if(currentDialog >= 62 && !openMove)
		{
			if(bigTeacher.transform.localPosition.x <= 0.2 && snow.transform.localPosition.x >= -0.2)
			{
				openMove = true;
			}
			else
			{
				if(snow.transform.localPosition.x <= -0.2)
				{
					snow.transform.localPosition += new Vector3(0.2f, 0, 0)*Time.deltaTime;
				}
				if(bigTeacher.transform.localPosition.x >= 0.2)
				{
					bigTeacher.transform.localPosition -= new Vector3(0.2f, 0, 0)*Time.deltaTime;
				}
			}
		}
	}
	
	void delayDisplay()
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
		else if(!end && currentDialog == endDialog)
		{
			end = true;
			isActive = false;
			wait();
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
					// wait();
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
			// wait();
			isActive = false;
		}
		if(currentDialog == 61)
		{
			StartCoroutine(FadeMusic(music0, 5f, 0));
			music.volume = 0;
			music.Play();
			StartCoroutine(FadeMusic(music, 10f, 1));
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
		GameData.PlayerPos = new Vector3(0, 22.5f, 0);
		GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>().Play();
		SceneManager.LoadScene(3);
	}
	void wait()
	{
		hint.SetActive(true);
	}
	public static IEnumerator FadeMusic(AudioSource audioSource, float duration, float targetVolume)
	{
		float currentTime = 0;
		float start = audioSource.volume;
		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
			yield return null;
		}
		yield break;
	}
}