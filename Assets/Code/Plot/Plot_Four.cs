using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_Four : MonoBehaviour
{
	public static bool openFade;
	CanvasGroup canvasGroup;
	public SceneFader sceneFader;
	
	public float fadeInTime;
	public float fadeOutTime;
	public static AsyncOperation async;
	
	void Awake() 
	{
		canvasGroup = GetComponent<CanvasGroup>();
		openFade = false;
	}
	
	void Start()
	{
		async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		async.allowSceneActivation = false;
	}
}