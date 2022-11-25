using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
	CanvasGroup canvasGroup;
	
	public float fadeInTime;
	public float fadeOutTime;
	
	void Awake() 
	{
		canvasGroup = GetComponent<CanvasGroup>();
		// DontDestroyOnLoad(gameObject);
	}
	
	public IEnumerator FadeOutIn(float time)
	{
		yield return FadeOut(time);
		yield return FadeIn(time);
		yield return Plot_Four.async.allowSceneActivation = true;
	}
	
	public IEnumerator FadeOut(float time)
	{
		while(canvasGroup.alpha < 1)
		{
			canvasGroup.alpha += Time.deltaTime / time;
			yield return null;
		}
	}
	
	public IEnumerator FadeIn(float time)
	{
		while(canvasGroup.alpha != 0)
		{
			canvasGroup.alpha -= Time.deltaTime / time;
			yield return null;
		}
	}
}