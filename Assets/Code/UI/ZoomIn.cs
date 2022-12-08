using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomIn : MonoBehaviour
{
	public static bool zoomActive;
	public Vector3[] Target;
	public Camera cam;
	public float speed;
	AsyncOperation async;
	
	void Start()
	{
		cam = Camera.main;
		async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		async.allowSceneActivation = false;
	}
	public void LateUpdate()
	{
		if(zoomActive)
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 0.0116f, speed);
			cam.transform.position = Vector3.Lerp(cam.transform.position, Target[1], speed);
		}
		else
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, speed);
			cam.transform.position = Vector3.Lerp(cam.transform.position, Target[0], speed);
		}
		if(cam.orthographicSize <= 0.01176) async.allowSceneActivation = true;
	}
}