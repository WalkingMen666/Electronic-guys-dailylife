using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemCall : MonoBehaviour
{
	public static int sceneNum;                     // 場景編號

	void Start()
	{
		sceneNum = SceneManager.GetActiveScene().buildIndex;
	}
	
	/// 下一個場景
	public static void changeScene_Add()
	{
		print(sceneNum);
		if(sceneNum == 5 && GameData.finishHideAndSeek) SceneManager.LoadScene(sceneNum + 2);
		else SceneManager.LoadScene(sceneNum + 1);
	}
	/// 前一個場景
	public static void changeScene_Sub()
	{
		if(sceneNum == 7 || sceneNum == 5) SceneManager.LoadScene(sceneNum - 2);
		else SceneManager.LoadScene(sceneNum - 1);
	}
}