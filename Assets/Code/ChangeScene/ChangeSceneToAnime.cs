using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneToAnime : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "我")
		{
			SceneManager.LoadScene(12);
		}
	}
}