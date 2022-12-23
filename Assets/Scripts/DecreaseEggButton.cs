using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseEggButton : MonoBehaviour
{

    PlayingCard playingCard;
    // Start is called before the first frame update
    void Start()
    {
        playingCard = this.transform.parent.GetComponent<PlayingCard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {

        if (playingCard.playerBoard.isCardHighlighted)
        {
            playingCard.playerBoard.BoardClicked();
            return;
        }

        playingCard.isClicked = true;
        playingCard.CheckHold();
    }

    private void OnMouseUp() {
        if (!playingCard.isClicked)
        {
            return;
        }

        playingCard.isClicked = false;
        playingCard.clickCount += 1;
        playingCard.DecreaseEggs();
    }

}
