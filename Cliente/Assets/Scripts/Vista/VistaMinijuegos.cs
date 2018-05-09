using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaMinijuegos : ClientElement {
    [SerializeField]
    private Text historia;

    public GameObject table;
    public Text timer;
    public Image gato;
    public Text category;
    public GameObject HUnumber;
    public GameObject continuar;
    public float targetTime = 0;
    public Sprite gatoAzul;
    public Sprite gatoNaranja;
    public Sprite gatoVerde;
    public Color naranja;
    public Color azul;
    public Color verde;
    public GameObject panelCriterios;

    public GameObject criterios;
    public GameObject criteriosT;
    public Toggle toggle;

    public VerticalLayoutGroup colCriterios;
    public VerticalLayoutGroup colCriteriosT;
    public VerticalLayoutGroup colToggles;


    int count = 0;

    // Use this for initialization
    void Start () {
        mostrarHistoria();
        mostrarCriterios();
        mostrarConToggles();
	}

    void OnEnable()
    {
        actualizar();
    }
	
	// Update is called once per frame
	void Update () {
        Timer();

        if (targetTime <= 0) {
            actualizar();
        }
	}

    public void Continuar() {
        actualizar();
    }

    void Timer() {

        targetTime -= Time.deltaTime;
        timer.text = ((int)(targetTime/60)).ToString()+":"+((int)targetTime%60).ToString();

        if (targetTime <= 0.0f) {

            timerEnded();
        }
    }
    void timerEnded()
    {
       //UIText timerText = Timer.Get
        //mer.text = "tiempo";
    }
    public void restart() {
        targetTime=120.0f;
    }

    public void actualizar() {

        switch (count) {
            case 0:
                incrementarContador();
                category.text = "Diseño";
                category.color = naranja;
                gato.sprite = gatoNaranja;
                count++;
                break;
            case 1:
                incrementarContador();
                category.text = "Construcción";
                category.color = verde;
                gato.sprite = gatoVerde;
                count++;
                break;
            case 2:
                incrementarContador();
                category.text = "Pruebas";
                category.color = azul;
                gato.sprite = gatoAzul;
                count++;
                break;
            case 3:
                controlador.establecerTiempo(targetTime);
                panelCriterios.SetActive(true);
                count = 0;
                break;
        } 

    }

    public void incrementarContador() {

        targetTime += 120;
    }

    public void mostrarHistoria() {
        string HU = controlador.obtenerHistoriaMinijuego();
        historia.text = HU;
    }

    public void mostrarCriterios() {

        List<string> criteriosLista = controlador.obtenerCriteriosMinijuego();


        foreach (string crit in criteriosLista)
        {
            if (crit != null)
            {
                GameObject criterioA = Instantiate(criterios);
                Text descCriterio = criterioA.GetComponentInChildren<Text>();
                descCriterio.text = crit;
                descCriterio.transform.SetParent(colCriterios.transform, false);
            }
        }
    }

    public void mostrarConToggles() {
        List<string> criteriosLista = controlador.obtenerCriteriosMinijuego();

        foreach (string crit in criteriosLista)
        {
            if (crit != null)
            {
                GameObject criterioT = Instantiate(criteriosT);
                Toggle critToggle = Instantiate(toggle);
                Text descCriterio = criterioT.GetComponentInChildren<Text>();
                descCriterio.text = crit;
                descCriterio.transform.SetParent(colCriteriosT.transform, false);
                critToggle.transform.SetParent(colToggles.transform, false);
            }
        }
    }

    public void revisarCompletadas()
    {
        Toggle[] estados = colToggles.GetComponentsInChildren<Toggle>();
        for (int i = 0;i<estados.Length;i++)
        {
            if (estados[i].isOn)
            {
                controlador.eliminarCriterioMinijuego(i);
            }
        }
    }

    public void cambiarVista() {
        throw new System.NotImplementedException();
    }
}
