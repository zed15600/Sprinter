﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Votar : ClientElement {

    public Text txt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void enviarVoto() {
        app.controlador.enviarVoto(txt.text);
        app.vista.estado.ocultarVotacion();
    }
}