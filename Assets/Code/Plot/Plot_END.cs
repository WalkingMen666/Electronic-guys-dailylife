using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Plot_END : MonoBehaviour
{
	public SceneFader sceneFader;	// 場景淡入
	public static bool openFadeOut = false;	// 場景淡出
	
	void Start()
	{
		StartCoroutine(fadeTest(""));
	}
	
	void Update()
	{
		if(openFadeOut)
		{
			StartCoroutine(fadeOut(""));
			openFadeOut = false;
		}
	}
	
	public IEnumerator fadeTest(string s)
	{	
		print("GetIn");
		SceneFader fade = Instantiate(sceneFader);
		yield return StartCoroutine(fade.FadeIn(2.5f));
		yield return null;
	}
	
	public IEnumerator fadeOut(string s)
	{	
		SceneFader fade = Instantiate(sceneFader);
		yield return StartCoroutine(fade.FadeOut(2.5f));
		yield return null;
	}
}