using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRoundPlaceholder : MonoBehaviour
{
    
    EndOfRoundGoals endOfRoundGoals;

    void Start()
    {
        endOfRoundGoals = GameObject.FindGameObjectWithTag("EndOfRound").GetComponent<EndOfRoundGoals>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if(endOfRoundGoals.endOfRoundOptions.Count > endOfRoundGoals.chosenGoals.Count) {
            for (int i = 0; i < 100; i++) {
                int index = Random.Range(0, endOfRoundGoals.endOfRoundOptions.Count);
                Sprite newSprite = endOfRoundGoals.endOfRoundOptions[index];
                if(!endOfRoundGoals.chosenGoals.Contains(newSprite)) {
                    GameObject goal = Instantiate(endOfRoundGoals.endOfRoundGoalPrefab);
                    goal.transform.parent = this.transform;
                    goal.GetComponent<SpriteRenderer>().sprite = newSprite;
                    goal.GetComponent<EndOfRoundGoal>().endOfRoundGoals = endOfRoundGoals;
                    goal.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
                    endOfRoundGoals.chosenGoals.Add(newSprite);
                    endOfRoundGoals.currentGoals.Add(goal);
                    return;
                }
            }
        } 
        Debug.Log("No more goals to choose from.");
    }
}
