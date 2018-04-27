using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPortrait : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable() {
        Screen.orientation = ScreenOrientation.Portrait;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
