using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdfeeder : MonoBehaviour
{
    //public List<FoodDice> availableFoodDice;
    //public List<FoodDice> usedFoodDice;

    public List<GameObject> availableFoodDiceLocations;
    public List<GameObject> usedFoodDiceLocations;

    public List<GameObject> availableFoodDice;
    public List<GameObject> usedFoodDice;

    public GameObject foodDiceParent;

    public GameObject foodDicePrefab;

    // Start is called before the first frame update
    void Start()
    {
        RollAllDice();
    }

    void ResetDice() {
        foreach (GameObject dice in availableFoodDice){
            Destroy(dice);
        }
        foreach (GameObject dice in usedFoodDice){
            Destroy(dice);
        }
        foreach (GameObject location in availableFoodDiceLocations) {
            location.GetComponent<FoodLocation>().isSpaceOccupied = true;
        }
        foreach (GameObject location in usedFoodDiceLocations) {
            location.GetComponent<FoodLocation>().isSpaceOccupied = false;
        }
        availableFoodDice = new List<GameObject>();
        usedFoodDice = new List<GameObject>();
    }

    void RollAllDice() {

        ResetDice();

        for (int i = 0; i < 5; i++) {
            GameObject foodDice = Instantiate(foodDicePrefab);
            foodDice.transform.parent = foodDiceParent.transform;
            GameObject foodLocation = availableFoodDiceLocations[i];
            foodDice.transform.position = foodLocation.transform.position;
            
            foodLocation.GetComponent<FoodLocation>().isSpaceOccupied = true;
            foodDice.GetComponent<FoodDice>().birdfeeder = this;
            foodDice.GetComponent<FoodDice>().foodLocation = foodLocation.GetComponent<FoodLocation>();
            availableFoodDice.Add(foodDice);
        }
    }

    void RollAllUsedDice() {
        foreach (GameObject foodDiceGO in usedFoodDice) {
            foodDiceGO.GetComponent<FoodDice>().RollDice();
        }
    }

    public void RerollButtonHit(bool isRollForAvailableFood) {
        if(isRollForAvailableFood) {
            RollAllDice();
        } else {
            RollAllUsedDice();
        }
    }

    private GameObject FindNewFoodLocation(List<GameObject> locationSet) {
        foreach (GameObject foodLocationGO in locationSet) {
            if(foodLocationGO.GetComponent<FoodLocation>().isSpaceOccupied == false) {
                return foodLocationGO;
            }
        }
        Debug.Log("No location found for food");
        return locationSet[0];
    }

    public void MoveFood(GameObject foodDiceGO) {
        FoodDice foodDice = foodDiceGO.GetComponent<FoodDice>();
        foodDice.foodLocation.isSpaceOccupied = false;

        GameObject newFoodLocationGO;

        if (foodDice.isAvailable) {
            newFoodLocationGO = FindNewFoodLocation(usedFoodDiceLocations);
            usedFoodDice.Add(foodDiceGO);
            availableFoodDice.Remove(foodDiceGO);
        } else {
            newFoodLocationGO = FindNewFoodLocation(availableFoodDiceLocations);
            usedFoodDice.Remove(foodDiceGO);
            availableFoodDice.Add(foodDiceGO);        
        }

        foodDiceGO.transform.position = newFoodLocationGO.transform.position;
        newFoodLocationGO.GetComponent<FoodLocation>().isSpaceOccupied = true; 
        foodDiceGO.GetComponent<FoodDice>().foodLocation = newFoodLocationGO.GetComponent<FoodLocation>();               
        foodDice.isAvailable = !foodDice.isAvailable;        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
