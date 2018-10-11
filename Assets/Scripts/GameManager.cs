using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    //壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    //オブジェクト壁全体
    public GameObject panelWalls;


    public GameObject buttonMessage; //ボタン:メッセージ
    public GameObject buttonMessageText;//メッセージテキスト

    private int wallNo;
    // Use this for initialization
    void Start () {
        wallNo = WALL_FRONT;
		
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
}
