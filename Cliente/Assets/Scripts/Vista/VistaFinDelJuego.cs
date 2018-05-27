using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaFinDelJuego : ClientElement, IVista {

    Idioma idioma;
    public Text titulo;
    public Text resultado;
    public Color verde;
    public Color rojo;

    public Text descripcion;
    private string victoria, derrota;
    public Button continuar;

	// Use this for initialization
	void OnEnable () {
        inicializarVista();
        if(revisarHistorias()) {
            resultado.text = victoria;
            resultado.color = verde;
        } else {
            resultado.text = derrota;
            resultado.color = rojo;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool revisarHistorias() {
        List<HistoriaDeUsuario> historias = controlador.obtenerHistorias();
        bool res = true;
        for (int i=0; i<historias.Count;i++) {
            if(!historias[i].getEstado()) {
                res = false;
                break;
            }
        }
        return res;
    }

    public void cambiarVista() {
        this.gameObject.SetActive(false);
        controlador.mostrarVistaEncuesta();
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["titulo"];
        victoria = map["victoria"];
        derrota = map["derrota"];
        descripcion.text = map["descripcion"];
        CambiadorBoton.cambiarBotonesAnimados(continuar, map["continuar"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }
}
