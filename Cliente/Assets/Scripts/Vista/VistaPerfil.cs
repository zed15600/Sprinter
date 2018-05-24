using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaPerfil : ClientElement, IVista {

    private Idioma idioma ;

    public Text titulo;
    public Button botonJugador;
    public Button botonInvestigador;
    public Button botonSalida;

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["titulo"];
        CambiadorBoton.cambiarBotonesAnimados(botonJugador, map["jugador"]);
        CambiadorBoton.cambiarBotonesAnimados(botonInvestigador, map["investigador"]);
        CambiadorBoton.cambiarBotonesAnimados(botonSalida, map["salida"]);
    }

    void Awake() {
        idioma = new PerfilEspañol();
    }

    void OnEnable() {
        inicializarVista();
    }
}
