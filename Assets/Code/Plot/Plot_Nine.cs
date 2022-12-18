using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plot_Nine : MonoBehaviour
{
	[Header("劇情")]
	public TextAsset dialogFile;
	public Text hint;
	
	[Header("UI物件")]
	public GameObject a1;  //考
	public GameObject a2;  //完
	public GameObject a3;  //試
	public GameObject a4;  //了
	public GameObject a5;  //，
	public GameObject a6;  //唉
	public GameObject a7;  //總
	public GameObject a8;  //感
	public GameObject a9;  //覺
	public GameObject a10;  //好
	public GameObject a11;  //空
	public GameObject a12;  //虛
	public GameObject a13;  //啊
	public GameObject a14;  //~
	public GameObject a15;  //一
	public GameObject a16;  //整
	public GameObject a17;  //天
	public GameObject a18;  //的
	public GameObject a19;  //勞
	public GameObject a20;  //累
	public GameObject a21;  //就
	public GameObject a22;  //此
	public GameObject a23;  //結
	public GameObject a24;  //束
	public GameObject a25;  //早
	public GameObject a26;  //上
	public GameObject a27;  //經
	public GameObject a28;  //過
	public GameObject a29;  //共
	public GameObject a30;  //同
	public GameObject a31;  //科
	public GameObject a32;  //目
	public GameObject a33;  //洗
	public GameObject a34;  //禮
	public GameObject a35;  //下
	public GameObject a36;  //午
	public GameObject a37;  //又
	public GameObject a38;  //塞
	public GameObject a39;  //滿
	public GameObject a40;  //專
	public GameObject a41;  //與
	public GameObject a42;  //實
	public GameObject a43;  //習
	public GameObject a44;  //$
	public GameObject a45;  //全
	public GameObject a46;  //身
	public GameObject a47;  //被
	public GameObject a48;  //疲
	public GameObject a49;  //憊
	public GameObject a50;  //佔
	public GameObject a51;  //據
	public GameObject a52;  //。
	public GameObject a53;  //當
	public GameObject a54;  //學
	public GameObject a55;  //生
	public GameObject a56;  //!
	public GameObject a57;  //真
	public GameObject a58;  //想
	public GameObject a59;  //和
	public GameObject a60;  //那
	public GameObject a61;  //些
	public GameObject a62;  //小
	public GameObject a63;  //說
	public GameObject a64;  //樣
	public GameObject a65;  //處
	public GameObject a66;  //在
	public GameObject a67;  //個
	public GameObject a68;  //自
	public GameObject a69;  //由
	public GameObject a70;  //世
	public GameObject a71;  //界
	public GameObject a72;  //我
	public GameObject a73;  //邊
	public GameObject a74;  //如
	public GameObject a75;  //者
	public GameObject a76;  //跟
	public GameObject a77;  //大
	public GameObject a78;  //家
	public GameObject a79;  //回
	public GameObject a80;  //到
	public GameObject a81;  //教
	public GameObject a82;  //室
	public GameObject a83;  //收
	public GameObject a84;  //拾
	public GameObject a85;  //書
	public GameObject a86;  //包
	public GameObject a87;  //告
	public GameObject a88;  //別
	public GameObject a89;  //離
	public GameObject a90;  //開
	public GameObject a91;  //校
	public GameObject a92;  //搭
	public GameObject a93;  //火
	public GameObject a94;  //車
	public GameObject a95;  //獨
	public GameObject a96;  //時
	public GameObject a97;  //段
	public GameObject a98;  //腦
	public GameObject a99;  //子
	public GameObject a100;  //還
	public GameObject a101;  //是
	public GameObject a102;  //著
	public GameObject a103;  //基
	public GameObject a104;  //電
	public GameObject a105;  //課
	public GameObject a106;  //美
	public GameObject a107;  //夢
	public GameObject a108;  //場
	public GameObject a109;  //景
	public GameObject a110;  //這
	public GameObject a111;  //突
	public GameObject a112;  //然
	public GameObject a113;  //產
	public GameObject a114;  //法
	public GameObject a115;  //做
	public GameObject a116;  //得
	public GameObject a117;  //出
	public GameObject a118;  //來
	public GameObject a119;  //嗎
	public GameObject a120;  //?
	public GameObject a121;  //站
	public GameObject a122;  //從
	public GameObject a123;  //往
	public GameObject a124;  //方
	public GameObject a125;  //向
	public GameObject a126;  //散
	public GameObject a127;  //步
	public GameObject a128;  //今
	public GameObject a129;  //太
	public GameObject a130;  //陽
	public GameObject a131;  //不
	public GameObject a132;  //微
	public GameObject a133;  //風
	public GameObject a134;  //徐
	public GameObject a135;  //很
	public GameObject a136;  //清
	public GameObject a137;  //澈
	public GameObject a138;  //晚
	public GameObject a139;  //點
	public GameObject a140;  //言
	public GameObject a141;  //語
	public GameObject a142;  //停
	public GameObject a143;  //公
	public GameObject a144;  //園
	public GameObject a145;  //入
	public GameObject a146;  //口
	public GameObject a147;  //管
	public GameObject a148;  //附
	public GameObject a149;  //近
	public GameObject a150;  //老
	public GameObject a151;  //人
	public GameObject a152;  //孩
	public GameObject a153;  //眼
	public GameObject a154;  //光
	public GameObject a155;  //剌
	public GameObject a156;  //躺
	public GameObject a157;  //冰
	public GameObject a158;  //涼
	public GameObject a159;  //石
	public GameObject a160;  //製
	public GameObject a161;  //滑
	public GameObject a162;  //梯
	public GameObject a163;  //右
	public GameObject a164;  //手
	public GameObject a165;  //抓
	public GameObject a166;  //依
	public GameObject a167;  //舊
	public GameObject a168;  //藍
	public GameObject a169;  //像
	public GameObject a170;  //話
	public GameObject a171;  //需
	public GameObject a172;  //要
	public GameObject a173;  //多
	public GameObject a174;  //容
	public GameObject a175;  //量
	public GameObject a176;  //G
	public GameObject a177;  //L
	public GameObject a178;  //S
	public GameObject a179;  //I
	public GameObject a180;  //夠
	public GameObject a181;  //現
	public GameObject a182;  //技
	public GameObject a183;  //遠
	public GameObject a184;  //用
	public GameObject a185;  //有
	public GameObject a186;  //膽
	public GameObject a187;  //逐
	public GameObject a188;  //漸
	public GameObject a189;  //浮
	public GameObject a190;  //水
	public GameObject a191;  //面
	public GameObject a192;  //.
	public GameObject a193;  //屬
	public GameObject a194;  //於
	public GameObject a195;  //己
	public GameObject a196;  //擬
	public GameObject a197;  //跳
	public GameObject a198;  //起
	public GameObject a199;  //旁
	public GameObject a200;  //看
	public GameObject a201;  //弟
	public GameObject a202;  //嚇
	public GameObject a203;  //跌
	public GameObject a204;  //倒
	public GameObject a205;  //踩
	public GameObject a206;  //股
	public GameObject a207;  //激
	public GameObject a208;  //動
	public GameObject a209;  //心
	public GameObject a210;  //情
	public GameObject a211;  //未
	public GameObject a212;  //曾
	public GameObject a213;  //彷
	public GameObject a214;  //彿
	public GameObject a215;  //沒
	public GameObject a216;  //綁
	public GameObject a217;  //安
	public GameObject a218;  //帶
	public GameObject a219;  //怒
	public GameObject a220;  //神
	public GameObject a221;  //失
	public GameObject a222;  //重
	public GameObject a223;  //後
	public GameObject a224;  //飛
	public GameObject a225;  //翱
	public GameObject a226;  //翔
	public GameObject a227;  //繼
	public GameObject a228;  //續
	public GameObject a229;  //留
	public GameObject a230;  //盡
	public GameObject a231;  //所
	public GameObject a232;  //色
	public GameObject a233;  //片
	public GameObject a234;  //只
	public GameObject a235;  //簡
	public GameObject a236;  //單
	public GameObject a237;  //解
	public GameObject a238;  //決
	public GameObject a239;  //餐
	public GameObject a240;  //並
	public GameObject a241;  //梳
	public GameObject a242;  //已
	public GameObject a243;  //黑
	public GameObject a244;  //訊
	public GameObject a245;  //息
	public GameObject a246;  //明
	public GameObject a247;  //四
	public GameObject a248;  //千
	public GameObject a249;  //五
	public GameObject a250;  //百
	public GameObject a251;  //原
	public GameObject a252;  //本
	public GameObject a253;  //都
	public GameObject a254;  //會
	public GameObject a255;  //拿
	public GameObject a256;  //背
	public GameObject a257;  //字
	public GameObject a258;  //但
	public GameObject a259;  //算
	public GameObject a260;  //吧
	public GameObject a261;  //也
	public GameObject a262;  //許
	public GameObject a263;  //因
	public GameObject a264;  //為
	public GameObject a265;  //溢
	public GameObject a266;  //程
	public GameObject a267;  //或
	public GameObject a268;  //馬
	public GameObject a269;  //行
	public GameObject a270;  //周
	public GameObject a271;  //旋
	public GameObject a272;  //特
	public GameObject a273;  //睡
	public GameObject a274;  //床
	public GameObject a275;  //窗
	public GameObject a276;  //戶
	public GameObject a277;  //閉
	public GameObject a278;  //雙
	public GameObject a279;  //熟
	public GameObject a280;  //悉
	public GameObject a281;  //聲
	public GameObject a282;  //音
	public GameObject a283;  //響
	public GameObject a284;  //裡
	public GameObject a285;  //鈉
	public GameObject a286;  //秘
	public GameObject a287;  //斯
	public GameObject a288;  //村
	public GameObject a289;  //"
	
	
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
				case '考':
					showQueue.Add(a1);
					break;
				case '完':
					showQueue.Add(a2);
					break;
				case '試':
					showQueue.Add(a3);
					break;
				case '了':
					showQueue.Add(a4);
					break;
				case '，':
					showQueue.Add(a5);
					break;
				case '唉':
					showQueue.Add(a6);
					break;
				case '總':
					showQueue.Add(a7);
					break;
				case '感':
					showQueue.Add(a8);
					break;
				case '覺':
					showQueue.Add(a9);
					break;
				case '好':
					showQueue.Add(a10);
					break;
				case '空':
					showQueue.Add(a11);
					break;
				case '虛':
					showQueue.Add(a12);
					break;
				case '啊':
					showQueue.Add(a13);
					break;
				case '~':
					showQueue.Add(a14);
					break;
				case '一':
					showQueue.Add(a15);
					break;
				case '整':
					showQueue.Add(a16);
					break;
				case '天':
					showQueue.Add(a17);
					break;
				case '的':
					showQueue.Add(a18);
					break;
				case '勞':
					showQueue.Add(a19);
					break;
				case '累':
					showQueue.Add(a20);
					break;
				case '就':
					showQueue.Add(a21);
					break;
				case '此':
					showQueue.Add(a22);
					break;
				case '結':
					showQueue.Add(a23);
					break;
				case '束':
					showQueue.Add(a24);
					break;
				case '早':
					showQueue.Add(a25);
					break;
				case '上':
					showQueue.Add(a26);
					break;
				case '經':
					showQueue.Add(a27);
					break;
				case '過':
					showQueue.Add(a28);
					break;
				case '共':
					showQueue.Add(a29);
					break;
				case '同':
					showQueue.Add(a30);
					break;
				case '科':
					showQueue.Add(a31);
					break;
				case '目':
					showQueue.Add(a32);
					break;
				case '洗':
					showQueue.Add(a33);
					break;
				case '禮':
					showQueue.Add(a34);
					break;
				case '下':
					showQueue.Add(a35);
					break;
				case '午':
					showQueue.Add(a36);
					break;
				case '又':
					showQueue.Add(a37);
					break;
				case '塞':
					showQueue.Add(a38);
					break;
				case '滿':
					showQueue.Add(a39);
					break;
				case '專':
					showQueue.Add(a40);
					break;
				case '與':
					showQueue.Add(a41);
					break;
				case '實':
					showQueue.Add(a42);
					break;
				case '習':
					showQueue.Add(a43);
					break;
				case '$':
					showQueue.Add(a44);
					break;
				case '全':
					showQueue.Add(a45);
					break;
				case '身':
					showQueue.Add(a46);
					break;
				case '被':
					showQueue.Add(a47);
					break;
				case '疲':
					showQueue.Add(a48);
					break;
				case '憊':
					showQueue.Add(a49);
					break;
				case '佔':
					showQueue.Add(a50);
					break;
				case '據':
					showQueue.Add(a51);
					break;
				case '。':
					showQueue.Add(a52);
					break;
				case '當':
					showQueue.Add(a53);
					break;
				case '學':
					showQueue.Add(a54);
					break;
				case '生':
					showQueue.Add(a55);
					break;
				case '!':
					showQueue.Add(a56);
					break;
				case '真':
					showQueue.Add(a57);
					break;
				case '想':
					showQueue.Add(a58);
					break;
				case '和':
					showQueue.Add(a59);
					break;
				case '那':
					showQueue.Add(a60);
					break;
				case '些':
					showQueue.Add(a61);
					break;
				case '小':
					showQueue.Add(a62);
					break;
				case '說':
					showQueue.Add(a63);
					break;
				case '樣':
					showQueue.Add(a64);
					break;
				case '處':
					showQueue.Add(a65);
					break;
				case '在':
					showQueue.Add(a66);
					break;
				case '個':
					showQueue.Add(a67);
					break;
				case '自':
					showQueue.Add(a68);
					break;
				case '由':
					showQueue.Add(a69);
					break;
				case '世':
					showQueue.Add(a70);
					break;
				case '界':
					showQueue.Add(a71);
					break;
				case '我':
					showQueue.Add(a72);
					break;
				case '邊':
					showQueue.Add(a73);
					break;
				case '如':
					showQueue.Add(a74);
					break;
				case '者':
					showQueue.Add(a75);
					break;
				case '跟':
					showQueue.Add(a76);
					break;
				case '大':
					showQueue.Add(a77);
					break;
				case '家':
					showQueue.Add(a78);
					break;
				case '回':
					showQueue.Add(a79);
					break;
				case '到':
					showQueue.Add(a80);
					break;
				case '教':
					showQueue.Add(a81);
					break;
				case '室':
					showQueue.Add(a82);
					break;
				case '收':
					showQueue.Add(a83);
					break;
				case '拾':
					showQueue.Add(a84);
					break;
				case '書':
					showQueue.Add(a85);
					break;
				case '包':
					showQueue.Add(a86);
					break;
				case '告':
					showQueue.Add(a87);
					break;
				case '別':
					showQueue.Add(a88);
					break;
				case '離':
					showQueue.Add(a89);
					break;
				case '開':
					showQueue.Add(a90);
					break;
				case '校':
					showQueue.Add(a91);
					break;
				case '搭':
					showQueue.Add(a92);
					break;
				case '火':
					showQueue.Add(a93);
					break;
				case '車':
					showQueue.Add(a94);
					break;
				case '獨':
					showQueue.Add(a95);
					break;
				case '時':
					showQueue.Add(a96);
					break;
				case '段':
					showQueue.Add(a97);
					break;
				case '腦':
					showQueue.Add(a98);
					break;
				case '子':
					showQueue.Add(a99);
					break;
				case '還':
					showQueue.Add(a100);
					break;
				case '是':
					showQueue.Add(a101);
					break;
				case '著':
					showQueue.Add(a102);
					break;
				case '基':
					showQueue.Add(a103);
					break;
				case '電':
					showQueue.Add(a104);
					break;
				case '課':
					showQueue.Add(a105);
					break;
				case '美':
					showQueue.Add(a106);
					break;
				case '夢':
					showQueue.Add(a107);
					break;
				case '場':
					showQueue.Add(a108);
					break;
				case '景':
					showQueue.Add(a109);
					break;
				case '這':
					showQueue.Add(a110);
					break;
				case '突':
					showQueue.Add(a111);
					break;
				case '然':
					showQueue.Add(a112);
					break;
				case '產':
					showQueue.Add(a113);
					break;
				case '法':
					showQueue.Add(a114);
					break;
				case '做':
					showQueue.Add(a115);
					break;
				case '得':
					showQueue.Add(a116);
					break;
				case '出':
					showQueue.Add(a117);
					break;
				case '來':
					showQueue.Add(a118);
					break;
				case '嗎':
					showQueue.Add(a119);
					break;
				case '?':
					showQueue.Add(a120);
					break;
				case '站':
					showQueue.Add(a121);
					break;
				case '從':
					showQueue.Add(a122);
					break;
				case '往':
					showQueue.Add(a123);
					break;
				case '方':
					showQueue.Add(a124);
					break;
				case '向':
					showQueue.Add(a125);
					break;
				case '散':
					showQueue.Add(a126);
					break;
				case '步':
					showQueue.Add(a127);
					break;
				case '今':
					showQueue.Add(a128);
					break;
				case '太':
					showQueue.Add(a129);
					break;
				case '陽':
					showQueue.Add(a130);
					break;
				case '不':
					showQueue.Add(a131);
					break;
				case '微':
					showQueue.Add(a132);
					break;
				case '風':
					showQueue.Add(a133);
					break;
				case '徐':
					showQueue.Add(a134);
					break;
				case '很':
					showQueue.Add(a135);
					break;
				case '清':
					showQueue.Add(a136);
					break;
				case '澈':
					showQueue.Add(a137);
					break;
				case '晚':
					showQueue.Add(a138);
					break;
				case '點':
					showQueue.Add(a139);
					break;
				case '言':
					showQueue.Add(a140);
					break;
				case '語':
					showQueue.Add(a141);
					break;
				case '停':
					showQueue.Add(a142);
					break;
				case '公':
					showQueue.Add(a143);
					break;
				case '園':
					showQueue.Add(a144);
					break;
				case '入':
					showQueue.Add(a145);
					break;
				case '口':
					showQueue.Add(a146);
					break;
				case '管':
					showQueue.Add(a147);
					break;
				case '附':
					showQueue.Add(a148);
					break;
				case '近':
					showQueue.Add(a149);
					break;
				case '老':
					showQueue.Add(a150);
					break;
				case '人':
					showQueue.Add(a151);
					break;
				case '孩':
					showQueue.Add(a152);
					break;
				case '眼':
					showQueue.Add(a153);
					break;
				case '光':
					showQueue.Add(a154);
					break;
				case '剌':
					showQueue.Add(a155);
					break;
				case '躺':
					showQueue.Add(a156);
					break;
				case '冰':
					showQueue.Add(a157);
					break;
				case '涼':
					showQueue.Add(a158);
					break;
				case '石':
					showQueue.Add(a159);
					break;
				case '製':
					showQueue.Add(a160);
					break;
				case '滑':
					showQueue.Add(a161);
					break;
				case '梯':
					showQueue.Add(a162);
					break;
				case '右':
					showQueue.Add(a163);
					break;
				case '手':
					showQueue.Add(a164);
					break;
				case '抓':
					showQueue.Add(a165);
					break;
				case '依':
					showQueue.Add(a166);
					break;
				case '舊':
					showQueue.Add(a167);
					break;
				case '藍':
					showQueue.Add(a168);
					break;
				case '像':
					showQueue.Add(a169);
					break;
				case '話':
					showQueue.Add(a170);
					break;
				case '需':
					showQueue.Add(a171);
					break;
				case '要':
					showQueue.Add(a172);
					break;
				case '多':
					showQueue.Add(a173);
					break;
				case '容':
					showQueue.Add(a174);
					break;
				case '量':
					showQueue.Add(a175);
					break;
				case 'G':
					showQueue.Add(a176);
					break;
				case 'L':
					showQueue.Add(a177);
					break;
				case 'S':
					showQueue.Add(a178);
					break;
				case 'I':
					showQueue.Add(a179);
					break;
				case '夠':
					showQueue.Add(a180);
					break;
				case '現':
					showQueue.Add(a181);
					break;
				case '技':
					showQueue.Add(a182);
					break;
				case '遠':
					showQueue.Add(a183);
					break;
				case '用':
					showQueue.Add(a184);
					break;
				case '有':
					showQueue.Add(a185);
					break;
				case '膽':
					showQueue.Add(a186);
					break;
				case '逐':
					showQueue.Add(a187);
					break;
				case '漸':
					showQueue.Add(a188);
					break;
				case '浮':
					showQueue.Add(a189);
					break;
				case '水':
					showQueue.Add(a190);
					break;
				case '面':
					showQueue.Add(a191);
					break;
				case '.':
					showQueue.Add(a192);
					break;
				case '屬':
					showQueue.Add(a193);
					break;
				case '於':
					showQueue.Add(a194);
					break;
				case '己':
					showQueue.Add(a195);
					break;
				case '擬':
					showQueue.Add(a196);
					break;
				case '跳':
					showQueue.Add(a197);
					break;
				case '起':
					showQueue.Add(a198);
					break;
				case '旁':
					showQueue.Add(a199);
					break;
				case '看':
					showQueue.Add(a200);
					break;
				case '弟':
					showQueue.Add(a201);
					break;
				case '嚇':
					showQueue.Add(a202);
					break;
				case '跌':
					showQueue.Add(a203);
					break;
				case '倒':
					showQueue.Add(a204);
					break;
				case '踩':
					showQueue.Add(a205);
					break;
				case '股':
					showQueue.Add(a206);
					break;
				case '激':
					showQueue.Add(a207);
					break;
				case '動':
					showQueue.Add(a208);
					break;
				case '心':
					showQueue.Add(a209);
					break;
				case '情':
					showQueue.Add(a210);
					break;
				case '未':
					showQueue.Add(a211);
					break;
				case '曾':
					showQueue.Add(a212);
					break;
				case '彷':
					showQueue.Add(a213);
					break;
				case '彿':
					showQueue.Add(a214);
					break;
				case '沒':
					showQueue.Add(a215);
					break;
				case '綁':
					showQueue.Add(a216);
					break;
				case '安':
					showQueue.Add(a217);
					break;
				case '帶':
					showQueue.Add(a218);
					break;
				case '怒':
					showQueue.Add(a219);
					break;
				case '神':
					showQueue.Add(a220);
					break;
				case '失':
					showQueue.Add(a221);
					break;
				case '重':
					showQueue.Add(a222);
					break;
				case '後':
					showQueue.Add(a223);
					break;
				case '飛':
					showQueue.Add(a224);
					break;
				case '翱':
					showQueue.Add(a225);
					break;
				case '翔':
					showQueue.Add(a226);
					break;
				case '繼':
					showQueue.Add(a227);
					break;
				case '續':
					showQueue.Add(a228);
					break;
				case '留':
					showQueue.Add(a229);
					break;
				case '盡':
					showQueue.Add(a230);
					break;
				case '所':
					showQueue.Add(a231);
					break;
				case '色':
					showQueue.Add(a232);
					break;
				case '片':
					showQueue.Add(a233);
					break;
				case '只':
					showQueue.Add(a234);
					break;
				case '簡':
					showQueue.Add(a235);
					break;
				case '單':
					showQueue.Add(a236);
					break;
				case '解':
					showQueue.Add(a237);
					break;
				case '決':
					showQueue.Add(a238);
					break;
				case '餐':
					showQueue.Add(a239);
					break;
				case '並':
					showQueue.Add(a240);
					break;
				case '梳':
					showQueue.Add(a241);
					break;
				case '已':
					showQueue.Add(a242);
					break;
				case '黑':
					showQueue.Add(a243);
					break;
				case '訊':
					showQueue.Add(a244);
					break;
				case '息':
					showQueue.Add(a245);
					break;
				case '明':
					showQueue.Add(a246);
					break;
				case '四':
					showQueue.Add(a247);
					break;
				case '千':
					showQueue.Add(a248);
					break;
				case '五':
					showQueue.Add(a249);
					break;
				case '百':
					showQueue.Add(a250);
					break;
				case '原':
					showQueue.Add(a251);
					break;
				case '本':
					showQueue.Add(a252);
					break;
				case '都':
					showQueue.Add(a253);
					break;
				case '會':
					showQueue.Add(a254);
					break;
				case '拿':
					showQueue.Add(a255);
					break;
				case '背':
					showQueue.Add(a256);
					break;
				case '字':
					showQueue.Add(a257);
					break;
				case '但':
					showQueue.Add(a258);
					break;
				case '算':
					showQueue.Add(a259);
					break;
				case '吧':
					showQueue.Add(a260);
					break;
				case '也':
					showQueue.Add(a261);
					break;
				case '許':
					showQueue.Add(a262);
					break;
				case '因':
					showQueue.Add(a263);
					break;
				case '為':
					showQueue.Add(a264);
					break;
				case '溢':
					showQueue.Add(a265);
					break;
				case '程':
					showQueue.Add(a266);
					break;
				case '或':
					showQueue.Add(a267);
					break;
				case '馬':
					showQueue.Add(a268);
					break;
				case '行':
					showQueue.Add(a269);
					break;
				case '周':
					showQueue.Add(a270);
					break;
				case '旋':
					showQueue.Add(a271);
					break;
				case '特':
					showQueue.Add(a272);
					break;
				case '睡':
					showQueue.Add(a273);
					break;
				case '床':
					showQueue.Add(a274);
					break;
				case '窗':
					showQueue.Add(a275);
					break;
				case '戶':
					showQueue.Add(a276);
					break;
				case '閉':
					showQueue.Add(a277);
					break;
				case '雙':
					showQueue.Add(a278);
					break;
				case '熟':
					showQueue.Add(a279);
					break;
				case '悉':
					showQueue.Add(a280);
					break;
				case '聲':
					showQueue.Add(a281);
					break;
				case '音':
					showQueue.Add(a282);
					break;
				case '響':
					showQueue.Add(a283);
					break;
				case '裡':
					showQueue.Add(a284);
					break;
				case '鈉':
					showQueue.Add(a285);
					break;
				case '秘':
					showQueue.Add(a286);
					break;
				case '斯':
					showQueue.Add(a287);
					break;
				case '村':
					showQueue.Add(a288);
					break;
				case '"':
					showQueue.Add(a289);
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
			else if(showQueue[showQueue.Count - queueCount] == a44) wordTickNum = 1f;
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