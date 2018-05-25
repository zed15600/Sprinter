using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVotacionEnableButtons : MonoBehaviour {
    
    public GameObject[] btns;
    public GameObject VLG;

    void OnEnable() {
        for(int i = 0;i<btns.Length;i++) {
            btns[i].SetActive(true);
        }
        VLG.SetActive(true);
    }
}
