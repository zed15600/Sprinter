using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaMenuInvestigador : ClientElement, IVista {

    private Idioma idioma;
    public Button botonIniciar;
    public Button botonSalida;

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        CambiadorBoton.cambiarBotonesAnimados(botonIniciar, map["datos"]);
        CambiadorBoton.cambiarBotonesAnimados(botonSalida, map["volver"]);
    }

    void OnEnable() {
        inicializarVista();
    }
}
