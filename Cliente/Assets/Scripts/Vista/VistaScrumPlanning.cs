using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaScrumPlanning : ClientElement {

    [SerializeField]
    private Text proyecto = null;
    [SerializeField]
    private Text descripcion = null;

    public GameObject prefabDesc;
    public GameObject prefabPrio;
    public GameObject prefabPunt;

    public VerticalLayoutGroup colDesc;
    public VerticalLayoutGroup colPrio;
    public VerticalLayoutGroup colPunt;

    public void establecerProyecto() {
        proyecto.text = app.controlador.obtenerNombreProyecto();
        descripcion.text = app.controlador.obtenerDescripcionProyecto();
    }

    public void llenarTabla()
    {
        List<HistoriaDeUsuario> historias = app.controlador.obtenerHistorias();
        for (int i = 0; i < historias.Capacity-1; i++)
        {

            GameObject contenidoHistoria = Instantiate(prefabDesc);
            GameObject contenidoPrioridad = Instantiate(prefabPrio);
            GameObject contenidoPuntos = Instantiate(prefabPunt);

            Text descripcion = contenidoHistoria.GetComponentInChildren<Text>();
            Text prioridad = contenidoPrioridad.GetComponentInChildren<Text>();
            Text puntos = contenidoPuntos.GetComponentInChildren<Text>();

            descripcion.text = historias[i].getDescripcion();
            prioridad.text = historias[i].getPrioridad();
            puntos.text = historias[i].getPuntos();

            descripcion.transform.parent = contenidoHistoria.transform;
            prioridad.transform.parent = contenidoPrioridad.transform;
            puntos.transform.parent = contenidoPuntos.transform;

            contenidoHistoria.transform.SetParent(colDesc.transform);
            contenidoPrioridad.transform.SetParent(colPrio.transform);
            contenidoPuntos.transform.SetParent(colPunt.transform);
        }
    }

    public void Start()
    {

    }
    // Use this for initialization
    public void Update () {
        establecerProyecto();
        llenarTabla();
    }
}
