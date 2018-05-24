using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaResultados : ClientElement, IVista {
    private Idioma idioma = new ResultadosEspañol();
    public Image gato, gatoAzul, gatoNaranja;
    public Text completada, incompleta, puntosPrefab, completitud, puntos, criterio;
    public VerticalLayoutGroup criterios;
    public GameObject checkMark;
    public Color rojo, verde;

    public Text titulo, puntosSTR, criteriosSTR;
    public Button continuar;
    string completa, incompletaSTR;

    private bool dialogoActivo = false;

    void OnEnable () {
        inicializarVista();
        puntos.text = "0";
        controlador.cargarDialogoInteracion(8);
        foreach(Transform child in criterios.transform) {
            GameObject.Destroy(child.gameObject);
        }
        if (verificarCompletitud()) {
            completitud.text = completa;
            completitud.color = verde;
            gato.sprite = gatoAzul.sprite;
            gato.color = verde;
            checkMark.gameObject.SetActive(true);
            puntos.text = calcularPuntaje().ToString();
            controlador.resetearIntentos();

        } else{
            completitud.text = incompletaSTR;
            completitud.color = rojo;
            gato.sprite = gatoNaranja.sprite;
            gato.color = rojo;
            checkMark.gameObject.SetActive(false);
            mostrarCriterios();
            controlador.aumentarIntento();
        }
	}
	
    public bool verificarCompletitud(){
        List<CriterioHU> criterios = controlador.obtenerCriteriosMinijuego();

        foreach (CriterioHU crit in criterios){
            if (!crit.getEstado()){
                return false;
            }
        }

        List<HistoriaDeUsuario> historias = controlador.obtenerHistorias();
        string completada = controlador.obtenerNombreHistoriaMinijuego();

        foreach (HistoriaDeUsuario historia in historias){
            if (completada.Equals(historia.getNombre())){
                controlador.terminarHistoria(historia);
                break;
            }
        }
        return true;
    }

    public int calcularPuntaje(){
        int resultado = 0;

        int puntos = controlador.obtenerPuntosHMinijuego();
        int prioridad = controlador.obtenerPrioridadMinijuego();
        int tiempo = (int) controlador.obtenerTiempoFinal();
        int intentos = controlador.obtenerIntentos();

        resultado = ((prioridad * 300) + (puntos + tiempo)) / intentos;

        controlador.obtenerHistoriaActual().setPuntaje(resultado);

        return resultado;
    }


    public void mostrarCriterios() {

        List<CriterioHU> criteriosLista = controlador.obtenerCriteriosMinijuego();


        foreach (CriterioHU crit in criteriosLista) {
            if (!crit.getEstado()) {
                Text criterioA = Instantiate(criterio);
                Text descCriterio = criterioA.GetComponentInChildren<Text>();
                descCriterio.text = crit.getDescripcion();
                descCriterio.transform.SetParent(criterios.transform, false);
            }
        }
    }

    public void mostrarDialogoFinal() {
        controlador.cargarDialogoInteracion(9);
    }

    public void cambiarVista() {
        mostrarDialogoFinal();
        dialogoActivo = true;
    }

    void Update() {
        if (controlador.verificarDialogoVacio() && dialogoActivo) {
            controlador.terminarDia();
            if (!controlador.obtenerMinijuego().getHistoriaActual().getEstado()) {
                controlador.mostrarPanelMensaje();
            }
            dialogoActivo = false;
            this.gameObject.SetActive(false);
        }
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["titulo"];
        criteriosSTR.text = map["criterios"];
        puntosSTR.text = map["puntos"];
        completa = map["completa"];
        incompletaSTR = map["incompleta"];
        CambiadorBoton.cambiarBotonesAnimados(continuar, map["continuar"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
    }
}
