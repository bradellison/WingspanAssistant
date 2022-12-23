using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRoundGoals : MonoBehaviour
{

    public List<GameObject> endOfRoundLocations;
    public List<Sprite> endOfRoundOptions;
    public GameObject endOfRoundGoalPrefab;
    public List<Sprite> chosenGoals;
    public List<GameObject> currentGoals;

    public List<EndOfRoundGoal> endOfRoundGoals;

    public void ResetGoals() {
        foreach(GameObject goal in currentGoals) {
            Destroy(goal);
        }
        currentGoals = new List<GameObject>();

        //foreach (Sprite goal in chosenGoals)
        //{
        //    Destroy(goal);
        //}
        chosenGoals = new List<Sprite>();

        foreach(EndOfRoundGoal goal in endOfRoundGoals)
        {
            Destroy(goal);
        }
        endOfRoundGoals = new List<EndOfRoundGoal>();
       
    }

}
