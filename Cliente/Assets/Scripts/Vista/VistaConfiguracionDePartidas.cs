using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaConfiguracionDePartidas : ClientElement, IVista {
    private Idioma idioma;

    public InputField nombreJugador;
    public InputField nombrePartida;
    public Dropdown proyectosDropdown;

    public Text titulo;
    public Text nombre;
    public Text partida;
    public Text proyectos;
    public Button volver;
    public Button continuar;

    void Start() {
        controlador.pedirProyectos();
        llenarDropdown();
    }

    void OnEnable() {
        inicializarVista();
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
        controlador.establecerScrumMaster(jugador);
        this.gameObject.SetActive(false);
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["titulo"];
        nombre.text = map["nombre"];
        partida.text = map["partida"];
        proyectos.text = map["proyecto"];
        CambiadorBoton.cambiarBotonesAnimados(volver, map["volver"]);
        CambiadorBoton.cambiarBotonesAnimados(continuar, map["continuar"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }
}
