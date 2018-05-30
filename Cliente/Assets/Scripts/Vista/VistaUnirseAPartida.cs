using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaUnirseAPartida : ClientElement, IVista {

    private Idioma idioma;
    public GameObject vistasPartidas;
    public HorizontalLayoutGroup grupoJugadores;
    public Text codigo, codigoJuego;
    public Image prefabJugador;

    private float timer = 2.0f;

    public Text titulo;
    public Button volver;
    public Button continuar;

    public void ponerCodigo() {
        string codigoPartida = controlador.obtenerCodigoPartida();
        //Debug.Log("VistaUnirseAPartida.ponerCodigo() -> Código de partida: " + codigoPartida);
        codigo.text = codigoPartida;
        codigoJuego.text = controlador.obtenerCodigoPartida();
    }

    public void llenarGrupo() {
        foreach(Transform child in grupoJugadores.transform) {
            GameObject.Destroy(child.gameObject);
        }
        List<Jugador> jugadores = controlador.obtenerJugadores();
        //Debug.Log("VistaUnirseAPartida.llenarGrupo() -> Número de jugadores: " + jugadores.Count);
        foreach (Jugador j in jugadores) {
            Image instanciaJugador = Instantiate(prefabJugador);
            string nombre = j.getNombre();
            string avatar = j.getAvatar();

            Sprite imagen = controlador.obtenerMapaAvatares()[avatar];
            instanciaJugador.sprite = imagen;
            instanciaJugador.GetComponentInChildren<Text>().text = nombre;
            instanciaJugador.transform.SetParent(grupoJugadores.transform, false);
        }
    }

	void OnEnable () {
        inicializarVista();
        ponerCodigo();
	}

	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 2.0f;
            controlador.pedirJugadores();
            llenarGrupo();
        }
	}

    public void cambiarVista() {
        controlador.mostrarVistasPartidas();
        controlador.empezarPartida();
        this.gameObject.SetActive(false);
        controlador.mostrarVistaScrumPlanning();
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["titulo"];
        CambiadorBoton.cambiarBotonesAnimados(volver, map["volver"]);
        CambiadorBoton.cambiarBotonesAnimados(continuar, map["continuar"]);
    }
}
