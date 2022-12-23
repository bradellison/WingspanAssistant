using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Birdfeeder birdfeeder;
    public GameObject player1Food;
    public GameObject player2Food;
    public PlayerBoard player1Board;
    public PlayerBoard player2Board;
    public EndOfRoundGoals endOfRoundGoals;
    public ScoreSheetCanvas scoresheetCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RemoveFood(GameObject playerFood) {
        GameObject[] allFoodTypes = new GameObject[playerFood.transform.childCount];

        int i = 0;
        foreach (Transform child in playerFood.transform)
        {
            allFoodTypes[i] = child.gameObject;
            i += 1;
        }

        foreach(GameObject food in allFoodTypes) {
            food.GetComponent<HeldFood>().RemoveAllFood();
        }
    }

    public void ResetAll() {
        birdfeeder.RollAllDice();
        RemoveFood(player1Food);
        RemoveFood(player2Food);
        player1Board.DeleteAllCards();
        player2Board.DeleteAllCards();
        endOfRoundGoals.ResetGoals();
        scoresheetCanvas.ResetAll();
    }
}
