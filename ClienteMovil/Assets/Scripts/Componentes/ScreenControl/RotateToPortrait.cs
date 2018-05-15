using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateToPortrait : MonoBehaviour {
    
    public Canvas canvas;
    CanvasScaler scaler;

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable() {
        scaler = canvas.GetComponent<CanvasScaler>();
        scaler.referenceResolution = new Vector2(480, 854);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
        Screen.orientation = ScreenOrientation.Portrait;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
