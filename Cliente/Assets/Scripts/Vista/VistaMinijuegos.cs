using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaMinijuegos:ClientElement {
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
    public Toggle toggle;

    public VerticalLayoutGroup colCriterios;
    public VerticalLayoutGroup colCriteriosT;
    public VerticalLayoutGroup colToggles;


    int count = 0;
    float targetTime = 0;
    bool descontar = true;
    bool dialogoFueActivo = false;
    bool activarCriterios = false;

    // Use this for initialization
    void Start() {
    }

    void OnEnable() {
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
            category.text="Diseño";
            category.color=colores[1];
            gato.sprite=gatos[1];
            count++;
            break;
            case 1:
            incrementarContador();
            category.text="Construcción";
            category.color=colores[2];
            gato.sprite=gatos[2];
            count++;
            break;
            case 2:
            incrementarContador();
            category.text="Pruebas";
            category.color=colores[0];
            gato.sprite=gatos[0];
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
            //if(crit!=null) {
                GameObject criterioA = Instantiate(criterios);
                Text descCriterio = criterioA.GetComponentInChildren<Text>();
                descCriterio.text=crit.getDescripcion();
                descCriterio.transform.SetParent(colCriterios.transform,false);
            //}
        }
    }

    public void mostrarConToggles() {
        foreach(Transform child in colCriteriosT.transform) {
            GameObject.Destroy(child.gameObject);
        }
        foreach(Transform child in colToggles.transform) {
            GameObject.Destroy(child.gameObject);
        }
        List<CriterioHU> criteriosLista = controlador.obtenerCriteriosMinijuego();

        foreach(CriterioHU crit in criteriosLista) {
            //if(crit!=null) {
                GameObject criterioT = Instantiate(criteriosT);
                Toggle critToggle = Instantiate(toggle);
                Text descCriterio = criterioT.GetComponentInChildren<Text>();
                descCriterio.text=crit.getDescripcion();
                descCriterio.transform.SetParent(colCriteriosT.transform,false);
                critToggle.transform.SetParent(colToggles.transform,false);
            //}
        }
    }

    public void revisarCompletadas() {
        Toggle[] estados = colToggles.GetComponentsInChildren<Toggle>();
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

}
