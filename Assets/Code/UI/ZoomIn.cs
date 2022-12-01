using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
	public bool zoomActive;
	public Vector3[] Target;
	public Camera cam;
	public float speed;
	
	void Start()
	{
		cam = Camera.main;
	}
	public void LateUpdate()
	{
		if(zoomActive)
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 0.001f, speed);
			cam.transform.position = Vector3.Lerp(cam.transform.position, Target[1], speed);
		}
		else
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, speed);
			cam.transform.position = Vector3.Lerp(cam.transform.position, Target[0], speed);
		}
	}
}