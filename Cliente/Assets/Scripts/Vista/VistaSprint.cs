using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaSprint : ClientElement{

    public GameObject pnlVotos;
    public GameObject prefabDesc;
    public GameObject prefabPrio;
    public GameObject prefabPunt;
    public Text dias;
    public VerticalLayoutGroup colDesc;
    public VerticalLayoutGroup colPrio;
    public VerticalLayoutGroup colPunt;

    void OnEnable(){
        int dia = controlador.obtenerDiaActual();
        dias.text = "Tiempo restante: " + dia + (dia==1?" día.":" días.");
        llenarTabla();
    }

    public void llenarTabla(){
        foreach(Transform child in colDesc.transform) {
            GameObject.Destroy(child.gameObject);
        }
        foreach(Transform child in colPrio.transform) {
            GameObject.Destroy(child.gameObject);
        }
        foreach(Transform child in colPunt.transform) {
            GameObject.Destroy(child.gameObject);
        }

        List<HistoriaDeUsuario> historias = controlador.obtenerHistoriasSprint();
        for (int i = 0; i < historias.ToArray().Length; i++){
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


    public void cambiarVista() {
        controlador.ocultarPanelMensaje();
        pnlVotos.SetActive(false);
        this.gameObject.SetActive(false);
        controlador.iniciarMinijuego();
    }
}
