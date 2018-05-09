/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Entidades.HistoriaDeUsuario;
import Negocio.Entidades.Backlog;
import Negocio.Entidades.IntegranteScrumTeam;
import Negocio.Procesos.IMensajes;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class ImplMensajes implements IMensajes {

    @Override
    public String terminarSprint(Backlog sprntBcklg) {
        return null;
        /*return Mensaje.terminarSprint(sprntBcklg);*/
    }

    @Override
    public String determinarVictoria(boolean resultado) {
        return Mensaje.determinarVictoria(resultado);
    }
    
    @Override
    public String traerProyecto(String nombre, String descripcion,
            ArrayList<HistoriaDeUsuario> historias) {
        return Mensaje.traerProyecto(nombre, descripcion, historias);
    }
    
    /**
     * 
     * @param sprintsRestantes 
     * @param numeroDeSprint
     * @return 
     */
    @Override
    public String sprintPlanning(int sprintsRestantes, int numeroDeSprint) {
        return Mensaje.sprintPlanning(sprintsRestantes, numeroDeSprint);
    }
    
    @Override
    public String unirsePartida(int jugadorId, boolean aceptado, String avatar){
        return Mensaje.unirsePartida(jugadorId, aceptado, avatar);
    }
    
    @Override
    public String actualizarEstadoJugador(boolean votar, HistoriaDeUsuario[] posibles){
        return Mensaje.actualizarEstadoJugador(votar, posibles);
    }
    
    @Override
    public String estadoVotacion(boolean votamos, int tipoVoto){
        return Mensaje.estadoVotacion(votamos, tipoVoto);
    }

    @Override
    public String enviarVotos(String[][] listaVotos) {
        return Mensaje.enviarVotos(listaVotos);
    }

    @Override
    public String enviarNombresProyectos() {
        return Mensaje.enviarNombresProyectos();
    }

    @Override
    public String enviarCodigoPartida(int codigo) {
        String id = String.valueOf(codigo);
        return Mensaje.enviarCodigoPartida(id);
    }

    @Override
    public String enviarJugadoresConAvatares(ArrayList<IntegranteScrumTeam> jugadores) {
        return Mensaje.enviarJugadoresConAvatares(jugadores);
    }
}
