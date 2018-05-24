using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaSprintPlanning : ClientElement, IVista {
    Idioma idioma;

    [SerializeField]
    private Text restantes = null;

    [SerializeField]
    private Text actual = null;

    public VerticalLayoutGroup tablaHistorias;
    public GameObject prefabHistoriaSprints;

    //Verifica que ya se ha validado un dialogo vaciado, detiene el Update de esta vista.
    private bool dialogoVacio;
    //Verifica que ya se ha activado el dialogo, previene que el update de esta vista se inicie
    //automaticamente.
    private bool dialogoFueActivo;

    public Text story;
    public Text prio;
    public Text points;
    public Text status;
    public Button continuar;
    private string sprintRestantesString1;
    private string sprintRestantesString2;
    private string sprintNumeroString1;
    private string sprintNumeroString2;

    public void establecerSprint()
    {
        restantes.text = sprintRestantesString1 + controlador.obtenerSprintsRestantes() +
            sprintRestantesString2;
        actual.text = sprintNumeroString1 + controlador.obtenerActual() + sprintNumeroString2;
    }

    public void llenarTabla()
    {
        foreach (Transform child in tablaHistorias.transform) {
            GameObject.Destroy(child.gameObject);
        }

        List<HistoriaDeUsuario> historias = controlador.obtenerHistorias();
        for (int i = 0; i < historias.Count; i++)
        {
            GameObject historia = Instantiate(prefabHistoriaSprints);
            string titulo = historias[i].getNombre();
            historia.GetComponentsInChildren<Button>()[0].GetComponentsInChildren<Image>()[0].
                GetComponentsInChildren<Text>()[0].text = titulo;
            historia.GetComponentsInChildren<Button>()[0].
                GetComponentsInChildren<Text>()[1].text = titulo;
            historia.GetComponentsInChildren<Image>()[2].GetComponentsInChildren<Text>()[0]
                .text = historias[i].getPrioridad() + "";
            historia.GetComponentsInChildren<Image>()[3].GetComponentsInChildren<Text>()[0]
                .text = historias[i].getPuntos() + "";

            if (!historias[i].getEstado())
                historia.GetComponentsInChildren<Image>()[4].gameObject.SetActive(false);

            historia.transform.SetParent(tablaHistorias.transform, false);
        }
    }

    void OnEnable() {
        inicializarVista();
        controlador.cargarDialogoInteracion(2);
        establecerSprint();
        while (controlador.obtenerHistorias().ToArray().Length == 0) {
            Debug.Log(controlador.obtenerHistorias().Capacity);
        }
        llenarTabla();
    }

    public void organizarPaneles() {
        controlador.cargarDialogoInteracion(3);
        dialogoVacio = false;
        dialogoFueActivo = true;
    }

    void Update() {
        if (!dialogoVacio && controlador.verificarDialogoVacio() && dialogoFueActivo) {
            controlador.mostrarPanelVotacion();
            dialogoVacio = true;
            dialogoFueActivo = false;
        }
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        story.text = map["historia"];
        prio.text = map["prioridad"];
        points.text = map["puntos"];
        status.text = map["status"];
        sprintNumeroString1 = map["numeroSTR1"];
        sprintNumeroString2 = map["numeroSTR2"];
        sprintRestantesString1 = map["restantesSTR1"];
        sprintRestantesString2 = map["restantesSTR2"];
        CambiadorBoton.cambiarBotonesAnimados(continuar, map["votos"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }
}
