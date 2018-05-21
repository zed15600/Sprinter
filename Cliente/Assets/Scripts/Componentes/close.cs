using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour {

    public void cerrar() {
        if (UnityEditor.EditorApplication.isPlaying) {
            UnityEditor.EditorApplication.isPlaying = false;
        } else {
            Application.Quit();
        }

    }
}
