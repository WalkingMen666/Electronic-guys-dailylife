using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot_Five : MonoBehaviour
{
	public SceneFader sceneFader;	// 場景淡入
	
	void Start()
	{
		StartCoroutine(fadeTest(""));
	}
	
	public IEnumerator fadeTest(string s)
	{	
		SceneFader fade = Instantiate(sceneFader);
		yield return StartCoroutine(fade.FadeIn(2.5f));
		yield return null;
	}
}