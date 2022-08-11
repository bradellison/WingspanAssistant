using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHeldFoodButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown() {
        this.gameObject.transform.parent.GetComponent<HeldFood>().AddFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
