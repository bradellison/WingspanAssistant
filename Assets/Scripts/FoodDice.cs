using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDice : MonoBehaviour
{
    public List<string> foodTypes;
    public List<Sprite> foodTypeImages;
    public FoodLocation foodLocation;
    public string currentType;
    public bool isAvailable;
    public Birdfeeder birdfeeder;

    // Start is called before the first frame update
    void Start()
    { 
        foodTypes.Add("Worm");
        foodTypes.Add("Worm/Wheat");
        foodTypes.Add("Wheat");
        foodTypes.Add("Fish");
        foodTypes.Add("Rat");
        foodTypes.Add("Cherry");
        isAvailable = true;
        RollDice();
    }

    public void RollDice() {
        int index = Random.Range(0,6);
        currentType = foodTypes[index];
        this.GetComponent<SpriteRenderer>().sprite = foodTypeImages[index];
    }

    private void OnMouseDown() {
        birdfeeder.MoveFood(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
