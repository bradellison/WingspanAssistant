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

    public void ResetGoals() {
        foreach(GameObject goal in currentGoals) {
            Destroy(goal);
        }
    }

}
