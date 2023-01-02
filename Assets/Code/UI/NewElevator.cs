using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewElevator : MonoBehaviour
{
	[Header("淡出特效")]
	public SceneFader sceneFader;   // 場景淡出入
	Color color;				    // 轉場圖片顏色
	
	[Header("UI/物件")]
	public AudioSource dingSound;			// "叮" 音效
	public GameObject staticObj;			// 電梯場景物件
	public GameObject door1;				// 門1
	public GameObject door2;				// 門2
	public GameObject door3;				// 門3
	public static AsyncOperation async;
	
	[Header("變數")]
	Vector3 moveSpeed = new Vector3(0, 5, 0);		// 電梯速度
	Vector3 targetPos = new Vector3(0, -40, 0);		// 停止位置
	Vector3 fasterPos = new Vector3(0, 18, 0);		// 漸加速停止位置
	Vector3 slowerPos = new Vector3(0, -16.5f, 0);	// 漸減速停止位置
	float destroyTime = 0.5f;
	int count = 0;
	
	void Start()
	{
		door1 = GameObject.Find("門");
		door2 = GameObject.Find("門 (1)");
		door3 = GameObject.Find("門 (2)");
		dingSound = GameObject.Find("電梯劇情").GetComponent<AudioSource>();
		async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		async.allowSceneActivation = false;
	}
	
	void Update()
	{
		if(staticObj.transform.localPosition.y >= -38.9f)
		{
			normalSpeed();
		}
		else if(staticObj.transform.localPosition.y > -39.5f)
		{
			slownDown();
		}
		else if(Time.time >= destroyTime)
		{
			if(count == 0)
			{
				dingSound.Play();
				count++;
				destroyTime = Time.time + 0.5f;
				return;
			}
			destroyTime = Time.time + 0.5f;
			switch(count)
			{
				case 1:
					Destroy(door1.gameObject);
					break;
				case 2:
					Destroy(door2.gameObject);
					break;
				case 3:
					Destroy(door3.gameObject);
					break;
				default:
					StartCoroutine(fadeTest(""));
					break;
			}
			count++;
		}
	}
	
	void slownDown()
	{
		staticObj.transform.localPosition = Vector3.Lerp(staticObj.transform.localPosition, targetPos, 0.5f * Time.deltaTime);
	}
	
	void normalSpeed()
	{
		staticObj.transform.localPosition -= moveSpeed * Time.deltaTime;
	}
	
	public IEnumerator fadeTest(string s)
	{	
		SceneFader fade = Instantiate(sceneFader);
		yield return StartCoroutine(fade.FadeOut(2.5f));
		yield return async.allowSceneActivation = true;
		yield return null;
	}
}