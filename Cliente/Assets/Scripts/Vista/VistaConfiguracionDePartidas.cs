using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaConfiguracionDePartidas : ClientElement {
    public InputField nombreJugador;
    public InputField nombrePartida;
    public Dropdown proyectosDropdown;

    void Start() {
        controlador.pedirProyectos();
        llenarDropdown();
    }
    public void llenarDropdown() {
        List<string> nombresProyecto = controlador.obtenerProyectos();
        proyectosDropdown.AddOptions(nombresProyecto);
    }

    public void crearPartida() {
        string jugador = nombreJugador.text;
        string partida = nombrePartida.text;
        string proyecto = proyectosDropdown.captionText.text;
        controlador.crearPartida(jugador, partida, proyecto);
        controlador.obtenerProyectoServidor();
        controlador.mostrarVistaUnirseAPartida();
        this.gameObject.SetActive(false);
    }

    public void cambiarVista() {
        throw new System.NotImplementedException();
    }
}
