using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingCard : MonoBehaviour
{

    public List<Sprite> eggSprites;
    public List<GameObject> eggLocations;
    List<GameObject> usedEggLocations;
    public GameObject eggGO;
    public int currentEggCount;
    public List<GameObject> eggsInNest;
    int maxEggCount;

    AudioSource audioSource;
    public AudioClip playCardClip;
    public AudioClip layEggClip;
    public AudioClip removeEggClip;
    public AudioClip deleteCardClip;


    public bool isClicked;
    public int clickCount;

    IEnumerator RemoveCard() {
        int clicksAtStart = clickCount;
        yield return new WaitForSeconds(1f);
        if(clickCount == clicksAtStart && isClicked) {
            audioSource.PlayOneShot(deleteCardClip);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentEggCount = 0;
        maxEggCount = eggLocations.Count;
        usedEggLocations = new List<GameObject>();
        eggsInNest = new List<GameObject>();
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        audioSource.PlayOneShot(playCardClip);
    }

    public void IncreaseEggs() {
        CheckDelete();
        if(currentEggCount < maxEggCount) {
            for (int i = 0; i < 100; i++) {
                int locIndex = Random.Range(0, eggLocations.Count);
                GameObject newLocation = eggLocations[locIndex];
                if(!usedEggLocations.Contains(newLocation)) {
                    currentEggCount += 1;
                    GameObject egg = Instantiate(eggGO);
                    egg.transform.parent = newLocation.transform;
                    egg.transform.position = newLocation.transform.position;
                    egg.transform.localRotation = Quaternion.Euler(newLocation.transform.localRotation.eulerAngles);
                    int eggIndex = Random.Range(0, eggSprites.Count);
                    egg.GetComponent<SpriteRenderer>().sprite = eggSprites[eggIndex];
                    eggsInNest.Add(egg);
                    usedEggLocations.Add(newLocation);
                    audioSource.PlayOneShot(layEggClip);
                    return;
                }
            }
        }
    }

    public void DecreaseEggs() {
        CheckDelete();
        if(currentEggCount > 0) {
            int eggIndex = Random.Range(0, eggsInNest.Count);
            GameObject eggToRemove = eggsInNest[eggIndex];
            GameObject locationToRemove = usedEggLocations[eggIndex];

            usedEggLocations.Remove(locationToRemove);
            eggsInNest.Remove(eggToRemove);
            Destroy(eggToRemove);
            audioSource.PlayOneShot(removeEggClip);
            currentEggCount -= 1;
        }    
    }

    void CheckDelete() {
        StartCoroutine(RemoveCard());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
