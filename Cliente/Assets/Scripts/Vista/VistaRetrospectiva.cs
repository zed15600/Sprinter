using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaRetrospectiva : ClientElement {

    public GameObject tabla;
    public Text textPrefab;
    public Text textoDelGato;

    List<HistoriaDeUsuario> historiasDeSprint;
    //int[][] a;
    //int x=0;

	// Use this for initialization
	void OnEnable () {
        historiasDeSprint = controlador.obtenerHistoriasSprint();
        mostrarHistorias(historiasDeSprint);
		//a = new int[][] {new int[]{1, 2745}, new int[]{2, 1890}};
	}
	
	// Update is called once per frame
	void Update () {
        /*x++;
        if(x==10)
		mostrarHistorias(a, "Hiciste algo.\n\nBien.");*/
	}

    public void mostrarHistorias(List<HistoriaDeUsuario> historias) {
        foreach(HistoriaDeUsuario historia in historias) {
            Text txt1 = Instantiate(textPrefab);
            Text txt2 = Instantiate(textPrefab);
            txt1.text = historia.getNombre();
            txt2.text = ""+historia.getPuntaje();
            txt1.transform.SetParent(tabla.transform);
            txt2.transform.SetParent(tabla.transform);
        }
    }

    public void cambiarVista() {
        this.gameObject.SetActive(false);
        Proyecto p = controlador.obtenerProyecto();
        if(p.getSprintActual() > p.getNumeroSprints()) {
            controlador.vista.finDelJuego.gameObject.SetActive(true);
        } else {
            controlador.vista.vistaSprint.gameObject.SetActive(true);
        }
    }
}
