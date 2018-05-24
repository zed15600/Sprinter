using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaEncuesta : ClientElement {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void enviarRespuesta(string opcion) {
        controlador.enviarRespuesta(opcion);
    }
}
