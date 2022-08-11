using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlaceholder : MonoBehaviour
{

    public GameObject playingCardGO;
    public DeleteCardEnabler deleteCardEnabler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        GameObject playingCard = Instantiate(playingCardGO);
        playingCard.GetComponent<PlayingCard>().deleteCardEnabler = deleteCardEnabler;

        playingCard.transform.localRotation = Quaternion.Euler(this.transform.localRotation.eulerAngles);
        playingCard.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2);
        playingCard.transform.parent = this.transform;
    }
}
