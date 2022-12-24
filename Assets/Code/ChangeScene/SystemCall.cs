using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemCall : MonoBehaviour
{

	public static AsyncOperation sceneAsync_Add;	// 轉換場景
	public static AsyncOperation sceneAsync_Sub;	// 轉換場景
	public static int sceneNum;						// 場景編號

	void Start()
	{
		// 轉換場景
		sceneNum = SceneManager.GetActiveScene().buildIndex;
		// sceneAsync_Add = SceneManager.LoadSceneAsync(sceneNum + 1);
		// sceneAsync_Add.allowSceneActivation = false;
		// sceneAsync_Sub = SceneManager.LoadSceneAsync(sceneNum - 1);
		// sceneAsync_Sub.allowSceneActivation = false;
	}
	
	/// 下一個場景
	public static void changeScene_Add()
	{
		// print("GetIn：" + sceneNum + " ; " + sceneAsync_Add.allowSceneActivation);
		// sceneAsync_Add.allowSceneActivation = true;
		// print("Done：" + sceneNum + " ; " + sceneAsync_Add.allowSceneActivation);
		SceneManager.LoadScene(sceneNum + 1);
	}
	/// 前一個場景
	public static void changeScene_Sub()
	{
		// sceneAsync_Sub.allowSceneActivation = true;
		if(SceneManager.GetActiveScene().buildIndex == 7 || SceneManager.GetActiveScene().buildIndex == 5) SceneManager.LoadScene(sceneNum - 2);
		else SceneManager.LoadScene(sceneNum - 1);
	}
}
