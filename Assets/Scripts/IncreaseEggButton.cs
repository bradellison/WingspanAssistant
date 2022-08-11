using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseEggButton : MonoBehaviour
{
    PlayingCard playingCard;
    void Start()
    {
        playingCard = this.transform.parent.GetComponent<PlayingCard>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown() {
        playingCard.IncreaseEggs();
    }
}
