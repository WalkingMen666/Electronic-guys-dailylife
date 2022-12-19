using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
	public Slider slider;
	public Text volume;
	public GameObject muciCube;
	public GameObject musicInstant = null;
	
	void Start()
	{
		musicInstant = GameObject.FindGameObjectWithTag("sound");
		if(musicInstant == null) musicInstant = (GameObject)Instantiate(muciCube);
		
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
}
