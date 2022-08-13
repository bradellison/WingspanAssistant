using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldFood : MonoBehaviour
{

    public GameObject heldFoodPrefab;
    public List<GameObject> heldFood;
    public GameObject addFoodButton;
    public GameObject heldFoodParent;
    
    AudioSource audioSource;
    public AudioClip getFoodClip;
    public AudioClip eatFoodClip;

    public float foodSpacing;

    public bool isP1;

    void Start() {
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
    }

    public void RemoveAllFood() {
        int totalFood = heldFood.Count;
        for (int i = 0; i < totalFood; i++) {
            RemoveFood(true);
        }
    }

    public void RemoveFood(bool isRemoveFromReset) {
        GameObject removedFood = heldFood[heldFood.Count - 1];
        heldFood.Remove(removedFood);
        if(!isRemoveFromReset) {
            audioSource.PlayOneShot(eatFoodClip);
        }
        Destroy(removedFood);
    }

    public void AddFood() {
        GameObject newFood = Instantiate(heldFoodPrefab);
        audioSource.PlayOneShot(getFoodClip);

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

}
