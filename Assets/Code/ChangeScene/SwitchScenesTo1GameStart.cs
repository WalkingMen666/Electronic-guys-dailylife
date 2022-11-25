using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenesTo1GameStart : MonoBehaviour
{
	protected AudioSource chooseSound;
	protected AudioSource openAudio;
	protected AudioSource closeAudio;
	Coroutine c = null;
	public GameObject pausePanel;
	public GameObject gameMode;
	public int choice = 1;
	int Press = 0;
	AsyncOperation async_classRoom;
	AsyncOperation async_ResCalculator;

	void Start()
	{
		async_classRoom = SceneManager.LoadSceneAsync(1);
		async_classRoom.allowSceneActivation = false;
		async_ResCalculator = SceneManager.LoadSceneAsync(8);
		async_ResCalculator.allowSceneActivation = false;
		GameObject.Find("我").transform.position = new Vector3(-3.0f, 0.5f, 0);
		chooseSound = GetComponent<AudioSource>();
		openAudio = GameObject.Find("開啟音效").GetComponent<AudioSource>();
		closeAudio = GameObject.Find("關閉音效").GetComponent<AudioSource>();
	}

	void Update()
	{
		UpDownMove();
		InToScene();
	}

	void UpDownMove()
	{
		if(Press == 0)
		{
			Vector3 Pos = gameObject.transform.localPosition;
			if (Input.GetKeyDown(KeyCode.S) && choice < 3)
			{
				GameObject.Find("我").transform.position -= new Vector3(0, 2.0f, 0);
				choice++;
				chooseSound.Play();
			}
			else if (Input.GetKeyDown(KeyCode.W) && choice > 1)
			{
				GameObject.Find("我").gameObject.transform.position += new Vector3(0, 2.0f, 0);
				choice--;
				chooseSound.Play();
			}
		}
	}
	void InToScene()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			chooseSound.Play();
			if (choice == 1)
			{
				chooseGameMode();
				print("Hello");
			}
			else if (choice == 2)
			{
				setting();
			}
			else if (choice == 3)
			{
				Application.Quit();  //unity開發中不顯示 但玩家端會關閉遊戲
				Debug.Log("leave game");
			}
		}
		if(Press == 1)
		{
			if (choice == 1) chooseGameMode();
			else if (choice == 2) setting();
		}
	}
	void chooseGameMode()
	{
		if (Input.GetKeyDown(KeyCode.Return) && Press == 0)
		{
			Press = 1;
			gameMode.SetActive(true);
			GameObject.Find("Pause").GetComponent<PopBox>().showPop(gameMode);
		}
		if (Input.GetKeyDown(KeyCode.Escape) && Press == 1)
		{
			Press = 0;
			GameObject.Find("Pause").GetComponent<PopBox>().hidePop(gameMode);
			gameMode.SetActive(false);
		}
	}
	void setting()
	{
		if (Input.GetKeyDown(KeyCode.Return) && Press == 0)
		{
			Press = 1;
			pausePanel.SetActive(true);
			GameObject.Find("Pause").GetComponent<PopBox>().showPop(pausePanel);
		}
		if (Input.GetKeyDown(KeyCode.Escape) && Press == 1)
		{
			Press = 0;
			GameObject.Find("Pause").GetComponent<PopBox>().hidePop(pausePanel);
			pausePanel.SetActive(false);
		}
	}
	public void buttonClosePanel()
	{
		Press = 0;
	}
	public void sceneToClassroom()
	{
		async_classRoom.allowSceneActivation = true;
	}
	public void sceneToResMode()
	{
		async_ResCalculator.allowSceneActivation = true;
	}
}
