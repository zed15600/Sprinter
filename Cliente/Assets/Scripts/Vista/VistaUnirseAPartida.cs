using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaUnirseAPartida : ClientElement{

    public HorizontalLayoutGroup grupoJugadores;
    public Text codigo;
    public Image prefabJugador;

    private float timer = 2.0f;

    public void ponerCodigo() {
        string codigoPartida = app.controlador.obtenerCodigoPartida();
        //Debug.Log("VistaUnirseAPartida.ponerCodigo() -> Código de partida: " + codigoPartida);
        codigo.text = codigoPartida;
    }

    public void llenarGrupo() {
        foreach(Transform child in grupoJugadores.transform) {
            GameObject.Destroy(child.gameObject);
        }
        List<Jugador> jugadores = app.controlador.obtenerJugadores();
        //Debug.Log("VistaUnirseAPartida.llenarGrupo() -> Número de jugadores: " + jugadores.Count);
        foreach (Jugador j in jugadores) {
            Image instanciaJugador = Instantiate(prefabJugador);
            string nombre = j.getNombre();
            string avatar = j.getAvatar();

            Sprite imagen = app.controlador.obtenerMapaAvatares()[avatar];
            instanciaJugador.sprite = imagen;
            instanciaJugador.GetComponentInChildren<Text>().text = nombre;
            instanciaJugador.transform.SetParent(grupoJugadores.transform, false);
        }
    }

	void OnEnable () {
        ponerCodigo();
	}

	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 2.0f;
            app.controlador.pedirJugadores();
            llenarGrupo();
        }
	}
}
