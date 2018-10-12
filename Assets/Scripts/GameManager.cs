using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    //TODO p175 方向切り替え時に各処理を消す


    //壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    //ボタン色
    public const int COLOR_GREEN = 0;
    public const int COLOR_RED = 1;
    public const int COLOR_BLUE = 2;
    public const int COLOR_WHITE = 3;

  

    public GameObject panelWalls;    //壁全体


    public GameObject buttonHammer; //ボタン:ハンマー
    public GameObject buttonKey; //ボタン:鍵


    public GameObject imageHammerIcon; //アイコン:ハンマー
    public GameObject imageKeyIcon; //アイコン:鍵


    public GameObject buttonPig; //ボタン:ブタの貯金箱　

    public GameObject buttonMessage; //ボタン:メッセージ
    public GameObject buttonMessageText;//メッセージテキスト

    public GameObject[] buttonLamp = new GameObject[3];//ボタン:金庫

    public Sprite[] buttonPicture = new Sprite[4]; //ボタンの絵

    public Sprite hammerPicture; //トンカチの絵
    public Sprite keyPicture; //鍵の絵


   
    private int wallNo;//現在向いている方向
    private bool doesHaveHammer; //ハンマーを持っているか
    private bool doesHaveKey; //鍵を持っているか
    private int[] buttonColor = new int[3];//金庫のボタン



    // Use this for initialization
    void Start () {
        wallNo = WALL_FRONT; //スタート時点では「前」をむく
        doesHaveHammer = false; //ハンマーは持ってない
        doesHaveKey = false; //鍵は持っていない

        buttonColor[0] = COLOR_GREEN; //ボタン1は「緑」
        buttonColor[1] = COLOR_RED;  //ボタン2は「赤」
        buttonColor[2] = COLOR_BLUE;//ボタン3は「青」



    }

    ///	// Update is called once per frame
    void Update () {
	}
    /// <summary>
    /// when pushed the memo,  call DisplayMessage.
    /// </summary>
    public void PushButtonMemo(){
        DisplayMessage("エッフェル塔と書いてある");
    }
    /// <summary>
    /// when pushed the message, hide it.
    /// </summary>
    public void PushButtonMessage(){
        buttonMessage.SetActive(false);
    }


    /// <summary>
    /// when push the button right, wallNo++ and call DisplayWall.
    /// </summary>
    public void PushButtonRight(){
        wallNo++;
        if(wallNo>WALL_LEFT){
            wallNo = WALL_FRONT;
        }
        DisplayWall();
    }

    /// <summary>
    /// when push the button left, wallNo-- and call DisplayWall.
    /// </summary>
    public void PushButtonLeft(){
        wallNo--;
        if(wallNo<WALL_FRONT){
            wallNo = WALL_LEFT;
        }
        DisplayWall();
    }


    /// <summary>
    /// Displaies the text message string.
    /// </summary>
    /// <param name="msg">Message.</param>
    void DisplayMessage(string msg){
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = msg;
    }


    /// <summary>
    /// changes the location of user view according to wallNo.
    /// </summary>
    void DisplayWall(){
        switch(wallNo){
            case WALL_FRONT://前
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT://前
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK://前
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEFT://前
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;
        }
    }

    /// <summary>
    /// when Pushs the button lamp1, then call ChangeButtonColor 0.
    /// </summary>
    //金庫のボタン1をタップ
    public void PushButtonLamp1()
    {
        ChangeButtonColor(0);
    }
    /// <summary>
    /// when Pushs the button lamp2, then call ChangeButtonColor 2.
    /// </summary>

    //金庫のボタン2をタップ
    public void PushButtonLamp2()
    {
        ChangeButtonColor(1);
    }
    /// <summary>
    /// when Pushs the button lamp3, then call ChangeButtonColor 3.
    /// </summary>
    public void PushButtonLamp3()
    {
        ChangeButtonColor(2);
    }


    //金庫のボタンの色を変更
    /// <summary>
    /// when button was pushed, then changes its color,
    /// if correct color set and not having hammer , get hammer.
    /// </summary>
    /// <param name="buttonNo">Button no.</param>
    void ChangeButtonColor (int buttonNo){
        buttonColor[buttonNo]++;
        //「白」の時にボタンを押したら「緑」に
        if(buttonColor[buttonNo]>COLOR_WHITE){
            buttonColor[buttonNo] = COLOR_GREEN;
        }

        //ボタンの画像を変更
        buttonLamp[buttonNo].GetComponent<Image>().sprite = buttonPicture[buttonColor[buttonNo]];
        //ボタンの色順をチェック
        if ((buttonColor[0] == COLOR_BLUE) && (buttonColor[1]==COLOR_WHITE)&&(buttonColor[2]==COLOR_RED)){
            //ハンマーを持っているかチェック
            if(!doesHaveHammer){
                DisplayMessage("金庫の中にハンマーが入っていた");
                buttonHammer.SetActive(true);//ハンマーの絵を表示
                imageHammerIcon.GetComponent<Image>().sprite = hammerPicture;

                doesHaveHammer = true;
            }
        }

    }

    /// <summary>
    /// when pushed buttonHammer, hide it.
    /// </summary>
    public void PushButtonHammer(){
        buttonHammer.SetActive(false);
    }
    /// <summary>
    /// when Pushs the buttonKey, hide it.
    /// </summary>
    public void PushButtonKey(){
        buttonKey.SetActive(false);
    }


    /// <summary>
    /// when pushed pig,
    /// if doesHaveHammer == false ,call DisplayMessage("cannot break")
    /// else if doesHaveHammer == true, call DisPlayMessage("broke and got key").
    /// </summary>
    public void PushButtonPig(){
        //ハンマーを持っているか
        if(!doesHaveHammer){
            //持ってない
            DisplayMessage("素手では割れない");
        }else{
            //持ってる
            DisplayMessage("貯金箱が割れて、中から鍵が出てきた");
            buttonPig.SetActive(false); //貯金箱を消す
            buttonKey.SetActive(true); //鍵の絵を表示
            imageKeyIcon.GetComponent<Image>().sprite = keyPicture;//鍵のアイコンを表示

            doesHaveKey = true;

        }
    }



}
