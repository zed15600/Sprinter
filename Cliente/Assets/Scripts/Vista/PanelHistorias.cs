using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHistorias : ClientElement {

    public Text tituloPanel;
    public Text descripcion;
    public Text prioridad;
    public Text puntos;

	public void actualizarHistoria(string titulo) {
        tituloPanel.text = titulo;
        HistoriaDeUsuario historia = controlador.obtenerHistoriaPorTitulo(titulo);
        descripcion.text = historia.getDescripcion();
        prioridad.text = "Prioridad: " + historia.getPrioridad();
        puntos.text = "Puntos: " + historia.getPuntos();
    }

}
