using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ME_For_PlotOne : MonoBehaviour
{
	SpriteRenderer sprite;
	public static int sortingOrder = 2;

	bool NowCanMove = true;
	bool nowUp = false;
	bool nowDown = false;
	bool nowLeft = false;
	bool nowRight = false;
	bool firstTime = true;
	bool highSpeed = false;
	bool high = true;
	bool enAble = true;
	Vector3 move;
	Vector3 last;
	Collider2D reach;

	void Start()
	{
		GameData.maxPosX = 8.5f;
		GameData.minPosX = -8.5f;
		GameData.maxPosY = 4.5f;
		GameData.minPosY = -4.5f;
	}

	void OnTriggerEnter2D(Collider2D other)  //colliderTrigger2D接觸判斷 要先將物件的觸發器打勾
	{
		if (other.tag != "台" && other.tag != "門1" && other.tag != "垃" && other.tag != "蟲")
		{
			reset();
			this.gameObject.transform.position = last;
			reach = other;
			GameData.textTouching = false;
			GameData.textTouchName = other.tag;
		}
		else  //覆蓋
		{
			sprite = other.gameObject.GetComponent<SpriteRenderer>();
			sprite.sortingOrder = 0;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "台" || other.tag == "門1" || other.tag == "垃" || other.tag == "蟲")
		{
			sprite.sortingOrder = 2;
		}
	}

	void Update()
	{
		if(GameData.openMeMove) Movement();
	}

	void Movement()
	{
		Vector3 Pos = gameObject.transform.localPosition;
		var up = Input.GetKeyDown(KeyCode.W);
		var down = Input.GetKeyDown(KeyCode.S);
		var left = Input.GetKeyDown(KeyCode.A);
		var right = Input.GetKeyDown(KeyCode.D);
		if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && (Pos.x == GameData.maxPosX + 0.5f || Pos.x == GameData.minPosX - 0.5f || Pos.y == GameData.maxPosY + 0.5f || Pos.y == GameData.minPosY - 0.5f))
		{
			reset();
			this.gameObject.transform.position = last;
		}
		else
		{
			if ((up && NowCanMove) || nowUp)
			{
				NowCanMove = false;
				nowUp = true;
				MoveUp();
			}
			if ((down && NowCanMove) || nowDown)
			{
				NowCanMove = false;
				nowDown = true;
				MoveDown();
			}
			if ((left && NowCanMove) || nowLeft)
			{
				NowCanMove = false;
				nowLeft = true;
				MoveLeft();
			}
			if ((right && NowCanMove) || nowRight)
			{
				NowCanMove = false;
				nowRight = true;
				MoveRight();
			}
		}
	}

	void MoveUp()
	{
		move = new Vector3(0, 0.5f, 0);
		if (firstTime)
		{
			last = this.gameObject.transform.position;
			firstTime = false;
			this.gameObject.transform.position += move;
			highSpeed = false;
			Invoke("delay", 0.3f);
		}
		if (highSpeed)
		{
			if (high)
			{
				if (GameData.notTouching)
				{
					highMove();
					Invoke("change", 0.1f);
				}
			}
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			reset();
			GameData.textPlayerPos = this.gameObject.transform.position;
		}
	}
	void MoveDown()
	{
		move = new Vector3(0, -0.5f, 0);
		if (firstTime)
		{
			last = this.gameObject.transform.position;
			this.gameObject.transform.position += move;
			firstTime = false;
			highSpeed = false;
			Invoke("delay", 0.3f);
		}
		if (highSpeed)
		{
			if (high)
			{
				highMove();
				Invoke("change", 0.1f);
			}
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			reset();
			GameData.textPlayerPos = this.gameObject.transform.position;
		}
	}
	void MoveLeft()
	{
		move = new Vector3(-0.5f, 0, 0);
		if (firstTime)
		{
			last = this.gameObject.transform.position;
			this.gameObject.transform.position += move;
			firstTime = false;
			highSpeed = false;
			Invoke("delay", 0.3f);
		}
		if (highSpeed)
		{
			if (high)
			{
				highMove();
				Invoke("change", 0.1f);
			}
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			reset();
			GameData.textPlayerPos = this.gameObject.transform.position;
		}
	}
	void MoveRight()
	{
		move = new Vector3(0.5f, 0, 0);
		if (firstTime)
		{
			last = this.gameObject.transform.position;
			this.gameObject.transform.position += move;
			firstTime = false;
			highSpeed = false;
			Invoke("delay", 0.3f);
		}
		if (highSpeed)
		{
			if (high)
			{
				highMove();
				Invoke("change", 0.1f);
			}
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			reset();
			GameData.textPlayerPos = this.gameObject.transform.position;
		}
	}
	void reset()
	{
		nowUp = false;
		nowDown = false;
		nowLeft = false;
		nowRight = false;
		NowCanMove = true;
		firstTime = true;
		highSpeed = false;
		enAble = false;
	}
	void delay()
	{
		if (!enAble)
		{
			enAble = true;
			highSpeed = true;
		}
	}
	void highMove()
	{
		last = this.gameObject.transform.position;
		this.gameObject.transform.position += move;
		high = false;
	}
	void change()
	{
		high = true;
	}
}