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
        Debug.Log(codigoPartida);
        codigo.text = codigoPartida;
    }

    public void llenarGrupo() {
        List<Jugador> jugadores = app.controlador.obtenerJugadores();
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
