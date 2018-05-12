using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaEstado : ClientElement {

    public GameObject pnlVotacion;
    public GameObject[] btns;
    public Text[] btnsVotacion;
    public RawImage avatar;

    float refreshTime = 3.0f;
    bool votar = false;

	// Use this for initialization
	void Start () {
		//votar = false;
	}

    void OnEnable() {
        //Debug.Log("VistaEstado.OnEnable() -> Avatar: " + app.modelo.getJugador().getAvatar());
        avatar.texture = controlador.modelo.getAvatar(controlador.modelo.getJugador().getAvatar());
        votar = false;

    }

    // Update is called once per frame
    void Update () {
        if(!votar){
            if(refreshTime>0) {
                refreshTime -= Time.deltaTime;
            } else {
                refreshTime = 3.0f;
                controlador.actualizarEstado();
            }
        }
	}

    public void mostrarVotacion(int[] HUsId, string[] HUsDesc) {
        votar = true;
        pnlVotacion.SetActive(true);
        int limit = btnsVotacion.Length/2;
        for(int i=0; i<limit;i++) {
            if(i<HUsId.Length) {
                btnsVotacion[i].text = ""+HUsId[i];
                btnsVotacion[i+limit].text = HUsDesc[i];
            } else {
                btns[i].SetActive(false);
            }
        }
    }

    public void ocultarVotacion() {
        votar = false;
        pnlVotacion.SetActive(false);
    }

}
