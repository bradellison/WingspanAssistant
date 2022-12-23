using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreCalculator : MonoBehaviour
{

    public ScoreSheetCanvas scoreSheetCanvas;
    public PlayerBoard playerBoard;
    public EndOfRoundGoals endOfRoundGoals;

    private GameManager gameManager;
    public int playerNumber;

    public TextMeshProUGUI birdPointsText;
    public Slider birdPointsSlider;

    public TextMeshProUGUI bonusPointsText;
    public Slider bonusPointsSlider;

    public TextMeshProUGUI endOfRoundsPointsText;
    int endOfRoundPoints;

    public TextMeshProUGUI eggsPointsText;
    int eggPoints;

    public TextMeshProUGUI cachedPointsText;
    int cachedPoints;

    public TextMeshProUGUI tuckedPointsText;
    public Slider tuckedPointsSlider;

    public TextMeshProUGUI totalPointsText;

    private void OnEnable()
    {
        UpdateTextFields();
        UpdateTotal();
        RemoveTextCollision();
        birdPointsSlider.onValueChanged.AddListener(delegate { UpdateSliderField(birdPointsSlider, birdPointsText); });
        bonusPointsSlider.onValueChanged.AddListener(delegate { UpdateSliderField(bonusPointsSlider, bonusPointsText); });
        tuckedPointsSlider.onValueChanged.AddListener(delegate { UpdateSliderField(tuckedPointsSlider, tuckedPointsText); });
    }

    void RemoveTextCollision()
    {
        birdPointsText.raycastTarget = false;
        bonusPointsText.raycastTarget = false;
        tuckedPointsText.raycastTarget = false;
    }


    private void OnDisable()
    {
        birdPointsSlider.onValueChanged.RemoveListener(delegate { UpdateSliderField(birdPointsSlider, birdPointsText); });
        bonusPointsSlider.onValueChanged.RemoveListener(delegate { UpdateSliderField(bonusPointsSlider, bonusPointsText); });
        tuckedPointsSlider.onValueChanged.RemoveListener(delegate { UpdateSliderField(tuckedPointsSlider, tuckedPointsText); });
    }

    public void ResetAll()
    {
        eggPoints = 0;
        eggsPointsText.text = "0";

        cachedPoints = 0;
        cachedPointsText.text = "0";

        endOfRoundPoints = 0;
        endOfRoundsPointsText.text = "0";

        birdPointsSlider.value = 0;
        birdPointsText.text = "0";

        bonusPointsSlider.value = 0;
        bonusPointsText.text = "0";

        tuckedPointsSlider.value = 0;
        tuckedPointsText.text = "0";

        UpdateTotal();
    }

    public int CalculateEggCount()
    {
        int total = 0;

        foreach (PlayerBoardRow row in playerBoard.allBoardRows)
        {
            foreach(GameObject card in row.allCards)
            {
                total += card.GetComponent<PlayingCard>().currentEggCount;
            }
        }

        return total;
    }

    public int CalculateCacheCount()
    {
        int total = 0;
        foreach (PlayerBoardRow row in playerBoard.allBoardRows)
        {
            foreach (GameObject card in row.allCards)
            {
                PlayingCard playingCard = card.GetComponent<PlayingCard>();
                foreach(CachedFoodContainer container in playingCard.cachedFoodContainers)
                {
                    total += container.cachedFoodCount;
                }
            }
        }

        return total;
    }

    public int CalculateEndOfRoundTotal()
    {

        int total = 0;
        int roundNumber = 1;
        foreach (EndOfRoundGoal goal in endOfRoundGoals.endOfRoundGoals)
        {
            if (goal.clicks == 0 || goal.clicks == playerNumber)
            {
                total += 3;
            }
            total += roundNumber;
            roundNumber++;
        }
        return total;
    }

    public void UpdateTextFields()
    {
        eggPoints = CalculateEggCount();
        eggsPointsText.text = eggPoints.ToString();

        cachedPoints = CalculateCacheCount();
        cachedPointsText.text = cachedPoints.ToString();

        endOfRoundPoints = CalculateEndOfRoundTotal();
        endOfRoundsPointsText.text = endOfRoundPoints.ToString();
    }

    public void UpdateSliderField(Slider slider, TextMeshProUGUI textField)
    {
        textField.text = slider.value.ToString();

        if(slider.value == slider.maxValue)
        {
            slider.maxValue += 1;
        }

        UpdateTotal();
    }

    public void UpdateTotal()
    {
        float total = 0;
        total += eggPoints + cachedPoints + endOfRoundPoints;
        total += birdPointsSlider.value + bonusPointsSlider.value + tuckedPointsSlider.value;

        totalPointsText.text = total.ToString();
    }

}
