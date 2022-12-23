using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCollider : MonoBehaviour
{
    //Empty collider for stopping game action while scoresheet is open

    private void OnMouseDown()
    {
        print("Empty collider clicked");
    }
}
