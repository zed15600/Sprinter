using System.Collections.Generic;
using UnityEngine;

public class ClienteControlador : ClientElement {

    public ClienteModelo modelo;
    public ClienteVista vista;
    public WebClient webClient;

    public void pedirProyectos() {
        webClient.pedirProyectos();
    }

    public void crearPartida(string jugador, string partida, string proyecto) {
        webClient.crearPartida(jugador, partida, proyecto);
    }

    public void obtenerProyectoServidor() {
        webClient.obtenerProyecto();
    }
    
    public Proyecto obtenerProyecto() {
        return modelo.getProyecto();
    }

    public string obtenerNombreProyecto() {
        return modelo.getProyecto().getNombre();
    }

    public string obtenerDescripcionProyecto(){
        return modelo.getProyecto().getDescripcion();
    }

    public List<HistoriaDeUsuario> obtenerHistorias(){
        return modelo.getProyecto().getHistorias();
    }

    public List<HistoriaDeUsuario> obtenerHistoriasSprint() {
        return modelo.getProyecto().getHistoriasSprint();
    }

    public void establecerHistoriasSprint(List<HistoriaDeUsuario> historias) {
        modelo.getProyecto().setHistoriasSprint(historias);
    }

    internal string obtenerCodigoPartida() {
        return modelo.getPartida().getID();
    }

    public string obtenerSprintsRestantes(){
        return modelo.getProyecto().getRestantes().ToString();
    }

    public string obtenerActual(){
        return modelo.getProyecto().getSprintActual().ToString();
    }

    public string obtenerHistoriaMinijuego() {
        return modelo.getMinijuego().getHistoriaActual().getDescripcion();   
    }

    public List<string> obtenerCriteriosMinijuego(){
        return modelo.getMinijuego().getHistoriaActual().getCriterios();
    }

    public void eliminarCriterioMinijuego(int indice){
        modelo.getMinijuego().eliminarCriterio(indice);
    }

    public void cambiarEstado(HistoriaDeUsuario historia){
        historia.cambiarEstado();
        webClient.establecerCompletada(historia.getID());
    }

    public int obtenerPuntosHMinijuego(){
        int puntos = 0;
        puntos = int.Parse(modelo.getMinijuego().getHistoriaActual().getPuntos());
        return puntos;
    }

    public int obtenerPrioridadMinijuego(){
        int prioridad = 0;
        prioridad = int.Parse(modelo.getMinijuego().getHistoriaActual().getPrioridad());
        return prioridad;
    }

    public void establecerTiempo(float tiempo){
        modelo.getMinijuego().setTiempoFinal(tiempo);
    }

    public float obtenerTiempoFinal(){
        float tiempoFinal = 0;
        tiempoFinal = modelo.getMinijuego().getTiempoFinal();
        return tiempoFinal;
    }

    public int obtenerIntentos(){
        return modelo.getMinijuego().getIntentos();
    }

    public void resetearIntentos() {
        modelo.getMinijuego().resetearIntentos();
    }

    public void aumentarIntento() {
        modelo.getMinijuego().aumentarIntentos();
    }

    public void obtenerPuntaje(HistoriaDeUsuario historia) {
        modelo.getProyecto().getHistorias();
    }

    public void establecerVotacion(bool votar, int tipoVoto) {
        webClient.establecerVotacion(modelo.getPartida().getID(), votar, tipoVoto);
    }

    public void estadoVotacion() {
        webClient.estadoVotacion(modelo.getPartida().getID());
    }

    public void terminarVotacionSprintPlanning() {
        vista.panelVotacionSPlanning.terminarVotacion(false);
    }

    public void obtenerVotos(int tipoVotacion) {
        webClient.obtenerVotos(modelo.getPartida().getID(), tipoVotacion);
    }

    public void mostrarVotosSprintPlanning(string[] historiasID, int[] votos) {
        vista.panelVotacionSPlanning.mostrarVotos(historiasID, votos);
    }

    public void terminarVotacionDia() {
        vista.panelVotacionDia.terminarVotacion(false);
    }

    public void mostrarVotosDia(string[] historiaID, int[] votos) {
        vista.panelVotacionDia.mostrarVotos(historiaID, votos);
    }

    public void establecerHistoriaActual(string historiaID) {
        foreach(HistoriaDeUsuario historia in modelo.getProyecto().getHistorias()) {
            if(historia.getID().Equals(historiaID)) {
                modelo.getMinijuego().setHistoriaActual(historia);
                return;
            }
        }
    }

    public List<string> obtenerProyectos() {
        return modelo.getProyectos();
    }

    public void establecerJugadores(List<Jugador> jugadores) {
        modelo.setJugadores(jugadores);
    }
    
    public List<Jugador> obtenerJugadores() {
        return modelo.getJugadores();
    }

    public Dictionary<string, Sprite> obtenerMapaAvatares() {
        return modelo.getMapaAvatares();
    }

    public void pedirJugadores() {
        webClient.pedirJugadores(modelo.getPartida().getID());
    }


    //Aquí inician las llamadas a Modelo

    public void setProyectos(List<string> nombres) {
        modelo.setProyectos(nombres);
    }

    public void setPartida(Partida partida) {
        modelo.setPartida(partida);
    }

    public void establecerProyecto(Proyecto proyecto) {
        modelo.setProyecto(proyecto);
    }

    public void establecerMapaAvatares(Dictionary<string, Sprite> avatares) {
        modelo.setMapaAvatares(avatares);
    }

    public Partida obtenerPartida() {
        return modelo.getPartida();
    }

    public Minijuego obtenerMinijuego() {
        return modelo.getMinijuego();
    }

    public void terminarDia() {
        if(modelo.getProyecto().terminarDia()){
            iniciarNuevoDia();
        } else {
            terminarSprint();
        }
    }



    //Aquí inician las llamadas a Vista

    public void iniciarNuevoDia() {
        vista.vistaSprint.gameObject.SetActive(true);
    }

    public void terminarSprint() {
        vista.retrospectiva.gameObject.SetActive(true);
    }

    /*public void iniciarNuevoSprint() {
        vista.vistaSprint.gameObject.SetActive(true);
    }

    public void terminarJuego() {
        vista.finDelJuego.gameObject.SetActive(true);
    }*/
}
