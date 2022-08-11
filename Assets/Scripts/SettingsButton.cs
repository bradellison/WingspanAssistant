using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{

    bool isSettingsOpen;
    public GameObject settingsCanvasPrefab;
    public GameObject settingsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if(!isSettingsOpen) {
            settingsCanvas = Instantiate(settingsCanvasPrefab);
        }
    }
}
