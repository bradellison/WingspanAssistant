using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoardRow : MonoBehaviour
{

    public List<GameObject> allCards;
    public int rowIndex;
    public List<CardPlaceholder> cardLocations;
    public int cardsInRow;

    private void Start()
    {
        cardsInRow = 0;
        //foreach(GameObject child in transform.)
        for(int i = 0; i < 5; i++)
        {
            cardLocations.Add(transform.GetChild(i).GetComponent<CardPlaceholder>());
        }
    }

    public void DeleteAllCards()
    {
        foreach (GameObject card in allCards)
        {
            Destroy(card);
        }
        cardsInRow = 0;
        allCards = new List<GameObject>();
    }
}
