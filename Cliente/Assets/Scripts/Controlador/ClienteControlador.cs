using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClienteControlador : ClientElement {

    public string obtenerNombreProyecto() {
        return app.modelo.getProyecto().getNombre();
    }

    public string obtenerDescripcionProyecto(){
        return app.modelo.getProyecto().getDescripcion();
    }

    public List<HistoriaDeUsuario> obtenerHistorias()
    {
        return app.modelo.getProyecto().getHistorias();
    }

    internal string obtenerCodigoPartida() {
        return app.modelo.getPartida().getID();
    }

    public string obtenerSprintsRestantes()
    {
        return app.modelo.getProyecto().getRestantes().ToString();
    }

    public string obtenerActual()
    {
        return app.modelo.getProyecto().getActual().ToString();
    }

    public string obtenerHistoriaMinijuego() {
        return app.modelo.getMinijuego().getHistoriaActual().getDescripcion();   
    }

    public List<string> obtenerCriteriosMinijuego()
    {
        return app.modelo.getMinijuego().getHistoriaActual().getCriterios();
    }

    public void eliminarCriterioMinijuego(int indice)
    {
        app.modelo.getMinijuego().eliminarCriterio(indice);
    }

    public void cambiarEstado(HistoriaDeUsuario historia)
    {
        historia.cambiarEstado();
        app.webClient.establecerCompletada(historia.getID());
    }

    public int obtenerPuntosHMinijuego()
    {
        int puntos = 0;
        puntos = int.Parse(app.modelo.getMinijuego().getHistoriaActual().getPuntos());
        return puntos;
    }

    public int obtenerPrioridadMinijuego()
    {
        int prioridad = 0;
        prioridad = int.Parse(app.modelo.getMinijuego().getHistoriaActual().getPrioridad());
        return prioridad;
    }

    public void establecerTiempo(float tiempo)
    {
        app.modelo.getMinijuego().setTiempoFinal(tiempo);
    }

    public float obtenerTiempoFinal()
    {
        float tiempoFinal = 0;
        tiempoFinal = app.modelo.getMinijuego().getTiempoFinal();
        return tiempoFinal;
    }

    public int obtenerIntentos()
    {
        return app.modelo.getMinijuego().getIntentos();
    }

    public void resetearIntentos() {
        app.modelo.getMinijuego().resetearIntentos();
    }

    public void aumentarIntento() {
        app.modelo.getMinijuego().aumentarIntentos();
    }

    public void obtenerPuntaje(HistoriaDeUsuario historia) {
        app.modelo.getProyecto().getHistorias();
    }

    public void establecerVotacion(bool votar, int tipoVoto) {
        app.webClient.establecerVotacion(app.modelo.getPartida().getID(), votar, tipoVoto);
    }

    public void estadoVotacion() {
        app.webClient.estadoVotacion(app.modelo.getPartida().getID());
    }

    public void terminarVotacionSprintPlanning() {
        app.vista.panelVotacionSPlanning.terminarVotacion(false);
    }

    public void obtenerVotos(int tipoVotacion) {
        app.webClient.obtenerVotos(app.modelo.getPartida().getID(), tipoVotacion);
    }

    public void mostrarVotosSprintPlanning(int[] historiasID, int[] votos) {
        app.vista.panelVotacionSPlanning.mostrarVotos(historiasID, votos);
    }

    public void terminarVotacionDia() {
        app.vista.panelVotacionDia.terminarVotacion(false);
    }

    public void mostrarVotosDia(int historiaID, int votos) {
        app.vista.panelVotacionDia.mostrarVotos(historiaID, votos);
    }

    public void establecerHistoriaActual(string historiaID) {
        HistoriaDeUsuario historia;
        foreach(HistoriaDeUsuario hist in app.modelo.getProyecto().getHistorias()) {
            if(hist.getID().Equals(historiaID)) {

            }
        }
    }

    public List<string> obtenerProyectos() {
        return app.modelo.getProyectos();
    }

    public void establecerJugadores(List<Jugador> jugadores) {
        app.modelo.setJugadores(jugadores);
    }
    
    public List<Jugador> obtenerJugadores() {
        return app.modelo.getJugadores();
    }

    public Dictionary<string, Sprite> obtenerMapaAvatares() {
        return app.modelo.getMapaAvatares();
    }

    public void pedirJugadores() {
        app.webClient.pedirJugadores(app.modelo.getPartida().getID());
    }

    public void establecerMapaAvatares(Dictionary<string, Sprite> avatares) {
        app.modelo.setMapaAvatares(avatares);
    }
}
