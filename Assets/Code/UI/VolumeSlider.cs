using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeSlider : MonoBehaviour
{
	public Slider slider;
	public Text volume;
	public GameObject muciCube;
	public GameObject musicInstant = null;
	
	void Start()
	{
		changeMusic();
		slider.value = GameData.gameVolume * 100f;
		AudioListener.volume = GameData.gameVolume;
		volume.text = (AudioListener.volume * 100f).ToString();
	}
	
	public void changeVolume()
	{
		AudioListener.volume = slider.value / 100f;
		GameData.gameVolume = AudioListener.volume;
		volume.text = (AudioListener.volume * 100f).ToString();
	}
	
	void changeMusic()
	{
		switch(SceneManager.GetActiveScene().buildIndex)
		{
			case 0:
				musicInstant = GameObject.FindGameObjectWithTag("music");
				musicInstant.tag = "sound";	
				break;
			case 1:
				if(GameObject.FindGameObjectWithTag("sound") != null) Destroy(GameObject.FindGameObjectWithTag("sound").gameObject);
				musicInstant = GameObject.FindGameObjectWithTag("music");
				musicInstant.tag = "sound";	
				break;
			case 2:
				if(GameData.exitClassroom) 
				{
					Destroy(GameObject.FindGameObjectWithTag("music"));
				}
				else
				{
					if(GameObject.FindGameObjectWithTag("sound") != null) Destroy(GameObject.FindGameObjectWithTag("sound").gameObject);
					musicInstant = GameObject.FindGameObjectWithTag("music");
					musicInstant.tag = "sound";	
				}
				break;
			case 6:
				if(GameObject.FindGameObjectWithTag("sound") != null) Destroy(GameObject.FindGameObjectWithTag("sound").gameObject);
				musicInstant = GameObject.FindGameObjectWithTag("music");
				musicInstant.tag = "sound";	
				break;
			case 7:
				if(!GameData.finishFirstPlotInFactory)
				{
					if(GameObject.FindGameObjectWithTag("sound") != null) Destroy(GameObject.FindGameObjectWithTag("sound").gameObject);
					musicInstant = GameObject.FindGameObjectWithTag("music");
					musicInstant.tag = "sound";	
				}
				else
				{
					if(GameObject.FindGameObjectWithTag("music") != null) Destroy(GameObject.FindGameObjectWithTag("music").gameObject);
				}
				break;
			case 10:
				if(GameObject.FindGameObjectWithTag("sound") != null) Destroy(GameObject.FindGameObjectWithTag("sound").gameObject);
				musicInstant = GameObject.FindGameObjectWithTag("music");
				musicInstant.tag = "sound";	
				break;
			case 11:
				if(GameObject.FindGameObjectWithTag("sound") != null) Destroy(GameObject.FindGameObjectWithTag("sound").gameObject);
				musicInstant = GameObject.FindGameObjectWithTag("music");
				musicInstant.tag = "sound";
				break;
			default:
				break;
		}
	}
}
