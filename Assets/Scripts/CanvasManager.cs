using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    public GameObject settingsCanvasPrefab;
    GameObject settingsCanvas;
    bool isSettingsOpen;

    void Start() {
        isSettingsOpen = false;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            ToggleSettingsCanvas();
        }
    }

    public void ToggleSettingsCanvas() {
        if(!isSettingsOpen) {
            settingsCanvas = Instantiate(settingsCanvasPrefab);
            isSettingsOpen = true;
        } else {
            Destroy(settingsCanvas);
            isSettingsOpen = false;
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ResetBoard() {
        Debug.Log("Reset");
    }
}
