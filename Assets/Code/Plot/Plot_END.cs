using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Plot_END : MonoBehaviour
{
	public SceneFader sceneFader;	// 場景淡入
	
	void Start()
	{
		StartCoroutine(fadeTest(""));
	}
	
	public IEnumerator fadeTest(string s)
	{	
		print("GetIn");
		SceneFader fade = Instantiate(sceneFader);
		yield return StartCoroutine(fade.FadeIn(2.5f));
		yield return null;
	}
}