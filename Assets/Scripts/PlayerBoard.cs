using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoard : MonoBehaviour
{

    public List<GameObject> allCards;

    public void DeleteAllCards() {
        foreach(GameObject card in allCards) {
            Destroy(card);
        }
    }
}
