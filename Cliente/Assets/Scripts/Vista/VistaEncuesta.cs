using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaEncuesta : ClientElement, IVista {
    Idioma idioma;

    public Text pregunta;
    public Text a;
    public Text b;
    public Text c;
    public Text d;
    public Text tiempo;


    public Text titulo, respondeMovil;
    float tiempoPorPregunta = 20f;

    private string siguiente, segundos, segundo;

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["poll"];
        respondeMovil.text = map["movil"];
        siguiente = map["siguiente"];
        segundos = map["segundos"];
        segundo = map["segundo"];
    }

    void OnEnable () {
        inicializarVista();
        Pregunta p = controlador.obtenerPregunta();
		pregunta.text = p.Descripcion;
        a.text = (p.Respuestas[1].Equals("")?"":"A. ")+ p.Respuestas[0];
        b.text = (p.Respuestas[1].Equals("")?"":"B. ")+p.Respuestas[1];
        c.text = (p.Respuestas[1].Equals("") ? "" : "C. ")+p.Respuestas[2];
        d.text = (p.Respuestas[1].Equals("") ? "" : "D. ")+p.Respuestas[3];
	}
	
	// Update is called once per frame
	void Update () {
		if(tiempoPorPregunta >=0) {
            tiempoPorPregunta -= Time.deltaTime;
            int t = (int)tiempoPorPregunta;
            tiempo.text = siguiente + t + (t==1?segundo:segundos);
        } else {
            tiempoPorPregunta = 20f;
            controlador.siguientePregunta();
            Debug.Log(controlador.obtenerPregunta());
            OnEnable();
        }
	}
}
