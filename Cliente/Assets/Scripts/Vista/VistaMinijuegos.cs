﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaMinijuegos:ClientElement, IVista {

    private Idioma idioma;

    [SerializeField]
    private Text historia;
    
    public Text timer;
    public Image gato;
    public Text category;
    public Sprite[] gatos;
    public Color[] colores;
    public GameObject panelCriterios;

    public GameObject criterios;
    public GameObject criteriosT;

    public VerticalLayoutGroup colCriterios;
    public VerticalLayoutGroup colCriteriosT;

    //Campos Sensibles a Idioma
    public Text minijuego, criteriosSTR, seleccionar;
    public Button continuar1, continuar2;
    private string diseño, construccion, pruebas;

    int count = 0;
    float targetTime = 0;
    bool descontar = true;
    bool dialogoFueActivo = false;
    bool activarCriterios = false;

    // Use this for initialization
    void Start() {
    }

    void OnEnable() {
        inicializarVista();
        controlador.cargarDialogoInteracion(6);
        dialogoFueActivo = true;
        restart();
        actualizar();
        descontar = true;
        mostrarHistoria();
        mostrarCriterios();
        mostrarConToggles();
    }

    // Update is called once per frame
    void Update() {
        if (controlador.verificarDialogoVacio()) {
            if (dialogoFueActivo) {
                if (descontar) {
                    targetTime -= Time.deltaTime;
                    timer.text = ((int)(targetTime / 60)).ToString() + ":" + ((int)targetTime % 60).ToString();
                }
                if (targetTime <= 0) {
                    actualizar();
                }
            }

            if (activarCriterios) {
                panelCriterios.SetActive(true);
                activarCriterios = false;
            }
        }
    }

    public void restart() {
        targetTime=0.0f;
    }

    public void actualizar() {

        switch(count) {
            case 0:
                incrementarContador();
                category.text=diseño;
                category.color=colores[1];
                gato.sprite=gatos[1];
                gato.color = colores[1];
                count++;
                break;
            case 1:
                incrementarContador();
                category.text=construccion;
                category.color=colores[2];
                gato.sprite=gatos[2];
                gato.color = colores[2];
                count++;
                break;
            case 2:
                incrementarContador();
                category.text=pruebas;
                category.color=colores[0];
                gato.sprite=gatos[0];
                gato.color = colores[0];
                count++;
                break;
            case 3:
                descontar = false;
                controlador.establecerTiempo(targetTime);
                activarCriterios = true;
                controlador.cargarDialogoInteracion(7);
                count=0;
                dialogoFueActivo = false;
                break;
        }

    }

    public void incrementarContador() {
        targetTime+=120;
    }

    public void mostrarHistoria() {
        string HU = controlador.obtenerDescripcionHistoriaMinijuego();
        historia.text=HU;
    }

    public void mostrarCriterios() {
        foreach(Transform child in colCriterios.transform) {
            GameObject.Destroy(child.gameObject);
        }

        List<CriterioHU> criteriosLista = controlador.obtenerCriteriosMinijuego();
        //Debug.Log("VistaMinijuegos.mostrarCriterios() -> N° criterios: " + criteriosLista.Count);


        foreach(CriterioHU crit in criteriosLista) {
                GameObject criterioA = Instantiate(criterios);
                criterioA.GetComponentInChildren<Text>().text = crit.getDescripcion();
                criterioA.transform.SetParent(colCriterios.transform,false);
        }
    }

    public void mostrarConToggles() {
        foreach(Transform child in colCriteriosT.transform) {
            GameObject.Destroy(child.gameObject);
        }

        List<CriterioHU> criteriosLista = controlador.obtenerCriteriosMinijuego();

        foreach(CriterioHU crit in criteriosLista) {
            //if(crit!=null) {
                GameObject criterioT = Instantiate(criteriosT);
                criterioT.GetComponentInChildren<Text>().text = crit.getDescripcion();
                criterioT.transform.SetParent(colCriteriosT.transform,false);
            //}
        }
    }

    public void revisarCompletadas() {
        Toggle[] estados = colCriteriosT.GetComponentsInChildren<Toggle>();
        Text[] descripciones = colCriteriosT.GetComponentsInChildren<Text>();
        for(int i = 0;i<estados.Length;i++) {
            if(estados[i].isOn) {
                controlador.eliminarCriterioMinijuego(descripciones[i].text);
            }
        }
    }

    public void cambiarVista() {
        revisarCompletadas();
        panelCriterios.SetActive(false);
        this.gameObject.SetActive(false);
        controlador.mostrarVistaResultados();
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        minijuego.text = map["titulo"];
        criteriosSTR.text = map["criterios"];
        seleccionar.text = map["seleccionar"];
        diseño = map["diseño"];
        construccion = map["construccion"];
        pruebas = map["pruebas"];
        CambiadorBoton.cambiarBotonesAnimados(continuar1, map["continuar"]);
        CambiadorBoton.cambiarBotonesAnimados(continuar2, map["continuar"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }
}
