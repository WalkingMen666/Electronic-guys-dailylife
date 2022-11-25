using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("已退出遊戲");
    }
    public void backToPreviousPage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("已回到前一個場景");
    }
}