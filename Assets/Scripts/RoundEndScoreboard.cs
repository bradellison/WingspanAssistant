using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndScoreboard : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip paperCrumpleClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        audioSource.PlayOneShot(paperCrumpleClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyScoreboard() {
        audioSource.PlayOneShot(paperCrumpleClip);
        Destroy(this.gameObject);
    }

    private void OnMouseDown() {
        DestroyScoreboard();
    }

}
