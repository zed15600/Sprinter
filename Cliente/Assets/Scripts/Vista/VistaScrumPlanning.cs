using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaScrumPlanning : ClientElement{

    // ---------------------------------------------- Contenidos ---------------------------------------------------
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
    // -------------------------------------------------------------------------------------------------------------
    public void establecerProyecto() {
        proyecto.text = controlador.obtenerNombreProyecto();
        descripcion.text = controlador.obtenerDescripcionProyecto();
    }

    public void llenarTabla()
    {

        List<HistoriaDeUsuario> historias = controlador.obtenerHistorias();
        for (int i = 0; i < historias.ToArray().Length; i++)
        {
            GameObject contenidoHistoria = Instantiate(prefabDesc);
            GameObject contenidoPrioridad = Instantiate(prefabPrio);
            GameObject contenidoPuntos = Instantiate(prefabPunt);

            Text descripcion = contenidoHistoria.GetComponentInChildren<Text>();
            Text prioridad = contenidoPrioridad.GetComponentInChildren<Text>();
            Text puntos = contenidoPuntos.GetComponentInChildren<Text>();

            descripcion.text = historias[i].getDescripcion();
            prioridad.text = "" + historias[i].getPrioridad();
            puntos.text = historias[i].getPuntos();

            contenidoHistoria.transform.SetParent(colDesc.transform, false);
            contenidoPrioridad.transform.SetParent(colPrio.transform, false);
            contenidoPuntos.transform.SetParent(colPunt.transform, false);
            
        }
    }

    public void OnEnable()
    {

        FindObjectOfType<DialogTrigger>().TriggerDialog();
        establecerProyecto();
        while (controlador.obtenerHistorias().ToArray().Length == 0)
        {
        }
        llenarTabla();
        controlador.cargarDialogoGlobal(1);
    }

    public void cambiarVista() {
        throw new System.NotImplementedException();
    }
}
