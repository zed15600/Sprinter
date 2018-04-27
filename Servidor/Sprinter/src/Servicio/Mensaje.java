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
    protected static String terminarSprint(SprintBacklog sprntBcklg){
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
    
    protected static String traerHU(String descripcion, String puntos, String prioridad,
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
    
    protected static String unirsePartida(int partidaID, int jugadorId, boolean aceptado){
        String res = "{"
                + "\"codigo\":0007,"
                + "\"pId\":"+partidaID+","
                + "\"jugadorId\":"+jugadorId+""
                + "}";
        return res;
    }
}
