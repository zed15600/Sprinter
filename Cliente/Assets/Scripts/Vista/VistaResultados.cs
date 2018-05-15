using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaResultados : ClientElement {

    public Text completitud; 
    public Image gato;
    public Text puntos;
    public Text completada;
    public Text incompleta;
    public Text puntosPrefab;
    public Image gatoVerde;
    public Image gatoNaranja;
    public VerticalLayoutGroup criterios;
    public Text criterio;
    public Image checkMark;

	void OnEnable () {
        foreach(Transform child in criterios.transform) {
            GameObject.Destroy(child.gameObject);
        }
        if (verificarCompletitud()) {
            completitud.text = completada.text;
            completitud.color = completada.color;
            gato.sprite = gatoVerde.sprite;
            checkMark.gameObject.SetActive(true);
            puntos.text = calcularPuntaje().ToString();
            controlador.resetearIntentos();

        } else{
            completitud.text = incompleta.text;
            completitud.color = incompleta.color;
            gato.sprite = gatoNaranja.sprite;
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

    public void cambiarVista() {
        controlador.terminarDia();
        if(!controlador.obtenerMinijuego().getHistoriaActual().getEstado()) {
            controlador.mostrarPanelMensaje();
        }
        this.gameObject.SetActive(false);
    }
}
