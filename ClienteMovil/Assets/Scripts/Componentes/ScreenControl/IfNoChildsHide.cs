using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfNoChildsHide : MonoBehaviour {
    
	void Update () {
        bool childs = false;
		foreach(Transform child in this.transform) {
            childs |= child.gameObject.activeInHierarchy;
        }
        if(!childs) {
            this.gameObject.SetActive(false);
        }
	}
}
