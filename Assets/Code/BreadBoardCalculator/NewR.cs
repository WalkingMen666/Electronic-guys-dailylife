using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NewR : MonoBehaviour
{
    public Text targetText; // 目標
    public Text tipText; // 提示
    public Text res0; // 電阻一圖示
    public Text res1; // 電阻二圖示
    public Text res2; // 電阻三圖示
    public Text res3; // 電阻四圖示
    public Canvas canvas; // 畫布
    public GameObject ResObject; // 電阻物件
    public GameObject chooseArrow; // 電阻選擇箭頭
    public Text sysText; // 系統提示文字

    static float answer = 0;
    static string show = "";
    List<float> list = new List<float>();
    List<int> Res = new List<int>(); //電阻大小陣列
    int click = 0; // 0 => 第一次點擊 ; 1 => 第二次點擊
    int tempClick = 0; //暫存第一次點擊的位置
    int resNum = 0;
    int tip = 0;
    bool opentip = false;// 尚未作答前不提示
    int resCount = 0;

    void Start()
    {
        tipText.text = "先試試看一次吧!";
        // 輸入電阻答案
        GameData.resAnswer.Add(10);
        GameData.resAnswer.Add(32.5f);
        GameData.resAnswer.Add(10);
        addResAnswer();
        tipTexts();
        GameData.finishAllQue = false;
    }
    void Update()
    {
        // 根據左右鍵改變所使用的電阻大小
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            resNum--;
            if (resNum < 0)
            {
                resNum = Res.Count - 1;
                GameObject.Find("ChooseArrow").transform.localPosition = new Vector3(450, -510, 0);
            }
            else
            {
                GameObject.Find("ChooseArrow").transform.localPosition -= new Vector3(300, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            resNum++;
            if (resNum > Res.Count - 1)
            {
                resNum = 0;
                GameObject.Find("ChooseArrow").transform.localPosition = new Vector3(-450, -510, 0);
            }
            else
            {
                GameObject.Find("ChooseArrow").transform.localPosition += new Vector3(300, 0, 0);
            }
        }
    }
    public void tipTexts()
    {
        GameData.tipWords.Add("(10//10)+(10//10)");
        GameData.tipWords.Add("10+10+10+10//10//10//10");
        GameData.tipWords.Add("(10+10+10)//(10+10//10)");
    }
    public void openTip()
    {
        if (opentip)
        {
            tip++;
            if (tip == 1) tipText.text = GameData.tipWords[GameData.resLevel - 1];
            else tipText.text = "夠簡單囉~剩下的請自己加油:)";
        }
        else tipText.text = "就叫你先試一次了!";
    }
    public void addResAnswer()
    {
        if (GameData.resLevel <= GameData.resAnswer.Count) // 依關卡改變目標電阻大小
        {
            targetText.text = "目標：" + GameData.resAnswer[GameData.resLevel - 1].ToString() + "KΩ";
            resValue();
        }
        else
        {
            targetText.text = "已完成所有目標";
            GameData.finishAllQue = true;
        }
        res0.text = Res[0].ToString() + "KΩ"; // 改變電阻選項數值表示
        res1.text = Res[1].ToString() + "KΩ";
        res2.text = Res[2].ToString() + "KΩ";
        res3.text = Res[3].ToString() + "KΩ";
    }
    void resValue()
    {
        //輸入電阻大小
        //依關卡改變 GameData.resSum 與 GameData.oResLimit;
        switch (GameData.resLevel)
        {
            case 1:
                GameData.oResLimit = true;  // 開啟or關閉電阻數量限制
                Res.Add(10);       // 輸入電阻大小選項
                Res.Add(10);
                Res.Add(10);
                Res.Add(10);
                GameData.resSum = 4;        // 輸入電阻限用數量
                break;
            case 2:
                GameData.oResLimit = false;
                Res.Add(10);
                Res.Add(10);
                Res.Add(10);
                Res.Add(10);
                break;
            case 3:
                GameData.oResLimit = true;  // 開啟or關閉電阻數量限制
                Res.Add(10);       // 輸入電阻大小選項
                Res.Add(10);
                Res.Add(10);
                Res.Add(10);
                GameData.resSum = 6;        // 輸入電阻限用數量
                break;
        }
    }
    //當按下按鈕就執行一次
    public void getRes()
    {
        float Posx = EventSystem.current.currentSelectedGameObject.transform.localPosition.x;
        float Posy = EventSystem.current.currentSelectedGameObject.transform.localPosition.y;
        int front = (int)(2 - (Posy / 100));
        int back = (int)((Posx / 100) + 7);
        int resDis = 0; //電阻生成距離誤差參數
        Vector3 resScale = ResObject.gameObject.transform.localScale; //改變電阻物件比例
        if (click == 0) // 第一次點擊
        {
            tempClick = back;
            click++;
        }
        else if(click == 1)
        {
            resCount++;
            if (resCount > GameData.resSum && GameData.oResLimit)
            {
                tipText.text = "超過電阻上限囉~~";
            }
            else
            {
                if (back > tempClick) //第一次點擊的位置在第二次前面 ex: 10 1 2
                {
                    list.Add(Res[resNum]);
                    list.Add(tempClick);
                    list.Add(back);
                    resDis = back - tempClick;
                }
                else if (tempClick > back) //第二次點擊的位置在第一次前面 ex: 10 2 1
                {
                    list.Add(Res[resNum]);
                    list.Add(back);
                    list.Add(tempClick);
                    resDis = back - tempClick;
                }
            }
            click--;
            GameObject clone = Instantiate(ResObject, new Vector3((Posx - resDis * 100 + 50 * resDis) / 108, Posy / 108, 0), Quaternion.identity, canvas.transform);
            Vector3 cloneScale = new Vector3(resScale.x * resDis * 1.5f, resScale.y, 0); // 1.5是大概
            clone.transform.localScale = cloneScale;
            clone.tag = "clone";
        }
    }

    //按下提交按鈕就執行一次
    public void finish()
    {
        //StringProcess();
        //print("Debug");
        Calculation(list);
        answer = list[0];
        //print("Answer = " + answer);
        if (GameData.oResLimit && resCount != GameData.resSum)
        {
            sysText.text = "要用到指定數量喔 Smile ~";
            clear();
        }
        else
        {
            opentip = true; //可開啟提示
            if (answer == GameData.resAnswer[GameData.resLevel - 1])
            {
                print("Correct");
                if (GameData.resLevel == GameData.resAnswer.Count)
                {
                    sysText.text = "恭喜答對，所有題目都完成囉~";
                    opentip = false;
                    GameData.finishAllQue = true;
                    clear();
                }
                else
                {
                    GameData.resLevel++;
                    sysText.text = "恭喜答對，前進下一關~";
                    tipText.text = "bla~bla~bla~";
                    opentip = false;
                    clear();
                    Res.Clear();
                    addResAnswer();
                }
            }
            else
            {
                sysText.text = "答錯囉~ 再一次吧!";
                print("Wrong");
                clear();
            }
        }
    }
    public void clear()
    {
        list.Clear();// 清除麵包板上的電阻
        click = 0;
        resCount = 0;
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones) Destroy(clone);
        answer = 0;
        tip = 0;
    }

    void StringProcess()
    {

    }

    void Calculation(List<float> list)
    {
        int abnormal, bridgeCheck;
        bool except1, except2;
        Electronic.sort(list); //呼叫 Electronic 裡的sort函式
        print("Debug check");
        do
        {
            bridgeCheck = list.Count;
            Electronic.bridge(list);
        } while (bridgeCheck != list.Count);
        //print("Debug check");
        Electronic.sort(list);
        while (list.Count > 3)
        {
            except1 = except2 = true;
            abnormal = list.Count;
            Electronic.sort(list);
            Electronic.seriesMerge(list);
            Electronic.sort(list);
            if(abnormal != list.Count)
            {
                Debug.Log("After series: ");
                //Electronic.showList(list);
                abnormal = list.Count;
                except2 = false;
            }
            Electronic.parallelMerge(list);
            Electronic.sort(list);
            if(abnormal != list.Count)
            {
                Debug.Log("After parallel: ");
                //Electronic.showList(list);
                abnormal = list.Count;
                except1 = false;
            }
            if(except1 && except2)
            {
                Debug.Log("Error");
                break;
            }
        }
    }
}
