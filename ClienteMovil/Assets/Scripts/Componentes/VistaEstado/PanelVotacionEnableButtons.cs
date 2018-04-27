using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVotacionEnableButtons : MonoBehaviour {
    
    public GameObject[] btns;

	// Use this for initialization
	void Start () {
		
	}

    void OnEnable() {
        for(int i = 0;i<btns.Length;i++) {
            btns[i].SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
