using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHistorias : ClientElement,IVista {

    Idioma idioma;
    public Text tituloPanel;
    public Text descripcion;
    public Text prioridad;
    public Text puntos;

    public Text prioridadSTR, puntosSTR;


	public void actualizarHistoria(string titulo) {
        inicializarVista();
        tituloPanel.text = titulo;
        HistoriaDeUsuario historia = controlador.obtenerHistoriaPorTitulo(titulo);
        descripcion.text = historia.getDescripcion();
        prioridad.text = prioridadSTR.text + historia.getPrioridad();
        puntos.text = puntos.text + historia.getPuntos();
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        prioridadSTR.text = map["prioridad"];
        puntosSTR.text = map["puntos"];
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }
}
