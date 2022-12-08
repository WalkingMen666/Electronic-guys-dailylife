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
		canvasGroup.alpha = 1;
		while(canvasGroup.alpha != 0)
		{
			canvasGroup.alpha -= Time.deltaTime / time;
			yield return null;
		}
	}
}