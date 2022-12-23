using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlaceholder : MonoBehaviour
{

    public GameObject playingCardPrefab;
    PlayerBoard playerBoard;
    PlayerBoardRow playerBoardRow;
    public GameObject rotatedCardCentre;
    
    // Start is called before the first frame update
    void Start()
    {
        playerBoardRow = this.transform.parent.GetComponent<PlayerBoardRow>();
        playerBoard = playerBoardRow.transform.parent.GetComponent<PlayerBoard>();

        if(playerBoard.playerNumber == 2)
        {
            rotatedCardCentre.transform.localPosition *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {

        // If there is a card highlighted, deselect it and don't create new
        if (playerBoard.isCardHighlighted)
        {
            playerBoard.BoardClicked();
            return;
        }

        //Don't create card if too far right
        if (playerBoardRow.cardLocations.IndexOf(this) != playerBoardRow.cardsInRow)
        {
            return;
        }

        //Don't create card if already has card child
        if(this.transform.childCount > 1)
        {
            return;
        }

        GameObject playingCardGO = Instantiate(playingCardPrefab);
        playerBoardRow.cardsInRow += 1;

        playerBoardRow.allCards.Add(playingCardGO);
        playingCardGO.transform.localRotation = Quaternion.Euler(this.transform.localRotation.eulerAngles);
        playingCardGO.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2);
        PlayingCard playingCard = playingCardGO.GetComponent<PlayingCard>();

        playingCard.playerBoard = playerBoard;
        playingCard.playerBoardRow = playerBoardRow;
        playingCard.indexOnRow = playerBoardRow.cardLocations.IndexOf(this);
        playingCard.transform.parent = this.transform;


    }
}
