/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Configuracion;
import Negocio.Entidades.IntegranteScrumTeam;
import Negocio.Entidades.Partida;
import Negocio.Entidades.Proyecto;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class ControladorPartida extends Controlador {
    
    public ControladorPartida(IMensajes respuestas,Configuracion configuracion){
        super(respuestas, configuracion);
    }
    
    public String determinarVictoria(int partidaID){
        Proyecto p = configuracion.obtenerProyectoDePartida(partidaID);
        boolean resultado = p.terminarJuego();
        configuracion.quitarPartida(partidaID);
        return respuestas.determinarVictoria(resultado);
    }

    public void establecerVotacion(int partidaID, boolean votar, int tipo) {
        Partida p = configuracion.obtenerPartida(partidaID);
        if(votar){
            p.reiniciarVotaciones();
        }
        p.setVotacion(votar);
        p.setTipoVotación(tipo);
    }

    public String estadoVotacion(int partidaID) {
        Partida p = configuracion.obtenerPartida(partidaID);
        return respuestas.estadoVotacion(p.getVotacion(), p.getTipoVotacion());
    }
    
    public String enviarVotos(int partidaID, int tipoVotacion){
        Proyecto p = configuracion.obtenerProyectoDePartida(partidaID);
        int respuestasVotos = 0;
        if(tipoVotacion == 1){
            respuestasVotos = p.getDuracionDeSprints();
        }
        if(tipoVotacion == 2){
            respuestasVotos = 1;
        }
        return this.respuestas.enviarVotos(p.getVotos(respuestasVotos, 
                configuracion.obtenerPartida(partidaID).getTipoVotacion()));
    }

    public String crearPartida(String jugador, String partida, String proyecto) {
        String codigo = configuracion.crearPartida(jugador, partida, proyecto);
        return respuestas.enviarCodigoPartida(codigo);
    }

    public String enviarJugadores(int idPartida) {
        Partida p = configuracion.obtenerPartida(idPartida);
        ArrayList<IntegranteScrumTeam> jugadores= p.getListaJugadores();
        return respuestas.enviarJugadoresConAvatares(jugadores);
    }
    
    public void empezarPartida(int partidaID){
        Partida p = configuracion.obtenerPartida(partidaID);
        p.setEstado("iniciada");
    }
    
}
