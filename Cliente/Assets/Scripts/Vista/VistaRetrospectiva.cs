using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaRetrospectiva : ClientElement {

    public GameObject tabla;
    public Text textPrefab;
    public Text textoDelGato;
    int[][] a;
    int x=0;

	// Use this for initialization
	void Start () {
		a = new int[][] {new int[]{1, 2745}, new int[]{2, 1890}};
	}
	
	// Update is called once per frame
	void Update () {
        x++;
        if(x==10)
		mostrarHistorias(a, "Hiciste algo.\n\nBien.");
	}

    public void mostrarHistorias(int[][] historias, string texto) {
        textoDelGato.text = texto;
        for(int i=0; i<historias.Length; i++) {
            Text txt1 = Instantiate(textPrefab);
            Text txt2 = Instantiate(textPrefab);
            txt1.text = historias[i][0].ToString();
            txt2.text = historias[i][1].ToString();
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
