using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaRetrospectiva : ClientElement, IVista {

    private Idioma idioma = new RetrospectivaIngles();

    public GameObject tabla;
    public GameObject historiaPrefab;
    public Text textoDelGato;
    private string bueno, malo;
    public Button continuar;

    List<HistoriaDeUsuario> historiasDeSprint;
    private bool dialogoActivo = false;

    public Text titulo;
    // Use this for initialization
    void OnEnable () {
        inicializarVista();
        controlador.cargarDialogoFinal(11);
        historiasDeSprint = controlador.obtenerHistoriasSprint();
        mostrarDialogoCliente();
        mostrarHistorias(historiasDeSprint);
    }

    // Update is called once per frame
    void Update() {
        if (dialogoActivo && controlador.verificarDialogoVacio()) {
            Proyecto p = controlador.obtenerProyecto();
            if (p.getSprintActual() > p.getNumeroSprints()) {
                controlador.mostrarVistaFinDelJuego();
            }
            else {
                controlador.mostrarVistaSprintPlanning();
            }
            dialogoActivo = false;
            this.gameObject.SetActive(false);
        }
    }

    public void mostrarDialogoCliente() {
        if (controlador.verificarSprintTotalmenteCompleto()) {
            textoDelGato.text = bueno;
        } else {
            textoDelGato.text = malo;
        }
    }

    public void mostrarHistorias(List<HistoriaDeUsuario> historias) {
        foreach (Transform child in tabla.transform) {
            GameObject.Destroy(child.gameObject);
        }
        foreach(HistoriaDeUsuario historia in historias) {
            GameObject hist = Instantiate(historiaPrefab);
            hist.GetComponentsInChildren<Text>()[0].text = historia.getNombre();
            hist.GetComponentsInChildren<Text>()[1].text = historia.getNombre();
            hist.GetComponentsInChildren<Text>()[2].text = historia.getPuntaje().ToString();
            hist.transform.SetParent(tabla.transform);
        }
    }

    public void cambiarVista() {
        controlador.cargarDialogoFinal(12);
        dialogoActivo = true;
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["titulo"];
        bueno = map["buen trabajo"];
        malo = map["mal trabajo"];
        CambiadorBoton.cambiarBotonesAnimados(continuar, map["continuar"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }
}
