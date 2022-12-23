using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSheetCanvas : MonoBehaviour
{

    public Sprite openEye;
    public Sprite closedEye;
    public Button showTotalTrigger;
    public bool showTotals;

    public GameObject player1Total;
    public GameObject player2Total;

    public PlayerScoreCalculator p1ScoreCalculator;
    public PlayerScoreCalculator p2ScoreCalculator;

    public void ResetAll()
    {
        p1ScoreCalculator.ResetAll();
        p2ScoreCalculator.ResetAll();
    }

    private void OnEnable()
    {
        showTotalTrigger.onClick.AddListener(ToggleTotalVisible);
    }

    private void OnDisable()
    {
        showTotalTrigger.onClick.RemoveListener(ToggleTotalVisible);
    }

    private void Start()
    {
        showTotals = false;
        player1Total.SetActive(false);
        player2Total.SetActive(false);
    }

    public void CloseScoresheet()
    {
        this.gameObject.SetActive(false);
    }

    void ToggleTotalVisible()
    {

        showTotals = !showTotals;
        Sprite newSprite = showTotals ? openEye : closedEye;
        showTotalTrigger.transform.GetComponent<Image>().sprite = newSprite;
        player1Total.SetActive(showTotals);
        player2Total.SetActive(showTotals);
    }

}
