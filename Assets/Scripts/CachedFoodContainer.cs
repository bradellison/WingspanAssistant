using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CachedFoodContainer : MonoBehaviour
{

    public int cachedFoodCount = 0;
    public TextMeshPro foodCountText;
    public CachedDirectionButton cachedDirectionButton;

    void Start()
    {
        gameObject.SetActive(false);
        UpdateText();
    }

    void UpdateText()
    {
        foodCountText.text = cachedFoodCount.ToString();
    }

    public void OnMouseDown()
    {
        if(cachedDirectionButton.isIncrease)
        {
            cachedFoodCount++;
        } else
        {
            cachedFoodCount = cachedFoodCount > 0 ? cachedFoodCount -= 1 : 0;
        }
        
        UpdateText();
    }
}
