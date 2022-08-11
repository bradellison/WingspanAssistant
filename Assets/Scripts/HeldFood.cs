using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldFood : MonoBehaviour
{

    public GameObject heldFoodPrefab;
    public List<GameObject> heldFood;
    public GameObject addFoodButton;
    public GameObject heldFoodParent;

    public float foodSpacing;

    public bool isP1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RemoveFood() {
        Debug.Log("RemoveFood");
        GameObject removedFood = heldFood[heldFood.Count - 1];
        heldFood.Remove(removedFood);
        Destroy(removedFood);
    }

    public void AddFood() {
        Debug.Log("addfood");
        GameObject newFood = Instantiate(heldFoodPrefab);

        newFood.GetComponent<FoodIconInventory>().heldFood = this;
        newFood.transform.parent = heldFoodParent.transform;

        float space;
        if(isP1) {
            space = foodSpacing;
        } else {
            space = -foodSpacing;
        }

        Vector3 newLocation = new Vector3(transform.position.x - ((heldFood.Count + 0.2f) * space), transform.position.y, transform.position.z - (heldFood.Count * 0.1f));
        newFood.transform.position = newLocation;

        var rotation = newFood.transform.localRotation.eulerAngles;
        
        //Apply random rotation
        //rotation.Set(0f, 0f, Random.Range(0f,360f));

        //Apply player-specific rotation
        if(isP1) {
            rotation.Set(0f, 0f, 270f);
        } else {
            rotation.Set(0f, 0f, 90f);
        }

        newFood.transform.localRotation = Quaternion.Euler(rotation);

        heldFood.Add(newFood);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
