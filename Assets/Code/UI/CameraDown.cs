using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDown : MonoBehaviour
{
	float smooth = 0.0015f;
	
	void Start()
	{
		transform.position = new Vector3(0f, 20f, -10f);
	}

	void Update()
	{
		if(transform.position.y > -9.00001f)
		{
			if(transform.position.y > -8.7f)
			{
				transform.position += new Vector3(0f, -0.4f, 0f)*Time.deltaTime;
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, new Vector3(0f, -9f, -10f), smooth);
			}
		}
	}
}