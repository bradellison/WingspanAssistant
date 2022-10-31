using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsCog : MonoBehaviour
{
    CanvasManager canvasManager;
    // Start is called before the first frame update
    void Start()
    {

        canvasManager = GameObject.FindGameObjectWithTag("CanvasManager").GetComponent<CanvasManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        canvasManager.ToggleSettingsCanvas();
    }

}
