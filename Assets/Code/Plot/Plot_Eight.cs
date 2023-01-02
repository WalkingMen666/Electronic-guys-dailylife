using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plot_Eight : MonoBehaviour
{
	public GameObject illustrate;			// 說明物件
	public GameObject Caculatorillustrate;	// 說明物件
	bool openillustrate = false;			// 開啟說明
	
	void Start()
	{
		if(!GameData.openCalculationMode)
		{
			illustrate.SetActive(true);
			openillustrate = true;	
		}
		else
		{
			Caculatorillustrate.SetActive(true);
			openillustrate = true;
		}
	}
	void LateUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && openillustrate)
		{
			openIllustrate();
		}
	}
	public void openIllustrate()
	{
		if(!openillustrate)
		{
			if(!GameData.openCalculationMode) illustrate.SetActive(true);
			else Caculatorillustrate.SetActive(true);
			openillustrate = true;
			PopBox.illustrateIsOpen = true;
		}
		else
		{
			if(!GameData.openCalculationMode) illustrate.SetActive(false);
			else Caculatorillustrate.SetActive(false);
			openillustrate = false;
			PopBox.illustrateIsOpen = false;
		}
	}
}