using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //TODO p166 色と順番を確認してフランス国旗と同じだったらトンカチの絵を表示する


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

    /// <summary>
    /// オブジェクト
    /// </summary>
    public GameObject panelWalls;    //壁全体


    public GameObject buttonHammer; //ボタン:ハンマー

    public GameObject imageHammerIcon; //アイコン:ハンマー



    public GameObject buttonMessage; //ボタン:メッセージ
    public GameObject buttonMessageText;//メッセージテキスト

    public GameObject[] buttonLamp = new GameObject[3];//ボタン:金庫

    public Sprite[] buttonPicture = new Sprite[4]; //ボタンの絵

    public Sprite hammerPicture; //トンカチの絵


    /// <summary>
    /// フラグたち
    /// </summary>
    private int wallNo;//現在向いている方向
    private bool doesHaveHammer; //ハンマーを持っているか
    private int[] buttonColor = new int[3];//金庫のボタン



    // Use this for initialization
    void Start () {
        wallNo = WALL_FRONT; //スタート時点では「前」をむく
        doesHaveHammer = false; //ハンマーは持ってない

        buttonColor[0] = COLOR_GREEN; //ボタン1は「緑」
        buttonColor[1] = COLOR_RED;  //ボタン2は「赤」
        buttonColor[2] = COLOR_BLUE;//ボタン3は「青」



    }

    ///	// Update is called once per frame
    void Update () {
	}
    /// <summary>
    /// Pushs the button memo.
    /// </summary>
    public void PushButtonMemo(){
        DisplayMessage("エッフェル塔と書いてある");
    }
    /// <summary>
    /// Pushs the button message.
    /// </summary>
    public void PushButtonMessage(){
        buttonMessage.SetActive(false);
    }


    /// <summary>
    /// Pushs the button right.
    /// </summary>
    public void PushButtonRight(){
        wallNo++;
        if(wallNo>WALL_LEFT){
            wallNo = WALL_FRONT;
        }
        DisplayWall();
    }

    /// <summary>
    /// Pushs the button left.
    /// </summary>
    public void PushButtonLeft(){
        wallNo--;
        if(wallNo<WALL_FRONT){
            wallNo = WALL_LEFT;
        }
        DisplayWall();
    }


    /// <summary>
    /// Displaies the message.
    /// </summary>
    /// <param name="msg">Message.</param>
    void DisplayMessage(string msg){
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = msg;
    }


    /// <summary>
    /// Displays the wall.
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
    /// 以下のボタンタップメソッドは一本化しても良いように思えるが、
    /// onclickイベントとして関連づけるために、各個のメソッドを用意した方が都合が良い
    /// </summary>

    //金庫のボタン1をタップ
    public void PushButtonLamp1()
    {
        ChangeButtonColor(0);
    }
    //金庫のボタン2をタップ
    public void PushButtonLamp2()
    {
        ChangeButtonColor(1);
    }
    //金庫のボタン2をタップ
    public void PushButtonLamp3()
    {
        ChangeButtonColor(2);
    }


    //金庫のボタンの色を変更
    void ChangeButtonColor (int buttonNo){
        buttonColor[buttonNo]++;
        //「白」の時にボタンを押したら「緑」に
        if(buttonColor[buttonNo]>COLOR_WHITE){
            buttonColor[buttonNo] = COLOR_GREEN;
        }

        //ボタンの画像を変更
        buttonLamp[buttonNo].GetComponent<Image>().sprite = buttonPicture[buttonColor[buttonNo]];
    }
}
