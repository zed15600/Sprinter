using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoBoton : MonoBehaviour {
    
    public AudioSource clip;

    public void playAudio() {
        clip.Play();
    }
}
