using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaEstado : ClientElement {

    public GameObject bienvenida;
    public GameObject detalle;
    public GameObject pnlVotacion;
    public GameObject[] btns;
    public Text[] btnsVotacion;
    public RawImage avatar;
    public Text estado;
    public Text descripcion;

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
                switch(controlador.obtenerEstadoPartida()) {
                    case "conexion":
                        bienvenida.SetActive(true);
                        detalle.SetActive(false);
                        break;
                    case "iniciada":
                        Impedimento i = controlador.obtenerImpedimento();
                        bienvenida.SetActive(false);
                        detalle.SetActive(true);
                        estado.text = i.Nombre;
                        descripcion.text = i.Descripcion;
                        if(i.Afectado) {
                            estado.color = new Color(1, 0, 0, 1);
                        } else {
                            estado.color = new Color(0, 0.710345f, 1, 1);
                        }
                        break;
                }
            }
        }
	}

    public void mostrarVotacion(string[] HUNombres, string[] HUsDesc) {
        votar = true;
        pnlVotacion.SetActive(true);
        int limit = btnsVotacion.Length/2;
        for(int i=0; i<limit;i++) {
            if(i<HUNombres.Length) {
                btnsVotacion[i].text = HUNombres[i];
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
