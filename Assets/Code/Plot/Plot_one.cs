using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_one : MonoBehaviour
{
	[Header("劇情")]
	public TextAsset dialogFile;
	public Text hint;

	[Header("UI物件")]
	public GameObject a1;  //睜
	public GameObject a2;  //開
	public GameObject a3;  //雙
	public GameObject a4;  //眼
	public GameObject a5;  //，
	public GameObject a6;  //是
	public GameObject a7;  //一
	public GameObject a8;  //望
	public GameObject a9;  //無
	public GameObject a10;  //際
	public GameObject a11;  //的
	public GameObject a12;  //天
	public GameObject a13;  //空
	public GameObject a14;  //。
	public GameObject a15;  //我
	public GameObject a16;  //慵
	public GameObject a17;  //懶
	public GameObject a18;  //從
	public GameObject a19;  //草
	public GameObject a20;  //皮
	public GameObject a21;  //上
	public GameObject a22;  //爬
	public GameObject a23;  //起
	public GameObject a24;  //身
	public GameObject a25;  //子
	public GameObject a26;  //這
	public GameObject a27;  //裡
	public GameObject a28;  //鈉
	public GameObject a29;  //秘
	public GameObject a30;  //斯
	public GameObject a31;  //村
	public GameObject a32;  //駐
	public GameObject a33;  //落
	public GameObject a34;  //於
	public GameObject a35;  //范
	public GameObject a36;  //特
	public GameObject a37;  //希
	public GameObject a38;  //境
	public GameObject a39;  //旁
	public GameObject a40;  //邊
	public GameObject a41;  //個
	public GameObject a42;  //莊
	public GameObject a43;  //今
	public GameObject a44;  //重
	public GameObject a45;  //要
	public GameObject a46;  //日
	public GameObject a47;  //十
	public GameObject a48;  //八
	public GameObject a49;  //歲
	public GameObject a50;  //生
	public GameObject a51;  //人
	public GameObject a52;  //只
	public GameObject a53;  //年
	public GameObject a54;  //滿
	public GameObject a55;  //就
	public GameObject a56;  //可
	public GameObject a57;  //以
	public GameObject a58;  //前
	public GameObject a59;  //往
	public GameObject a60;  //探
	public GameObject a61;  //險
	public GameObject a62;  //在
	public GameObject a63;  //大
	public GameObject a64;  //家
	public GameObject a65;  //不
	public GameObject a66;  //捨
	public GameObject a67;  //下
	public GameObject a68;  //告
	public GameObject a69;  //別
	public GameObject a70;  //里
	public GameObject a71;  //們
	public GameObject a72;  //邁
	public GameObject a73;  //步
	public GameObject a74;  //嚮
	public GameObject a75;  //已
	public GameObject a76;  //久
	public GameObject a77;  //神
	public GameObject a78;  //祕
	public GameObject a79;  //之
	public GameObject a80;  //地
	public GameObject a81;  //聽
	public GameObject a82;  //說
	public GameObject a83;  //中
	public GameObject a84;  //充
	public GameObject a85;  //了
	public GameObject a86;  //危
	public GameObject a87;  //魔
	public GameObject a88;  //物
	public GameObject a89;  //但
	public GameObject a90;  //機
	public GameObject a91;  //伴
	public GameObject a92;  //隨
	public GameObject a93;  //著
	public GameObject a94;  //緣
	public GameObject a95;  //也
	public GameObject a96;  //令
	public GameObject a97;  //垂
	public GameObject a98;  //涎
	public GameObject a99;  //寶
	public GameObject a100;  //藏
	public GameObject a101;  //與
	public GameObject a102;  //裝
	public GameObject a103;  //備
	public GameObject a104;  //正
	public GameObject a105;  //當
	public GameObject a106;  //幻
	public GameObject a107;  //想
	public GameObject a108;  //取
	public GameObject a109;  //得
	public GameObject a110;  //發
	public GameObject a111;  //致
	public GameObject a112;  //富
	public GameObject a113;  //時
	public GameObject a114;  //聲
	public GameObject a115;  //怒
	public GameObject a116;  //吼
	public GameObject a117;  //渾
	public GameObject a118;  //都
	public GameObject a119;  //由
	public GameObject a120;  //自
	public GameObject a121;  //主
	public GameObject a122;  //冒
	public GameObject a123;  //汗
	public GameObject a124;  //那
	public GameObject a125;  //音
	public GameObject a126;  //來
	public GameObject a127;  //獄
	public GameObject a128;  //咆
	public GameObject a129;  //嘯
	public GameObject a130;  //猶
	public GameObject a131;  //如
	public GameObject a132;  //響
	public GameObject a133;  //雷
	public GameObject a134;  //般
	public GameObject a135;  //驚
	public GameObject a136;  //動
	public GameObject a137;  //再
	public GameObject a138;  //次
	public GameObject a139;  //害
	public GameObject a140;  //怕
	public GameObject a141;  //全
	public GameObject a142;  //震
	public GameObject a143;  //嗯
	public GameObject a144;  //?
	public GameObject a145;  //腳
	public GameObject a146;  //好
	public GameObject a147;  //像
	public GameObject a148;  //踢
	public GameObject a149;  //到
	public GameObject a150;  //甚
	public GameObject a151;  //麼
	public GameObject a152;  //東
	public GameObject a153;  //西
	public GameObject a154;  //"
	public GameObject a155;  //你
	public GameObject a156;  //底
	public GameObject a157;  //睡
	public GameObject a158;  //候
	public GameObject a159;  //阿
	public GameObject a160;  //!
	public GameObject a161;  //夢
	public GameObject a162;  //醒
	public GameObject a163;  //看
	public GameObject a164;  //憤
	public GameObject a165;  //老
	public GameObject a166;  //師
	public GameObject a167;  //和
	public GameObject a168;  //臉
	public GameObject a169;  //猙
	public GameObject a170;  //獰
	public GameObject a171;  //手
	public GameObject a172;  //摀
	public GameObject a173;  //屁
	public GameObject a174;  //股
	public GameObject a175;  //座
	public GameObject a176;  //尷
	public GameObject a177;  //尬
	public GameObject a178;  //笑
	public GameObject a179;  //此
	public GameObject a180;  //課
	public GameObject a181;  //鐘
	public GameObject a182;  //奈
	public GameObject a183;  //回
	public GameObject a184;  //講
	public GameObject a185;  //桌

	float wordGap_X = 0.5f;				// X軸間隔
	float wordGap_Y = -2f;				// Y軸間隔
	float wordTick = 0.1f;             	// 字出現時間
	float wordTickNum = 0.1f;          	// 字延遲時間
	int queueCount = 0;                 // 物件佇列位置
	bool openDialog = true;             // 開啟對話
	int dialogCount = 0;                // 第幾個對話
	int endDialog;                      // 結束對話編號
	string pSpace = "/p";               // 按下空白鍵繼續
	bool pGoDown = true;                // 偵測到/p
	AsyncOperation async;				// 轉換場景
	Vector3 startPos = new Vector3(-6.5f, 3, 0);
	List<GameObject> showQueue = new List<GameObject>();    // 對話物件list
	List<string> dialogQueue = new List<string>();          // 對話文字list

	void Start()
	{
		GameData.openMeMove = false;
		GetDialogText(dialogFile);
		changewords();
		async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		async.allowSceneActivation = false;
	}

	void Update()
	{
		if(dialogCount + 1 == endDialog) GameData.openMeMove = true;
		if(Time.time >= wordTick && openDialog)
		{
			showdialog();
			wordTick = Time.time + wordTickNum;
		}
		else if(!openDialog && !pGoDown)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				hint.text = "";
				openDialog = true;
				pGoDown = true;
				var clones = GameObject.FindGameObjectsWithTag("clone");
				foreach (var clone in clones) Destroy(clone);

				if(dialogCount + 1 > endDialog) 
				{
					openDialog = false;
					wait();
					if(Input.GetKeyDown(KeyCode.Space)) async.allowSceneActivation = true;
					return;
				}
				else changewords();
			}
		}
	}

	void GetDialogText(TextAsset file)
	{
		dialogQueue.Clear();
		dialogCount = 0;
		var dialogText = file.text.Split('\n');
		foreach(var s in dialogText)
		{
			dialogQueue.Add(s);
		}
		endDialog = dialogQueue.Count;
	}

	void changewords()
	{
		char[] c = convertDialog(dialogQueue[dialogCount]);
		showQueue.Clear();
		foreach(char c1 in c)
		{
			switch(c1)
			{
				case '睜':
					showQueue.Add(a1);
					break;
				case '開':
					showQueue.Add(a2);
					break;
				case '雙':
					showQueue.Add(a3);
					break;
				case '眼':
					showQueue.Add(a4);
					break;
				case '，':
					showQueue.Add(a5);
					break;
				case '是':
					showQueue.Add(a6);
					break;
				case '一':
					showQueue.Add(a7);
					break;
				case '望':
					showQueue.Add(a8);
					break;
				case '無':
					showQueue.Add(a9);
					break;
				case '際':
					showQueue.Add(a10);
					break;
				case '的':
					showQueue.Add(a11);
					break;
				case '天':
					showQueue.Add(a12);
					break;
				case '空':
					showQueue.Add(a13);
					break;
				case '。':
					showQueue.Add(a14);
					break;
				case '我':
					showQueue.Add(a15);
					break;
				case '慵':
					showQueue.Add(a16);
					break;
				case '懶':
					showQueue.Add(a17);
					break;
				case '從':
					showQueue.Add(a18);
					break;
				case '草':
					showQueue.Add(a19);
					break;
				case '皮':
					showQueue.Add(a20);
					break;
				case '上':
					showQueue.Add(a21);
					break;
				case '爬':
					showQueue.Add(a22);
					break;
				case '起':
					showQueue.Add(a23);
					break;
				case '身':
					showQueue.Add(a24);
					break;
				case '子':
					showQueue.Add(a25);
					break;
				case '這':
					showQueue.Add(a26);
					break;
				case '裡':
					showQueue.Add(a27);
					break;
				case '鈉':
					showQueue.Add(a28);
					break;
				case '秘':
					showQueue.Add(a29);
					break;
				case '斯':
					showQueue.Add(a30);
					break;
				case '村':
					showQueue.Add(a31);
					break;
				case '駐':
					showQueue.Add(a32);
					break;
				case '落':
					showQueue.Add(a33);
					break;
				case '於':
					showQueue.Add(a34);
					break;
				case '范':
					showQueue.Add(a35);
					break;
				case '特':
					showQueue.Add(a36);
					break;
				case '希':
					showQueue.Add(a37);
					break;
				case '境':
					showQueue.Add(a38);
					break;
				case '旁':
					showQueue.Add(a39);
					break;
				case '邊':
					showQueue.Add(a40);
					break;
				case '個':
					showQueue.Add(a41);
					break;
				case '莊':
					showQueue.Add(a42);
					break;
				case '今':
					showQueue.Add(a43);
					break;
				case '重':
					showQueue.Add(a44);
					break;
				case '要':
					showQueue.Add(a45);
					break;
				case '日':
					showQueue.Add(a46);
					break;
				case '十':
					showQueue.Add(a47);
					break;
				case '八':
					showQueue.Add(a48);
					break;
				case '歲':
					showQueue.Add(a49);
					break;
				case '生':
					showQueue.Add(a50);
					break;
				case '人':
					showQueue.Add(a51);
					break;
				case '只':
					showQueue.Add(a52);
					break;
				case '年':
					showQueue.Add(a53);
					break;
				case '滿':
					showQueue.Add(a54);
					break;
				case '就':
					showQueue.Add(a55);
					break;
				case '可':
					showQueue.Add(a56);
					break;
				case '以':
					showQueue.Add(a57);
					break;
				case '前':
					showQueue.Add(a58);
					break;
				case '往':
					showQueue.Add(a59);
					break;
				case '探':
					showQueue.Add(a60);
					break;
				case '險':
					showQueue.Add(a61);
					break;
				case '在':
					showQueue.Add(a62);
					break;
				case '大':
					showQueue.Add(a63);
					break;
				case '家':
					showQueue.Add(a64);
					break;
				case '不':
					showQueue.Add(a65);
					break;
				case '捨':
					showQueue.Add(a66);
					break;
				case '下':
					showQueue.Add(a67);
					break;
				case '告':
					showQueue.Add(a68);
					break;
				case '別':
					showQueue.Add(a69);
					break;
				case '里':
					showQueue.Add(a70);
					break;
				case '們':
					showQueue.Add(a71);
					break;
				case '邁':
					showQueue.Add(a72);
					break;
				case '步':
					showQueue.Add(a73);
					break;
				case '嚮':
					showQueue.Add(a74);
					break;
				case '已':
					showQueue.Add(a75);
					break;
				case '久':
					showQueue.Add(a76);
					break;
				case '神':
					showQueue.Add(a77);
					break;
				case '祕':
					showQueue.Add(a78);
					break;
				case '之':
					showQueue.Add(a79);
					break;
				case '地':
					showQueue.Add(a80);
					break;
				case '聽':
					showQueue.Add(a81);
					break;
				case '說':
					showQueue.Add(a82);
					break;
				case '中':
					showQueue.Add(a83);
					break;
				case '充':
					showQueue.Add(a84);
					break;
				case '了':
					showQueue.Add(a85);
					break;
				case '危':
					showQueue.Add(a86);
					break;
				case '魔':
					showQueue.Add(a87);
					break;
				case '物':
					showQueue.Add(a88);
					break;
				case '但':
					showQueue.Add(a89);
					break;
				case '機':
					showQueue.Add(a90);
					break;
				case '伴':
					showQueue.Add(a91);
					break;
				case '隨':
					showQueue.Add(a92);
					break;
				case '著':
					showQueue.Add(a93);
					break;
				case '緣':
					showQueue.Add(a94);
					break;
				case '也':
					showQueue.Add(a95);
					break;
				case '令':
					showQueue.Add(a96);
					break;
				case '垂':
					showQueue.Add(a97);
					break;
				case '涎':
					showQueue.Add(a98);
					break;
				case '寶':
					showQueue.Add(a99);
					break;
				case '藏':
					showQueue.Add(a100);
					break;
				case '與':
					showQueue.Add(a101);
					break;
				case '裝':
					showQueue.Add(a102);
					break;
				case '備':
					showQueue.Add(a103);
					break;
				case '正':
					showQueue.Add(a104);
					break;
				case '當':
					showQueue.Add(a105);
					break;
				case '幻':
					showQueue.Add(a106);
					break;
				case '想':
					showQueue.Add(a107);
					break;
				case '取':
					showQueue.Add(a108);
					break;
				case '得':
					showQueue.Add(a109);
					break;
				case '發':
					showQueue.Add(a110);
					break;
				case '致':
					showQueue.Add(a111);
					break;
				case '富':
					showQueue.Add(a112);
					break;
				case '時':
					showQueue.Add(a113);
					break;
				case '聲':
					showQueue.Add(a114);
					break;
				case '怒':
					showQueue.Add(a115);
					break;
				case '吼':
					showQueue.Add(a116);
					break;
				case '渾':
					showQueue.Add(a117);
					break;
				case '都':
					showQueue.Add(a118);
					break;
				case '由':
					showQueue.Add(a119);
					break;
				case '自':
					showQueue.Add(a120);
					break;
				case '主':
					showQueue.Add(a121);
					break;
				case '冒':
					showQueue.Add(a122);
					break;
				case '汗':
					showQueue.Add(a123);
					break;
				case '那':
					showQueue.Add(a124);
					break;
				case '音':
					showQueue.Add(a125);
					break;
				case '來':
					showQueue.Add(a126);
					break;
				case '獄':
					showQueue.Add(a127);
					break;
				case '咆':
					showQueue.Add(a128);
					break;
				case '嘯':
					showQueue.Add(a129);
					break;
				case '猶':
					showQueue.Add(a130);
					break;
				case '如':
					showQueue.Add(a131);
					break;
				case '響':
					showQueue.Add(a132);
					break;
				case '雷':
					showQueue.Add(a133);
					break;
				case '般':
					showQueue.Add(a134);
					break;
				case '驚':
					showQueue.Add(a135);
					break;
				case '動':
					showQueue.Add(a136);
					break;
				case '再':
					showQueue.Add(a137);
					break;
				case '次':
					showQueue.Add(a138);
					break;
				case '害':
					showQueue.Add(a139);
					break;
				case '怕':
					showQueue.Add(a140);
					break;
				case '全':
					showQueue.Add(a141);
					break;
				case '震':
					showQueue.Add(a142);
					break;
				case '嗯':
					showQueue.Add(a143);
					break;
				case '?':
					showQueue.Add(a144);
					break;
				case '腳':
					showQueue.Add(a145);
					break;
				case '好':
					showQueue.Add(a146);
					break;
				case '像':
					showQueue.Add(a147);
					break;
				case '踢':
					showQueue.Add(a148);
					break;
				case '到':
					showQueue.Add(a149);
					break;
				case '甚':
					showQueue.Add(a150);
					break;
				case '麼':
					showQueue.Add(a151);
					break;
				case '東':
					showQueue.Add(a152);
					break;
				case '西':
					showQueue.Add(a153);
					break;
				case '"':
					showQueue.Add(a154);
					break;
				case '你':
					showQueue.Add(a155);
					break;
				case '底':
					showQueue.Add(a156);
					break;
				case '睡':
					showQueue.Add(a157);
					break;
				case '候':
					showQueue.Add(a158);
					break;
				case '阿':
					showQueue.Add(a159);
					break;
				case '!':
					showQueue.Add(a160);
					break;
				case '夢':
					showQueue.Add(a161);
					break;
				case '醒':
					showQueue.Add(a162);
					break;
				case '看':
					showQueue.Add(a163);
					break;
				case '憤':
					showQueue.Add(a164);
					break;
				case '老':
					showQueue.Add(a165);
					break;
				case '師':
					showQueue.Add(a166);
					break;
				case '和':
					showQueue.Add(a167);
					break;
				case '臉':
					showQueue.Add(a168);
					break;
				case '猙':
					showQueue.Add(a169);
					break;
				case '獰':
					showQueue.Add(a170);
					break;
				case '手':
					showQueue.Add(a171);
					break;
				case '摀':
					showQueue.Add(a172);
					break;
				case '屁':
					showQueue.Add(a173);
					break;
				case '股':
					showQueue.Add(a174);
					break;
				case '座':
					showQueue.Add(a175);
					break;
				case '尷':
					showQueue.Add(a176);
					break;
				case '尬':
					showQueue.Add(a177);
					break;
				case '笑':
					showQueue.Add(a178);
					break;
				case '此':
					showQueue.Add(a179);
					break;
				case '課':
					showQueue.Add(a180);
					break;
				case '鐘':
					showQueue.Add(a181);
					break;
				case '奈':
					showQueue.Add(a182);
					break;
				case '回':
					showQueue.Add(a183);
					break;
				case '講':
					showQueue.Add(a184);
					break;
				case '桌':
					showQueue.Add(a185);
					break;	
			}
		}
		queueCount = showQueue.Count;
	}
	
	char[] convertDialog(string s)
	{   
		if(s.Contains(pSpace)) 
		{
			pGoDown = false;
			s.Replace(pSpace,"");
		}
		char[] dialog_char = s.ToCharArray();
		dialogCount++;
		return dialog_char;
	}

	void showdialog()
	{
		if(openDialog)
		{
			GameObject clone = Instantiate(showQueue[showQueue.Count - queueCount], startPos, Quaternion.Euler(0, 0, 0));
			if(showQueue[showQueue.Count - queueCount] == a5) wordTickNum = 0.3f;
			else wordTickNum = 0.1f;
			clone.tag = "clone";
			startPos.x += wordGap_X;
			queueCount--;
		}
		if(queueCount == 0) 
		{
			if(!pGoDown) 
			{
				openDialog = false;
				startPos.y = 3f;
				startPos.x = -6.5f;
				wait();
			}
			else
			{
				openDialog = false;
				startPos.y += wordGap_Y;
				startPos.x = -6.5f;
				openDialog = true;
				changewords();
			}
		}
	}
	void wait()
	{
		hint.text = "按下Space繼續";
	}
}