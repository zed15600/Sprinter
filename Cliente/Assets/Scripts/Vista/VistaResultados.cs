using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaResultados : ClienteVista {

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
        if (verificarCompletitud()) {
            completitud.text = completada.text;
            completitud.color = completada.color;
            gato.sprite = gatoVerde.sprite;
            checkMark.gameObject.SetActive(true);
            puntos.text = calcularPuntaje().ToString();
            app.controlador.resetearIntentos();

        } else{
            completitud.text = incompleta.text;
            completitud.color = incompleta.color;
            gato.sprite = gatoNaranja.sprite;
            checkMark.gameObject.SetActive(false);
            mostrarCriterios();
            app.controlador.aumentarIntento();
        }
	}
	
    public bool verificarCompletitud(){
        List<string> criterios = app.controlador.obtenerCriteriosMinijuego();

        foreach (string crit in criterios)
        {
            if (crit != null)
            {
                return false;
            }
        }

        List<HistoriaDeUsuario> historias = app.controlador.obtenerHistorias();
        string completada = app.controlador.obtenerHistoriaMinijuego();

        foreach (HistoriaDeUsuario historia in historias)
        {
            if (completada.Equals(historia.getDescripcion()))
            {
                app.controlador.cambiarEstado(historia);
            }
        }
        return true;
    }

    public int calcularPuntaje()
    {
        int resultado = 0;

        int puntos = app.controlador.obtenerPuntosHMinijuego();
        int prioridad = app.controlador.obtenerPrioridadMinijuego();
        int tiempo = (int) app.controlador.obtenerTiempoFinal();
        int intentos = app.controlador.obtenerIntentos();

        resultado = ((prioridad * 300) + (puntos + tiempo)) / intentos;

        return resultado;
    }

    public void mostrarCriterios() {

        List<string> criteriosLista = app.controlador.obtenerCriteriosMinijuego();


        foreach (string crit in criteriosLista) {
            if (crit != null) {
                Text criterioA = Instantiate(criterio);
                Text descCriterio = criterioA.GetComponentInChildren<Text>();
                descCriterio.text = crit;
                descCriterio.transform.SetParent(criterios.transform, false);
            }
        }
    }

    public void cambiarVista() {
        this.gameObject.SetActive(false);
        app.controlador.terminarDia();
    }
}
