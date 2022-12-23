using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoardImage : MonoBehaviour
{

    public PlayerBoard playerBoard;

    public void OnMouseDown()
    {
        print("board clicked");
        playerBoard.BoardClicked();   
    }

}
