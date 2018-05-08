using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaConfiguracionDePartidas : ClientElement {
    public InputField nombreJugador;
    public InputField nombrePartida;
    public Dropdown proyectosDropdown;

    public void Start() {
        app.webClient.pedirProyectos();
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
        app.webClient.crearPartida(jugador, partida, proyecto);
        app.webClient.obtenerProyecto();
        app.vista.unirseAPartida.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
