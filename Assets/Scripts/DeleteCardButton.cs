using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCardButton : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        this.transform.parent.transform.parent.GetComponent<PlayingCard>().DeleteCard();
    }
}
