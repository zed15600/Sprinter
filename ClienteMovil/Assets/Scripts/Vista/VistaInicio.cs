using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaInicio : ClientElement {
	
	// Update is called once per frame
	void Update () {
		
	}

    public void iniciarPartida() {
        this.gameObject.SetActive(false);
        controlador.mostrarVistaConectarse();
    }

    public void abrirConfiguracion() {
        controlador.mostrarVistaConfiguracion();
    }
}
