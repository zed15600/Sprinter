using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateToLandscape : MonoBehaviour {
    
    public Canvas canvas;
    CanvasScaler scaler;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable() {
        scaler = canvas.GetComponent<CanvasScaler>();
        scaler.referenceResolution = new Vector2(854, 480);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
