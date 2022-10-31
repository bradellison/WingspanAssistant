using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTop : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();

        //transform.localScale = Vector3(1,1,1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        //transform.localScale.x = worldScreenWidth / width;
        //transform.localScale.y = worldScreenHeight / height;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
