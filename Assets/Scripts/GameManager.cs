using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    public GameObject panelWalls;

    private int wallNo;
    // Use this for initialization
    void Start () {
        wallNo = WALL_FRONT;
		
	}
	
	// Update is called once per frame
	void Update () {
	}


    /*
     * 右ボタンを押した
     */
    public void PushButtonRight(){
        wallNo++;
        if(wallNo>WALL_LEFT){
            wallNo = WALL_FRONT;
        }
        DisplayWall();
    }

    /*
     * 左ボタンを押した
    */
    public void PushButtonLeft(){
        wallNo--;
        if(wallNo<WALL_FRONT){
            wallNo = WALL_LEFT;
        }
        DisplayWall();
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
