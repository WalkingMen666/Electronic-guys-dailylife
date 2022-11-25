using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText_TypewritterEffect : MonoBehaviour
{

    public GameObject dialogBox; // 對話框(透明圖片背景)
    public Text dialogBoxText; // 顯示文字的地方
    public string showText; // 要顯示的文字
    public string gameObjectName;
    private bool isPlayerTouch; // 玩家是否觸碰到要觸發文字的物件

    public float charsPerSecond = 0.1f; // 打字時間間隔
    private string words; // 保存需要顯示的文字
    private bool isActive = false; // 打字機效果是否動作
    private float timer; // 計時器
    private int currentPos = 0; // 當前打字位置

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        isActive = false;
        charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
        words = showText;
        dialogBoxText.text = "";//獲取Text的文本信息，保存到words中，然後動態更新文本顯示內容，實現打字機的效果
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerTouch && GameData.textTouchName == gameObjectName)
        {
            isActive = true;
            dialogBox.SetActive(true);
        }
        OnStartWriter();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("我"))
        {
            isPlayerTouch = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("我"))
        {
            isPlayerTouch = false;
            isActive = false;
            dialogBox.SetActive(false);
            dialogBoxText.text = "";
            OnFinish();
        }
    }
    /// <summary>
    /// 執行打字任務
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {   //判斷計時器時間是否到達
                timer = 0;
                currentPos++;
                dialogBoxText.text = words.Substring(0, currentPos);//刷新文本顯示內容
                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }

        }
    }
    /// <summary>
    /// 結束打字，初始化數據
    /// </summary>
    void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
    }
}