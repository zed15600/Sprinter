using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaSprintPlanning : ClientElement {

    [SerializeField]
    private Text restantes = null;

    [SerializeField]
    private Text actual = null;

    public GameObject prefabDesc;
    public GameObject prefabPrio;
    public GameObject prefabPunt;
    public GameObject prefabCompletada;
    public GameObject prefabVacio;

    public VerticalLayoutGroup colDesc;
    public VerticalLayoutGroup colPrio;
    public VerticalLayoutGroup colPunt;
    public VerticalLayoutGroup colEstado;

    public void establecerSprint()
    {
        restantes.text = "Quedan " + controlador.obtenerSprintsRestantes() + " Sprints.";
        actual.text = "Sprint Número: " + controlador.obtenerActual() + ".";
    }

    public void llenarTabla()
    {

        List<HistoriaDeUsuario> historias = controlador.obtenerHistorias();
        for (int i = 0; i < historias.ToArray().Length; i++)
        {
            GameObject contenidoHistoria = Instantiate(prefabDesc);
            GameObject contenidoPrioridad = Instantiate(prefabPrio);
            GameObject contenidoPuntos = Instantiate(prefabPunt);
            GameObject contenidoEstado = null;


            if (historias[i].getEstado())
            {
                contenidoEstado = Instantiate(prefabCompletada);
            } else {
                contenidoEstado = Instantiate(prefabVacio);
            }

            Text descripcion = contenidoHistoria.GetComponentInChildren<Text>();
            Text prioridad = contenidoPrioridad.GetComponentInChildren<Text>();
            Text puntos = contenidoPuntos.GetComponentInChildren<Text>();

            descripcion.text = historias[i].getDescripcion();
            prioridad.text = "" + historias[i].getPrioridad();
            puntos.text = historias[i].getPuntos();

            contenidoHistoria.transform.SetParent(colDesc.transform, false);
            contenidoPrioridad.transform.SetParent(colPrio.transform, false);
            contenidoPuntos.transform.SetParent(colPunt.transform, false);
            contenidoEstado.transform.SetParent(colEstado.transform, false);
        }
    }

    void OnEnable() {
        establecerSprint();
        while (controlador.obtenerHistorias().ToArray().Length == 0) {
            Debug.Log(controlador.obtenerHistorias().Capacity);
        }
        llenarTabla();
        controlador.cargarDialogoGlobal(2);
    }

    public void organizarPaneles() {
        controlador.cargarDialogoGlobal(3);
        while (!controlador.verificarDialogoVacio()) {
        }
        controlador.mostrarPanelVotacion();
    }

}
