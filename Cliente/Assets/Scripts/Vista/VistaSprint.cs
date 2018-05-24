using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaSprint : ClientElement, IVista {
    Idioma idioma;

    public GameObject pnlVotos;
    public GameObject prefabHistoria;
    public Text dias;
    public VerticalLayoutGroup tablaHistorias;

    public Text story;
    public Text prio;
    public Text points;
    public Button continuar;

    private string tiempoRestante;
    private string diaStr;
    private string diasStr;

    void OnEnable(){
        inicializarVista();
        controlador.cargarDialogoInteracion(4);
        int dia = controlador.obtenerDiaActual();
        dias.text = tiempoRestante + dia + (dia==1?diaStr:diasStr);
        llenarTabla();
    }

    public void llenarTabla(){

        foreach(Transform child in tablaHistorias.transform) {
            GameObject.Destroy(child.gameObject);
        }

        List<HistoriaDeUsuario> historias = controlador.obtenerHistoriasSprint();
        for (int i = 0; i < historias.Count; i++){
            if (!historias[i].getEstado()) {
                GameObject contenidoHistoria = Instantiate(prefabHistoria);
                string titulo = historias[i].getNombre();
                contenidoHistoria.GetComponentsInChildren<Button>()[0].GetComponentsInChildren<Image>()[0].
                    GetComponentsInChildren<Text>()[0].text = titulo;
                contenidoHistoria.GetComponentsInChildren<Button>()[0].
                    GetComponentsInChildren<Text>()[1].text = titulo;
                contenidoHistoria.GetComponentsInChildren<Image>()[2].GetComponentsInChildren<Text>()[0]
                    .text = historias[i].getPrioridad() + "";
                contenidoHistoria.GetComponentsInChildren<Image>()[3].GetComponentsInChildren<Text>()[0]
                    .text = historias[i].getPuntos() + "";
                contenidoHistoria.transform.SetParent(tablaHistorias.transform, false);
            }
        }
    }


    public void cambiarVista() {
        controlador.ocultarPanelMensaje();
        pnlVotos.SetActive(false);
        this.gameObject.SetActive(false);
        controlador.iniciarReunion();
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        story.text = map["historia"];
        prio.text = map["prioridad"];
        points.text = map["puntos"];
        tiempoRestante = map["STRtrestante"];
        diaStr = map["STRDia"];
        diasStr = map["STRDias"];
        CambiadorBoton.cambiarBotonesAnimados(continuar, map["continuar"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }
}
