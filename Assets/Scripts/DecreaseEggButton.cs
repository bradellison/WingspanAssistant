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
        playingCard.isClicked = true;
        playingCard.clickCount += 1;
        playingCard.DecreaseEggs();
    }

    private void OnMouseUp() {
        playingCard.isClicked = false;
    }

}
