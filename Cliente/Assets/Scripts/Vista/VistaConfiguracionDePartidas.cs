using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaConfiguracionDePartidas : ClienteVista {
    public InputField nombreJugador;
    public InputField nombrePartida;
    public Dropdown proyectosDropdown;

    public void Start() {
        app.controlador.pedirProyectos();
        llenarDropdown();
    }
    public void llenarDropdown() {
        List<string> nombresProyecto = app.controlador.obtenerProyectos();
        proyectosDropdown.AddOptions(nombresProyecto);
    }

    public void crearPartida() {
        string jugador = nombreJugador.text;
        string partida = nombrePartida.text;
        string proyecto = proyectosDropdown.captionText.text;
        app.controlador.crearPartida(jugador, partida, proyecto);
        app.controlador.obtenerProyectoServidor();
        unirseAPartida.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void cambiarVista() {
        throw new System.NotImplementedException();
    }
}
