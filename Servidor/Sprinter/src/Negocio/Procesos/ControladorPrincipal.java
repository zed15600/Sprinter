/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Modelo.Configuracion;
import java.util.Map;

/**
 *
 * @author EDISON
 */
public class ControladorPrincipal {
    private final IConexion conexion;
    private final ControladorJugador controladorJugadores;
    private final ControladorProyecto controladorProyectos;
    private final ControladorPartida controladorPartidas;
    private final ControladorEncuesta controladorEncuesta;
    
    public ControladorPrincipal(IMensajes respuestas, IConexion conexion, 
    Configuracion configuracion) {
        this.controladorJugadores = new ControladorJugador(respuestas,
                configuracion);
        this.controladorProyectos = new ControladorProyecto(respuestas,
                configuracion);
        this.controladorPartidas = new ControladorPartida(respuestas,
                configuracion);
        this.controladorEncuesta = new ControladorEncuesta(respuestas,
                configuracion);
        this.conexion = conexion;
    }
    
    public void conectar(){
        conexion.conectar();
    }
    
    /*public void controlar(Map datos){
        String codigo = datos.get((Object)"codigo").toString();
        //System.out.println("ControladorPrincipal.controlar() -> Código: " + codigo);
    }*/
    
    public void terminarSprint(int partidaID){
        controladorProyectos.terminarSprint(partidaID);
    }
    
    public String determinarVictoria(int partidaID){
        return controladorPartidas.determinarVictoria(partidaID);
    }
    
    public String enviarProyecto(int partidaID){
        return controladorProyectos.enviarProyecto(partidaID);
    }
    
    public String sprintPlanning(int partidaID){
        return controladorProyectos.sprintPlanning(partidaID);
    }
    
    public void establecerCompletada(int partidaID, String nombreHistoria, int puntos) {
        controladorProyectos.establecerCompletada(partidaID, nombreHistoria, puntos);
    }
    
    public String unirsePartida(int codigo, String nombreJugador, 
            String deviceID){
        return controladorJugadores.unirsePartida(codigo, nombreJugador, 
                deviceID);
    }
    
    public String actualizarEstadoJugador(int partidaID, int jugador){
        return controladorJugadores.actualizarEstadoJugador(partidaID, jugador);     
    }
    
    public void registrarVoto(int partidaID, String historiaNombre, int jugador){
        controladorJugadores.registrarVoto(partidaID, historiaNombre, jugador);
    }
    
    public void establecerVotación(int partidaID, boolean votar, int tipo){
        controladorPartidas.establecerVotacion(partidaID, votar, tipo);
    }
    
    public String estadoVotacion(int partidaID){
        return controladorPartidas.estadoVotacion(partidaID);
    }
    
    public String enviarVotos(int partidaID){
        return controladorPartidas.enviarVotos(partidaID);
    }
    
    public String enviarProyectos(){
        return controladorProyectos.enviarProyectos();
    }
    
    public String crearPartida(String jugador, String deviceID, String partida, 
            String proyecto){
        return controladorPartidas.crearPartida(jugador, deviceID, partida, proyecto);
    }

    public String enviarJugadores(int idPartida) {
        return controladorPartidas.enviarJugadores(idPartida);
    }
    
    public void empezarPartida(int partidaID){
        controladorPartidas.empezarPartida(partidaID);
    }
    
    public String terminarDia(int partidaID){
        return controladorPartidas.terminarDia(partidaID);
    }
    
    public String empezarEncuesta(int partidaID){
        return controladorEncuesta.empezarEncuesta(partidaID);
    }
    
    public String siguientePregunta(int partidaID){
        return controladorEncuesta.siguientePregunta(partidaID);
    }
    
    public String registrarRespuesta(int partidaID, int jugador, String respuesta){
        return controladorEncuesta.registrarRespuesta(partidaID, jugador, respuesta);
    }
    
    public void enviarDatosDePartida(int partidaID){
        controladorPartidas.enviarDatosDePartida(partidaID);
    }
    
    public void actualizarEstadoPartida(int pID, String estado){
        controladorPartidas.actualizarEstadoPartida(pID, estado);
    }
    
}
