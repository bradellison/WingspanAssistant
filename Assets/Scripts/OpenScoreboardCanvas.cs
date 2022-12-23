using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScoreboardCanvas : MonoBehaviour
{

    public GameObject scoreboard;

    public void OnMouseDown()
    {
        scoreboard.SetActive(true);
    }

}
