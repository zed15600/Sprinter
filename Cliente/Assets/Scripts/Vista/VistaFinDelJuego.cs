using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaFinDelJuego : ClientElement {

    public Text resultado;
    public Color verde;
    public Color rojo;

	// Use this for initialization
	void Start () {
        if(revisarHistorias()) {
            resultado.text = "¡Victoria!";
            resultado.color = verde;
        } else {
            resultado.text = "Derrota";
            resultado.color = rojo;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool revisarHistorias() {
        List<HistoriaDeUsuario> historias = app.controlador.obtenerHistorias();
        bool res = true;
        for (int i=0; i<historias.Count;i++) {
            if(!historias[i].getEstado()) {
                res = false;
                break;
            }
        }
        return res;
    }
}
