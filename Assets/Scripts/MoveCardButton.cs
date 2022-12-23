using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCardButton : MonoBehaviour
{

    public bool shouldMoveUp;

    public void OnMouseDown()
    {
        this.transform.parent.transform.parent.GetComponent<PlayingCard>().TryToMoveCard(shouldMoveUp);
    }


}
