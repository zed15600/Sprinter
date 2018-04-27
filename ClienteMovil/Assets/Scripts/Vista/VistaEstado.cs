using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaEstado : ClientElement {

    public GameObject pnlVotacion;
    public GameObject[] btns;
    public Text[] btnsVotacion;

    float refreshTime = 3.0f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update () {
        if(refreshTime>0) {
            refreshTime -= Time.deltaTime;
        } else {
            refreshTime = 3.0f;
            app.controlador.actualizarEstado(app.modelo.getPartida().getID());
        }
	}

    public void mostrarVotacion(int[] HUsId, string[] HUsDesc) {
        for(int i=0; i<4;i++) {
            if(i<HUsId.Length) {
                btnsVotacion[i].text = ""+HUsId[i];
                btnsVotacion[i+1].text = HUsDesc[i];
            } else {
                btns[i].SetActive(false);
            }
        }
        pnlVotacion.SetActive(true);
    }

    public void ocultarVotacion() {
        pnlVotacion.SetActive(false);
    }
}
