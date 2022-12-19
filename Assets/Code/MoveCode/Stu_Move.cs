using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stu_Move : MonoBehaviour
{
	Vector3 moveSpeed = new Vector3(2, 0, 0);		// 移動速度
	Vector3 targetPos = new Vector3(9.5f, 0, 0);	// 目標位置(X軸)
	
	void FixedUpdate()
	{
		if(!HideAndSeek.openPressToContinue)
		{
			changeMoveSpeed();
			if(!HideAndSeek.openGameIntroduce) this.transform.localPosition += moveSpeed*Time.deltaTime;
			if(this.transform.localPosition.x >= targetPos.x) Destroy(this.gameObject);
		}
		else
		{
			var clones = GameObject.FindGameObjectsWithTag("學");
			foreach(var clone in clones)
			{
				Destroy(clone.gameObject);
			}
		}
	}
	void changeMoveSpeed()
	{
		switch(GameData.level)
		{
			case 1:
				moveSpeed = new Vector3(2, 0, 0);
				break;
			case 2:
				moveSpeed = new Vector3(Random.Range(1,2.5f), 0, 0);
				break;
			case 3:
				moveSpeed = new Vector3(Random.Range(0,3f), 0, 0);
				break;
			case 4:
				moveSpeed = new Vector3(Random.Range(0,5f), 0, 0);
				break;
		}
	}
}