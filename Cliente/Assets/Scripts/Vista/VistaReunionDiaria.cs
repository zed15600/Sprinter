using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaReunionDiaria : ClientElement, IVista {
    private Idioma idioma;

    public Text Historia;
    public Text diaSprint;
    public Text timer;

    public VerticalLayoutGroup criteriosLayout;
    public GridLayoutGroup jugadoresEnProblemas;

    public GameObject jugadoresPrefab;
    public GameObject criteriosPrefab;

    public Text titulo, criterios, problemas, desarollo, dia;
    public Button continuarBoton;
    float targetTime = 60;
    private bool dialogoFueActivo = false;

    void OnEnable () {
        inicializarVista();
        controlador.cargarDialogoInteracion(5);
        if (controlador.obtenerMinijuego().getJugadoresEnProblemas().Count > 0) {
            controlador.cargarDialogoImpedimento();
        }
        dialogoFueActivo = true;
        establecerReunion();
	}

    public void establecerReunion() {
        foreach (Transform child in jugadoresEnProblemas.transform) {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in criteriosLayout.transform) {
            GameObject.Destroy(child.gameObject);
        }

        Minijuego minijuego = controlador.obtenerMinijuego();
        HistoriaDeUsuario historia = minijuego.getHistoriaActual();
        Historia.text = historia.getNombre();
        diaSprint.text = dia.text + controlador.obtenerDiaActual();
        foreach (Jugador j in minijuego.getJugadoresEnProblemas()) {
            GameObject jugador = Instantiate(jugadoresPrefab);
            jugador.GetComponentInChildren<Text>().text = j.getNombre();
            Sprite imagen = controlador.obtenerMapaAvatares()[j.getAvatar()];
            jugador.GetComponentInChildren<Image>().sprite = imagen;

            jugador.transform.SetParent(jugadoresEnProblemas.transform, false);
        }

        foreach (CriterioHU crit in historia.getCriterios()) {
            GameObject criterio = Instantiate(criteriosPrefab);
            criterio.GetComponentInChildren<Text>().text = crit.getDescripcion();
            criterio.transform.SetParent(criteriosLayout.transform, false);
        }
    }

    public void restart() {
        targetTime = 60;
    }

    public void continuar() {
        targetTime = 0.0f;
    }

    void Update() {
        if (controlador.verificarDialogoVacio() && dialogoFueActivo) {
            targetTime -= Time.deltaTime;
            timer.text = ((int)(targetTime)).ToString();
            if (targetTime <= 0) {
                restart();
                dialogoFueActivo = false;
                gameObject.SetActive(false);
                controlador.iniciarMinijuego();
            }
        }
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["titulo"];
        criterios.text = map["criterios"];
        problemas.text = map["problemas"];
        desarollo.text = map["desarrollo"];
        dia.text = map["dia"];
        CambiadorBoton.cambiarBotonesAnimados(continuarBoton, map["continuar"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }
}
