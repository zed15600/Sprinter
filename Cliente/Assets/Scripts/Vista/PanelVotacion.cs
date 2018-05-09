using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelVotacion : ClientElement {

    public GameObject button;
    public GameObject pnlHistorias;
    public GameObject titulo;
    public Text timertext;
    public int tipoVoto;

    public Text historiaDescPrefab;

    private float time = 21.0f, revisarVotaciones = 2.0f;
    private bool contar = true;
    

	// Use this for initialization
    void Start() {
        
    }

	void OnEnable () {
		time = 21.0f;
        revisarVotaciones = 2.0f;
        contar = true;
        timertext.gameObject.SetActive(true);
        titulo.SetActive(false);
        pnlHistorias.SetActive(false);
        button.SetActive(false);
        app.controlador.establecerVotacion(true, tipoVoto);
	}
	
	// Update is called once per frame
	void Update () {
        if(contar) {
            time -= Time.deltaTime;
            revisarVotaciones -= Time.deltaTime;
            timertext.text = ""+(int)time;
        }
        if(contar && revisarVotaciones <= 0) {
            revisarVotaciones = 2.0f;
            app.controlador.estadoVotacion();
        }
        if(contar && time <=0) {
            terminarVotacion(true);
        }
	}

    public void mostrarVotos(string[] historiasID, int[] votos) {
        if(historiasID.Length == votos.Length){
            for(int i=0; i<historiasID.Length; i++){
                Text txt = Instantiate(historiaDescPrefab);
                Text txt2 = Instantiate(historiaDescPrefab);
                txt.text = "Historia " + historiasID[i];
                txt2.text = "" + votos[i];
                txt.transform.SetParent(pnlHistorias.transform);
                txt2.transform.SetParent(pnlHistorias.transform);
            }
        } else {
            Debug.Log("PanelVotacion.llenarHistorias() -> Hay una cantidad diferente de historias y contadores de votos");
        }
    }

    public void mostrarVotos(int historiaID, int votos) {
        Text txt = Instantiate(historiaDescPrefab);
        Text txt2 = Instantiate(historiaDescPrefab);
        txt.text = "Historia " + historiaID;
        txt2.text = "" + votos;
        txt.transform.SetParent(pnlHistorias.transform);
        txt2.transform.SetParent(pnlHistorias.transform);
    }

    public void terminarVotacion(bool origen) {
        contar = false;
        timertext.gameObject.SetActive(false);
        titulo.SetActive(true);
        pnlHistorias.SetActive(true);
        button.SetActive(true);
        if(origen){
            app.controlador.establecerVotacion(false, tipoVoto);
        }
        app.controlador.obtenerVotos(tipoVoto);
    }
}
