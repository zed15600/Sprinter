using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVotacionEnableButtons : MonoBehaviour {
    
    public GameObject[] btns;

    void OnEnable() {
        for(int i = 0;i<btns.Length;i++) {
            btns[i].SetActive(true);
        }
    }
}
