using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CachedDirectionButton : MonoBehaviour
{

    public Sprite increaseSprite;
    public Sprite decreaseSprite;
    public bool isIncrease;

    private SpriteRenderer _sr;

    void Start()
    {
        isIncrease = true;
        _sr = this.gameObject.GetComponent<SpriteRenderer>();
        _sr.sprite = increaseSprite;
    }

    public void OnMouseDown()
    {
        isIncrease = !isIncrease;
        Sprite newSprite = isIncrease ? increaseSprite : decreaseSprite;
        _sr.sprite = newSprite;
    }
}
