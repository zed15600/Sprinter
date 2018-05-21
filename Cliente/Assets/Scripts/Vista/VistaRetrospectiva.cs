using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaRetrospectiva : ClientElement {

    public GameObject tabla;
    public GameObject historiaPrefab;
    public Text textoDelGato;

    List<HistoriaDeUsuario> historiasDeSprint;
    private bool dialogoActivo = false;

    // Use this for initialization
    void OnEnable () {
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
            textoDelGato.text = "Lograron completar todas las historias del Sprint! \n" +
                        "El cliente esta muy satisfecho con el trabajo hecho, Felicidades. :D";
        } else {
            textoDelGato.text = "Parece que faltaron algunas historias por completar. :( \n" +
                        "El cliente espera más compromiso de parte de ustedes.";
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
}
