using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRoundGoal : MonoBehaviour
{

    public List<Color> playerColors;
    public GameObject winningTokenLocation;
    public GameObject winningTokenPrefab;
    int clicks;
    int clickCount;
    bool isClicked;
    public EndOfRoundGoals endOfRoundGoals;

    GameObject winningToken;

    AudioSource audioSource;
    public AudioClip playGoalClip;
    public AudioClip clickGoalClip;
    
    public GameObject roundEndScoreboard;
    bool scoreboardChanged;

    void Start()
    {
        clicks = 0;
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        audioSource.PlayOneShot(playGoalClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckOpenGoals() {
        int clicksAtStart = clickCount;
        yield return new WaitForSeconds(1f);
        if(clicksAtStart == clickCount && isClicked) {
            //endOfRoundGoals.currentGoals.Remove(this.gameObject);
            //Destroy(this.gameObject);
            GameObject existingRoundEndScoreboard = GameObject.FindGameObjectWithTag("EndOfRoundScoreboard");
            if(existingRoundEndScoreboard == null) {
                Instantiate(roundEndScoreboard);
                scoreboardChanged = true;
            } else {
                existingRoundEndScoreboard.GetComponent<RoundEndScoreboard>().DestroyScoreboard();
                scoreboardChanged = true;
            }
        }
    }

    private void OnMouseUp() {
        isClicked = false;
        if(!scoreboardChanged) {
            if(clicks == 0) {
                winningToken = Instantiate(winningTokenPrefab);
                winningToken.transform.parent = transform;
                winningToken.transform.position = new Vector3(winningTokenLocation.transform.position.x, winningTokenLocation.transform.position.y, winningTokenLocation.transform.position.z + 1);
                winningToken.GetComponent<SpriteRenderer>().color = playerColors[0];
                audioSource.PlayOneShot(clickGoalClip);
                clicks++;
            } else if(clicks == 1) {
                winningToken.GetComponent<SpriteRenderer>().color = playerColors[1];
                audioSource.PlayOneShot(clickGoalClip);
                clicks++;            
            } else if(clicks == 2) {
                Destroy(winningToken);
                clicks = 0;
            }
        }
        scoreboardChanged = false;
    }

    private void OnMouseDown() {
        isClicked = true;
        clickCount++;
        StartCoroutine(CheckOpenGoals());
    }

}
