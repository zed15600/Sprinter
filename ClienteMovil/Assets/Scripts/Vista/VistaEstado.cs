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
    public Image avatar;
    public Text estado;
    public Text descripcion;
    private Color azulNormal = new Color(0.2090157f, 0.3889777f, 0.5754717f);
    private Color rojoImpedimento = new Color(1, 0.4470001f, 0.2971698f);
    float refreshTime = 3.0f;
    bool votar = false;
	// Use this for initialization
	void Start () {
		//votar = false;
	}

    void OnEnable() {
        //Debug.Log("VistaEstado.OnEnable() -> Avatar: " + app.modelo.getJugador().getAvatar());
        avatar.sprite = controlador.modelo.getAvatar(controlador.modelo.getJugador().getAvatar());
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
                            estado.color = rojoImpedimento;
                            descripcion.color = rojoImpedimento;
                        } else {
                            estado.color = azulNormal;
                            descripcion.color = azulNormal;
                        }
                        break;
                    case "encuesta":
                        this.gameObject.SetActive(false);
                        controlador.mostrarEncuesta();
                    break;
                }
            }
        }
	}

    public void mostrarVotacion(string[] HUNombres) {
        votar = true;
        pnlVotacion.SetActive(true);
        int limit = btnsVotacion.Length/2;
        for(int i=0; i<limit;i++) {
            if(i<HUNombres.Length) {
                btnsVotacion[i].text = HUNombres[i];
                btnsVotacion[i+limit].text = HUNombres[i];
            } else {
                btns[i].SetActive(false);
            }
        }
    }
    
    public void ocultarVotacion() {
        if(votar==true){
            votar = false;
            pnlVotacion.SetActive(false);
        }
    }

}
