using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    float cameraY;      //根據camera位置判斷
    bool hit = false;   //童打龍 
    string characterName = "";	// 角色tag
    
    void Start()
    {
        characterName = this.gameObject.tag;
    }

    void OnTriggerStay2D(Collider2D other)   //讓"我"對"龍"碰撞判斷
    {
        if(other.tag == "龍" && this.tag == "我")
        {
            this.transform.position -= new Vector3(0f, 4f, 0f)*Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)   //"龍"對"童"碰撞判斷 
    {
        if(other.tag == "童")
        {
            hit = true;
        }
    }
    void DragonOut()        //滅龍
    {   
        this.transform.position += new Vector3(4f, 4f, 0f)*Time.deltaTime;
        this.transform.Rotate(new Vector3(0, 0, 10));
        if(this.transform.position.x > 10)
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        if(hit)             //打龍用
        {
            DragonOut();
        }
        cameraY = GameObject.Find("Main Camera").transform.position.y;
        if(cameraY >15)             //重設位置
        {
            setLocation();
        }
        else if(cameraY > 10)       //第一幕
        {
            move1();
        }
        else if(cameraY > 9.5)      //重設位置
        {
            setLocation();
        }
        else if(cameraY > 8)        //第二幕
        {
            move2();
        }
        else if(cameraY > 7.5)      //重設位置
        {
            setLocation();
        }
        else if(cameraY > 3.15)     //第三幕
        {
            move3();
        }
        else if(cameraY > 3)        //重設位置
        {
            setLocation();
        }
        else if(cameraY > 2)        //第四幕
        {
            move4();
        }
        else if(cameraY > 1)
        {
            setLocation();
        }
    }
    void setLocation()              //位置設定
    {
        if(cameraY > 15)
        {
            switch(characterName)
            {
                case "我":
                    this.transform.position = new Vector3(-9.5f, 9.5f, 0f);
                    break;
                case "教":
                    this.transform.position = new Vector3(-10f, 9.5f, 0f);
                    break;
            }
        }
        else if(cameraY > 9.5)
        {
            
            switch(characterName)
            {
                case "我":
                    this.transform.position = new Vector3(10f, 5.5f, 0f);
                    break;
                case "獸":    
                    this.transform.position = new Vector3(12f, 5.5f, 0f);
                    break;
                case "教":
                    Destroy(this.gameObject);
                    break;
            }
        }
        else if(cameraY > 7.5)
        {
            switch(characterName)
            {
                case "我":
                    this.transform.position = new Vector3(-10f, 2.5f, 0f);
                    break;
                case "龍":
                    this.transform.position = new Vector3(5f, 14f, 0f);
                    break;    
                case "獸":    
                    Destroy(this.gameObject);
                    break;
                
            }
        }
        else if(cameraY > 3.1)
        {
            switch(characterName)
            {
                case "童":
                    this.transform.position = new Vector3(-2f, -1f, 0f);
                    break;                    
            }
        }
        else if(cameraY > 1.5 && cameraY < 2)
        {
            switch(characterName)
            {
                case "我":
                    this.transform.position = new Vector3(10f, -11f, 0f);
                    break;                    
            }
        }
    }

    void move1()    //14~10
    {
        switch(characterName)
        {
            case "我":
                if((cameraY<14 && cameraY>13)||(cameraY<12.35))
                {
                    if(cameraY < 12.35)
                    {
                        this.transform.position += new Vector3(6f, 0f, 0f)*Time.deltaTime;
                    }
                    else
                    {
                        this.transform.position += new Vector3(3f, 0f, 0f)*Time.deltaTime;
                    }
                    
                }
                break;
            case "教":
                if(cameraY<13)
                {
                    if(cameraY < 12.3)
                    {
                        this.transform.position += new Vector3(6f, 0f, 0f)*Time.deltaTime;
                    }
                    else
                    {
                        this.transform.position += new Vector3(4f, 0f, 0f)*Time.deltaTime;  
                    }
                }
                break;
        }
    }
    void move2()    //9.5~3
    {
        switch(characterName)
        {
            case "我":
                if(cameraY<9.5 && cameraY>8)
                {
                    if(cameraY < 9.5)
                    {
                        this.transform.position -= new Vector3(6f,0f,0f)*Time.deltaTime;
                    }
                    
                }
                break;
            case "獸":
                if(cameraY<9.5 && cameraY>8)
                {
                    if(cameraY < 9.5)
                    {
                        this.transform.position -= new Vector3(6f,0f,0f)*Time.deltaTime;
                    }
                    
                }
                break;
        }
    }
    void move3()    //7~3
    {
        Vector3 tongMove = new Vector3(0f, 0f, 0f);
        if(cameraY >4.8)
        {
            tongMove = new Vector3(0f, 3f, 0f);
        }
        else if(cameraY > 4.35)
        {
            tongMove = new Vector3(6f, 0f, 0f);
        }
        else if(cameraY < 3.8 && cameraY >3.35)
        {
            tongMove = new Vector3(-6f, 0f, 0f);
        }
        else if(cameraY < 3.35 && cameraY > 3.15)
        {
            tongMove = new Vector3(0f, -3f, 0f);
        }
        switch(characterName)
        {
            case "我":
                if(cameraY<7 && cameraY>6)
                {
                    this.transform.position += new Vector3(6f, 0f, 0f)*Time.deltaTime; 
                }
                if(cameraY < 5.9 && cameraY > 5.4)
                {
                    this.transform.position += new Vector3(0f, 2f, 0f)*Time.deltaTime;
                }
                break;
            case "龍":
                if(cameraY < 6.2 && cameraY > 4.85)
                {
                    this.transform.position -= new Vector3(0f, 4f, 0f)*Time.deltaTime; 
                }
                break;
            case "童":
                if(cameraY < 5)
                {
                    this.transform.position += tongMove*Time.deltaTime;
                }
                break;
        }
    }
    void move4()    //3~2
    {
        switch(characterName)
        {
            case "我":
                this.transform.position += new Vector3(3f,0f,0f)*Time.deltaTime;                                                
                break;
        }
    }
}
