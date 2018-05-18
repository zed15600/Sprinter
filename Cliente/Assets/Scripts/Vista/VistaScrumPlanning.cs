using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaScrumPlanning : ClientElement{

    // ---------------------------------------------- Contenidos ---------------------------------------------------
    [SerializeField]
    private Text proyecto = null;
    [SerializeField]
    private Text descripcion = null;

    public GameObject prefabHistoria;

    public VerticalLayoutGroup contenidosHistoria;

    // -------------------------------------------------------------------------------------------------------------
    public void establecerProyecto() {
        proyecto.text = controlador.obtenerNombreProyecto();
        descripcion.text = controlador.obtenerDescripcionProyecto();
    }

    public void llenarTabla()
    {
        foreach (Transform child in contenidosHistoria.transform) {
            GameObject.Destroy(child.gameObject);
        }

        List<HistoriaDeUsuario> historias = controlador.obtenerHistorias();
        for (int i = 0; i < historias.Count; i++) {
            GameObject historia = Instantiate(prefabHistoria);
            string titulo = historias[i].getNombre();
            historia.GetComponentsInChildren<Button>()[0].GetComponentsInChildren<Image>()[0].
                GetComponentsInChildren<Text>()[0].text = titulo;
            historia.GetComponentsInChildren<Button>()[0].
                GetComponentsInChildren<Text>()[1].text = titulo;
            historia.GetComponentsInChildren<Image>()[2].GetComponentsInChildren<Text>()[0]
                .text = historias[i].getPrioridad() + "";
            historia.GetComponentsInChildren<Image>()[3].GetComponentsInChildren<Text>()[0]
                .text = historias[i].getPuntos() + "";
            historia.transform.SetParent(contenidosHistoria.transform, false);     
        }
    }

    public void OnEnable()
    {
        controlador.cargarDialogoGlobal(1);
        //FindObjectOfType<DialogTrigger>().TriggerDialog();
        establecerProyecto();
        while (controlador.obtenerHistorias().ToArray().Length == 0)
        {
        }
        llenarTabla();
    }
}
