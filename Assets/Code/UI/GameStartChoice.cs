using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartChoice : MonoBehaviour
{
    public int choice = 1;
    void Start()
    {
        GameObject.Find("我").transform.position = new Vector3(-3.0f, 0.5f, 0);
    }

    void Update()
    {
        UpDownMove();
        InToScene();
    }

    void UpDownMove()
    {
        Vector3 Pos = gameObject.transform.localPosition;
        if(Input.GetKeyDown(KeyCode.S) && choice < 3)
        {
            this.gameObject.transform.position -= new Vector3(0, 2.0f, 0);
            choice++;
        }
        else if(Input.GetKeyDown(KeyCode.W) && choice > 1)
        {
            this.gameObject.transform.position += new Vector3(0, 2.0f, 0);
            choice--;
        }

    }
    void InToScene()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(choice == 1)
            {
                SceneManager.LoadScene("教室");
            }
            else if(choice == 2)
            {
                SceneManager.LoadScene("開始場景音量");
            }
            else if(choice == 3)
            {
                Application.Quit();  //unity開發中不顯示 但玩家端會關閉遊戲
                Debug.Log("leave game");
            }
        }
    }
}