using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaEncuesta : ClientElement {

    public Text pregunta;
    public Text a;
    public Text b;
    public Text c;
    public Text d;
    public Text tiempo;

    float tiempoPorPregunta = 20f;
    
	void OnEnable () {
        Pregunta p = controlador.obtenerPregunta();
		pregunta.text = p.Descripcion;
        a.text = p.Respuestas[0];
        b.text = p.Respuestas[1];
        c.text = p.Respuestas[2];
        d.text = p.Respuestas[3];
	}
	
	// Update is called once per frame
	void Update () {
		if(tiempoPorPregunta >=0) {
            tiempoPorPregunta -= Time.deltaTime;
            int t = (int)tiempoPorPregunta;
            tiempo.text = "Siguiente pregunta en " + t + (t==1?" segundo.":" segundos.");
        } else {
            tiempoPorPregunta = 20f;
            controlador.siguientePregunta();
            OnEnable();
        }
	}
}
