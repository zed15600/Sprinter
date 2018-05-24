using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaMenuJugador : ClientElement, IVista {

    private Idioma idioma;
    public Button botonIniciar;
    public Button botonConfiguracion;
    public Button botonSalida;

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        CambiadorBoton.cambiarBotonesAnimados(botonIniciar, map["iniciar"]);
        CambiadorBoton.cambiarBotonesAnimados(botonConfiguracion, map["configuracion"]);
        CambiadorBoton.cambiarBotonesAnimados(botonSalida, map["volver"]);
    }

    void OnEnable() {
        inicializarVista();
    }
}
