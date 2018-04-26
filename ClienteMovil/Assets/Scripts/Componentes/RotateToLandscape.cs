using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToLandscape : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable() {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
