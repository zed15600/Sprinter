/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Entidades.Criterio;
import Negocio.Entidades.HistoriaDeUsuario;
import Negocio.Entidades.Proyecto;
import Negocio.Entidades.SprintBacklog;
import Negocio.Procesos.IMensajes;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class ImplMensajes implements IMensajes {

    @Override
    public String terminarDia(Proyecto p) {
        return null;
        /*return Mensaje.terminarDia(p);*/
    }

    @Override
    public String terminarSprint(SprintBacklog sprntBcklg) {
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

    @Override
    public String enviarHU(String descripcion, String puntos, String prioridad, ArrayList<Criterio> criterios,
    boolean estado) {
        return Mensaje.traerHU(descripcion, puntos, prioridad, criterios, estado);
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
    public String unirsePartida(int partidaID, int jugadorId, boolean aceptado){
        return Mensaje.unirsePartida(partidaID, jugadorId, aceptado);
    }
    
    @Override
    public String actualizarEstadoJugador(boolean votar, HistoriaDeUsuario[] posibles){
        return Mensaje.actualizarEstadoJugador(votar, posibles);
    }
}
