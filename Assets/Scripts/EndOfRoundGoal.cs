using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRoundGoal : MonoBehaviour
{

    public List<Color> playerColors;
    public GameObject winningTokenLocation;
    public GameObject winningTokenPrefab;
    int clicks;

    GameObject winningToken;

    void Start()
    {
        clicks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if(clicks == 0) {
            winningToken = Instantiate(winningTokenPrefab);
            winningToken.transform.parent = transform;
            winningToken.transform.position = new Vector3(winningTokenLocation.transform.position.x, winningTokenLocation.transform.position.y, winningTokenLocation.transform.position.z + 1);
            winningToken.GetComponent<SpriteRenderer>().color = playerColors[0];
            clicks++;
        } else if(clicks == 1) {
            winningToken.GetComponent<SpriteRenderer>().color = playerColors[1];
            clicks++;            
        } else if(clicks == 2) {
            Destroy(winningToken);
            clicks = 0;
        }
    }

}
