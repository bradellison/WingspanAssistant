using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCardButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        this.transform.parent.transform.parent.GetComponent<PlayingCard>().TryToRotateCard();
    }
}
