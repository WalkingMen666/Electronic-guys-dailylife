using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;	// 跟隨相機的位置
	public float smoothing;		// 平滑移動的數值(線性插值)

	public Vector2 minPosition; // 可以移動的最小座標
	public Vector2 maxPosition; // 可以移動的最大座標

	void Start()
	{
		
	}
	
	void Update()
	{
		if(target != null)
		{
			if(transform.position != target.position)
			{
				Vector3 targetPos = target.position;
				targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x); // 限制 x 回傳值為 min 到 max 
				targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y); // 限制 y 回傳值為 min 到 max 
				transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
			}
		}
	}

	// 限制相機位置
	public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
	{
		minPosition = minPos;
		maxPosition = maxPos;
	}
}