using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoard : MonoBehaviour
{

    //public List<GameObject> allCards;
    public List<PlayerBoardRow> allBoardRows;
    public int playerNumber;
    public bool isCardHighlighted;
    public PlayingCard highlightedCard;

    public void DeleteAllCards() {
        foreach(PlayerBoardRow row in allBoardRows) {
            row.DeleteAllCards();
        }
        isCardHighlighted = false;
        highlightedCard = null;
    }

    public void BoardClicked()
    {
        if(!highlightedCard)
        {
            return;
        }

        highlightedCard.DeselectCard();
    }
}
