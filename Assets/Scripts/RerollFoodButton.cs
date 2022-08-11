using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollFoodButton : MonoBehaviour
{

    public bool isAvailableReroll;
    Birdfeeder birdfeeder;

    void Start()
    {
        birdfeeder = this.transform.parent.GetComponent<Birdfeeder>();
    }

    private void OnMouseDown() {
        birdfeeder.RerollButtonHit(isAvailableReroll);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
