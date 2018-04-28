using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelVotacion : ClientElement {

    public GameObject button;
    public GameObject pnlHistorias;
    public GameObject titulo;
    public Text timertext;
    public int trampa;
    public int tipoVoto;

    public Text historiaDescPrefab;

    private float time = 21.0f;
    private bool contar = true;

    bool llenarTabla = true;

	// Use this for initialization
    void Start() {
        app.webClient.establecerVotacion("15600", true, tipoVoto);
    }

	void onEnable () {
		time = 20.0f;
        contar = true;
        timertext.gameObject.SetActive(true);
        titulo.SetActive(false);
        pnlHistorias.SetActive(false);
        button.SetActive(false);
        app.webClient.establecerVotacion("15600", true, tipoVoto);
	}
	
	// Update is called once per frame
	void Update () {
        if(contar) {
            time -= Time.deltaTime;
            timertext.text = ""+(int)time;
        }
        if(time <=trampa && llenarTabla) {
            llenarTabla = false;
            terminarVotacion();
            
        }
	}

    public void llenarHistorias() {
        Text txt = Instantiate(historiaDescPrefab);
        Text txt2 = Instantiate(historiaDescPrefab);
        txt.text = "Historia 1";
        txt2.text = "1";
        txt.transform.SetParent(pnlHistorias.transform);
        txt2.transform.SetParent(pnlHistorias.transform);
    }

    public void terminarVotacion() {
        llenarHistorias();
        contar = false;
        timertext.gameObject.SetActive(false);
        titulo.SetActive(true);
        pnlHistorias.SetActive(true);
        button.SetActive(true);
        app.webClient.establecerVotacion("15600", false, tipoVoto);
    }
}
