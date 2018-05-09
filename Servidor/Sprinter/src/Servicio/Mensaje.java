/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Entidades.Criterio;
import Negocio.Entidades.HistoriaDeUsuario;
import Negocio.Entidades.Proyecto;
import Negocio.Entidades.Backlog;
import Negocio.Entidades.IntegranteScrumTeam;
import Negocio.Entidades.Jugador;
import java.util.ArrayList;

/**
 *
 * @author EDISON
 */
public class Mensaje {
    
    /*
    Recibe un Proyecto y retorna un String con el código para la vista Sprint, 
    el sprint actual, el día actual del proyecto y una lista con los identificadores
    de las historias de usaurio correspondientes, en formato Json.
    */
    protected static String terminarDia(Proyecto p){
        String res = "{\"codigo\":0003, "
                + "\"sprintActual\":"+p.getSprintActual()+", "
                + "\"diaActual\""+p.getDiaActual()+", "
                + "\"HUs\":{";
        ArrayList<HistoriaDeUsuario> historias = p.getSprints().get(p.getSprintActual()).getSprintBacklog().getHistorias();
        for(int i=0; i<historias.size(); i++){
            res += "\""+(i+1)+"\":"+historias.get(i).getId()+", ";
        }
        res += "}\"}";
        return res;
    }
    
    
    /*
    Recibe un SprintBacklog y retorna un String con el código para la vista 
    Retrospectiva y una lista con los identificadores de las historias de usuario,
    en formato Json.
    */
    protected static String terminarSprint(Backlog sprntBcklg){
        ArrayList<HistoriaDeUsuario> historias = sprntBcklg.getHistorias();
        String HUs = "{\"codigo\":0001, "
                + " \"HUs\":\"{";
        for(int i=0; i<historias.size(); i++){
            if(historias.get(i).getEstado()){
                HUs += "\""+(i+1)+"\":"+historias.get(i).getPuntuacion()+", ";
            }
        }
        HUs += "}\"}";
        return HUs;
    }
    
    /*
    Recibe un booleano y retorna un String con el código para la vista Fin del 
    Juego y el resultado de la partida (Victoria o Derrota), en formato Json.
    */
    protected static String determinarVictoria(boolean resultado){
        String res = "{"
                + "\"codigo\":0002, "
                + "\"resultado\":\""+(resultado?"Victoria":"Derrota")+"\""
                + "}";
        return res;
    }

    /**
     * Retorna el String en formato Json con los datos del proyecto: nombre y descripcion.
     * @param nombre nombre del proyecto.
     * @param descripcion descripcion del proyecto.
     * @param HUs
     * @return string en formato Json con el codigo 0004 para la vista de Scrum Planning.
     */
    protected static String traerProyecto(String nombre, String descripcion, 
            ArrayList<HistoriaDeUsuario> HUs) {
        String res = "{"
                + "\"codigo\":0004, "
                + "\"nombre\":\""+nombre+"\","
                + "\"descripcion\":\""+descripcion+"\", "
                                + " \"HUs\":[";
        for(int i=0; i<HUs.size(); i++){
                res += "\""+HUs.get(i).getId()+"\", ";
        }
        return res += "]}";
    }
    
    protected static String traerHU(String descripcion, String puntos, int prioridad,
    ArrayList<Criterio> criterios, boolean estado){
        String res = "{"
                + "\"codigo\":0005, "
                + "\"descripcion\":\""+descripcion+"\","
                + "\"puntos\":\""+puntos+"\","
                + "\"estado\":"+estado+","
                + "\"prioridad\":\""+prioridad+"\","
                                + " \"criterios\":[";
        for(int i=0; i<criterios.size(); i++){
                res += "\""+criterios.get(i).getDescripcion() +"\", ";
        }
        return res += "]}";
    }
    
    protected static String sprintPlanning(int sprintsRestantes, int numeroDeSprint){
        String res = "{"
                +   "\"codigo\":0006, "
                +   "\"restantes\":"+sprintsRestantes+","
                +   "\"numero\":"+numeroDeSprint+"}";
        return res;
    }
    
    protected static String unirsePartida(int jugadorId, boolean aceptado, String avatar){
        String res = "{"
                + "\"jugadorId\":"+jugadorId+","
                + "\"aceptado\":"+aceptado+","
                + "\"avatar\":\""+avatar+"\""
                + "}";
        return res;
    }
    
    protected static String actualizarEstadoJugador(boolean votar, HistoriaDeUsuario[] posibles){
        String HUsID = "[";
        String HUsDesc = "[";
        for (HistoriaDeUsuario posible : posibles) {
            HUsID += posible.getId() + ",";
            HUsDesc += "\"" + posible.getDescripcion() + "\",";
        }
        //System.out.println("Mensaje.actualziarEstadoJugador() -> cantidad de historias para votar: "+posibles.length);
        HUsID = posibles.length!=0?HUsID.substring(0, HUsID.length()-1) + "]":"[]";
        HUsDesc = posibles.length!=0?HUsDesc.substring(0, HUsDesc.length()-1) + "]":"[]";
        String res = "{"
                   + "\"votacion\":"+votar+","
                   + "\"HUs\":"+HUsID+","
                   + "\"HUsDesc\":"+HUsDesc+""
                   + "}";
        return res;
    }
    
    protected static String estadoVotacion(boolean votamos, int tipoVotacion){
        String res = "{"
                   + "\"votamos\":"+votamos+","
                   + "\"tipoVotacion\":"+tipoVotacion
                   + "}";
        return res;
    }
    
    protected static String enviarVotos(String[][] listaVotos){
        String hID = "[";
        String votos = "[";
        for(int i=0; i<listaVotos[0].length; i++){
            hID += "\""+listaVotos[0][i]+"\",";
            votos += listaVotos[1][i]+",";
        }
        hID = hID.substring(0, hID.length()-1)+"]";
        votos = votos.substring(0, votos.length()-1)+"]";
        String res = "{"
                + "\"historiasID\":"+hID+","
                + "\"votos\":"+votos
                + "}";
        return res;
    }

    protected static String enviarNombresProyectos() {
        String json = "{";
        ArrayList<Proyecto> proyectos = ConexionTCP.getProceso().getConexion().obtenerConfiguracion().getListaDeProyectos();
        json += "\"proyectos\":[";
        for (Proyecto p:proyectos){
            json += "\""+p.getNombre() +"\", ";
        }
        return json += "]}";
    }

    protected static String enviarCodigoPartida(String id) {
        return "{\"id\":\""+id+"\"}";
    }

    protected static String enviarJugadoresConAvatares(ArrayList<IntegranteScrumTeam> jugadores) {
        String json = "{";
        json += "\"jugadores\":[";
        for (Jugador j:jugadores){
            json += "\""+j.getNombre() +"\", ";
        }
        json += "],";
        json += "\"avatares\":[";
        for (IntegranteScrumTeam j:jugadores){
            json += "\""+j.getAvatar()+"\", ";
        }
        return json += "]}";
    }
}
