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
        /*Lo hice así porque me dio la gana.
         Te cedo el hecho de que, desde un punto de vista global, la cantidad de procesamiento
         que se lleva a cabo de este modo es mucho mayor a que si sólo busco si el jugador ya está
         o no, porque al fin y al cabo, vamos a tener un máxmio de 5 jugadores y cuando hayan 4
         voy a estar instanciando y borrando 4 instancias de ese prefab, continuamente hasta que
         ingrese el quinto o le den a continuar, pero eso es procesamiento por el que ningún pc va a 
         sufrir, así que por ahora no me importa.*/
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
