using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    
    public Button quitGameButton;
    public Button resetBoardButton;
    public Button resumeGameButton;

    CanvasManager canvasManager;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        canvasManager = GameObject.FindGameObjectWithTag("CanvasManager").GetComponent<CanvasManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        quitGameButton.onClick.AddListener(QuitGame);
        resetBoardButton.onClick.AddListener(ResetBoard);
        resumeGameButton.onClick.AddListener(ResumeGame);
    }

    void QuitGame() {
        Application.Quit();
    }

    void ResetBoard() {
        gameManager.ResetAll();
    }

    void ResumeGame() {
        canvasManager.ToggleSettingsCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
