using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayingCard : MonoBehaviour
{

    public List<Sprite> eggSprites;
    public List<GameObject> eggLocations;
    List<GameObject> usedEggLocations;
    public GameObject eggGO;
    public int currentEggCount;
    public List<GameObject> eggsInNest;
    int maxEggCount;

    public PlayerBoard playerBoard;
    public PlayerBoardRow playerBoardRow;
    public int indexOnRow;

    public GameObject optionsBar;
    public List<CachedFoodContainer> cachedFoodContainers;

    AudioSource audioSource;
    public AudioClip playCardClip;
    public AudioClip layEggClip;
    public AudioClip removeEggClip;
    public AudioClip deleteCardClip;
    public AudioClip incorrectClip;

    public bool isClicked;
    public int clickCount;

    public Vector3 originalPosition;
    public Vector3 rotatedPosition;
    public bool isCardRotated;

    public bool isBeingHeld;
    public bool justBeenReleased;
    private Vector3 heldScaleChange;

    IEnumerator HoldCard()
    {
        int clicksAtStart = clickCount;
        yield return new WaitForSeconds(0.5f);
        if (clickCount == clicksAtStart && isClicked)
        {
            if (isBeingHeld)
            {
                DeselectCard();
            }
            else
            {
                if (!playerBoard.isCardHighlighted)
                {
                    playerBoard.isCardHighlighted = true;
                    playerBoard.highlightedCard = this;
                    isBeingHeld = true;
                    optionsBar.SetActive(true);
                    this.transform.localScale += new Vector3(heldScaleChange.x, heldScaleChange.y, 0);
                    this.transform.localPosition += new Vector3(0, 0, -1);
                    foreach (CachedFoodContainer container in cachedFoodContainers)
                    {
                        container.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void DeselectCard() {
        isBeingHeld = false;
        optionsBar.SetActive(false);
        this.transform.localScale -= new Vector3(heldScaleChange.x, heldScaleChange.y, 0);
        this.transform.localPosition += new Vector3(0, 0, 1);
        justBeenReleased = true;
        playerBoard.isCardHighlighted = false;
        playerBoard.highlightedCard = null;
    
        foreach (CachedFoodContainer container in cachedFoodContainers)
        {
            if (container.cachedFoodCount == 0)
            {
                container.gameObject.SetActive(false);
            }
        }
    }
    
    public void TryToMoveCard(bool shouldMoveUp) {
    
        //Fail is card is not at end of row
        if (playerBoardRow.cardsInRow != indexOnRow + 1)
        {
            audioSource.PlayOneShot(incorrectClip);
            return;
        }
    
        // If at bottom moving down, or top moving up, fail
        if ((playerBoardRow.rowIndex == 0 && shouldMoveUp) || (playerBoardRow.rowIndex == 2 && !shouldMoveUp))
        {
            audioSource.PlayOneShot(incorrectClip);
            return;
        }
    
        // Fail if card is rotated
        if (isCardRotated)
        {
            audioSource.PlayOneShot(incorrectClip);
            return;
        }
    
        // Find row to move to
        int moveDirection = shouldMoveUp ? -1 : 1;
        PlayerBoardRow rowToMoveTo = playerBoard.allBoardRows[playerBoardRow.rowIndex + moveDirection];

        // Fail if new row has 5+ cards
        if (rowToMoveTo.cardsInRow >= 5)
        {
            audioSource.PlayOneShot(incorrectClip);
            return;
        }

        //Move card, update values
        playerBoardRow.cardsInRow--;
        rowToMoveTo.cardsInRow++;
        playerBoardRow = rowToMoveTo;

        indexOnRow = rowToMoveTo.cardsInRow - 1;

        Vector3 newVector = rowToMoveTo.cardLocations[indexOnRow].transform.position;
        transform.position = new Vector3(newVector.x, newVector.y, transform.position.z);
        transform.parent = rowToMoveTo.cardLocations[indexOnRow].transform;
        audioSource.PlayOneShot(playCardClip);
        DeselectCard();
    }

    public void TryToRotateCard()
    {
        //Fail is card is not at end of row
        int cardSize = isCardRotated ? 2 : 1;
        if (playerBoardRow.cardsInRow != indexOnRow + cardSize)
        {
            audioSource.PlayOneShot(incorrectClip);
            return;
        }

        //Fail if row is full
        if (playerBoardRow.cardsInRow == 5 && !isCardRotated)
        {
        audioSource.PlayOneShot(incorrectClip);
            return;
        }



        if (isCardRotated)
        {
            //Rotate card
            isCardRotated = false;
            int angle = playerBoard.playerNumber == 1 ? 270 : 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector3 newVector = this.transform.parent.position;
            transform.position = new Vector3(newVector.x, newVector.y, transform.position.z);
            playerBoardRow.cardsInRow--;
        }
        else
        {
            //Reset to normal
            isCardRotated = true;
            int angle = playerBoard.playerNumber == 1 ? 180 : 0;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector3 newVector = this.transform.parent.GetComponent<CardPlaceholder>().rotatedCardCentre.transform.position;
            transform.position = new Vector3(newVector.x, newVector.y, transform.position.z);
            playerBoardRow.cardsInRow++;
        }
        audioSource.PlayOneShot(playCardClip);
        DeselectCard();
    }

    public void DeleteCard()
    {
        int cardSize = isCardRotated ? 2 : 1;
        if (playerBoardRow.cardsInRow != indexOnRow + cardSize)
        {
            audioSource.PlayOneShot(incorrectClip);
            return;
        }

        audioSource.PlayOneShot(deleteCardClip);
        playerBoardRow.cardsInRow -= cardSize;
        playerBoardRow.allCards.Remove(this.gameObject);

        playerBoard.isCardHighlighted = false;
        playerBoard.highlightedCard = null;
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentEggCount = 0;
        Vector3 originalScale = this.transform.localScale;
        heldScaleChange = originalScale / 2.7f;
        optionsBar.SetActive(false);
        isCardRotated = false;

        maxEggCount = eggLocations.Count;
        usedEggLocations = new List<GameObject>();
        eggsInNest = new List<GameObject>();
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        audioSource.PlayOneShot(playCardClip);
    }

    public void IncreaseEggs() {
        if (isBeingHeld || justBeenReleased)
        {
            justBeenReleased = false;
            return;
        }
        if (currentEggCount < maxEggCount) {
            for (int i = 0; i < 100; i++) {
                int locIndex = Random.Range(0, eggLocations.Count);
                GameObject newLocation = eggLocations[locIndex];
                if (!usedEggLocations.Contains(newLocation)) {
                    currentEggCount += 1;
                    GameObject egg = Instantiate(eggGO);
                    egg.transform.parent = newLocation.transform;
                    egg.transform.position = newLocation.transform.position;
                    egg.transform.localRotation = Quaternion.Euler(newLocation.transform.localRotation.eulerAngles);
                    int eggIndex = Random.Range(0, eggSprites.Count);
                    egg.GetComponent<SpriteRenderer>().sprite = eggSprites[eggIndex];
                    eggsInNest.Add(egg);
                    usedEggLocations.Add(newLocation);
                    audioSource.PlayOneShot(layEggClip);
                    return;
                }
            }
        }
    }

    public void DecreaseEggs() {
        if (isBeingHeld || justBeenReleased)
        {
            justBeenReleased = false;
            return;
        }
        if (currentEggCount > 0) {
            int eggIndex = Random.Range(0, eggsInNest.Count);
            GameObject eggToRemove = eggsInNest[eggIndex];
            GameObject locationToRemove = usedEggLocations[eggIndex];

            usedEggLocations.Remove(locationToRemove);
            eggsInNest.Remove(eggToRemove);
            Destroy(eggToRemove);
            audioSource.PlayOneShot(removeEggClip);
            currentEggCount -= 1;
        }
    }

    public void CheckHold() {
        StartCoroutine(HoldCard());
    }
}

