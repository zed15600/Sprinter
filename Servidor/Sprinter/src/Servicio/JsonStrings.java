/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.HistoriaDeUsuario;
import Negocio.Proyecto;
import Negocio.SprintBacklog;
import java.util.ArrayList;

/**
 *
 * @author EDISON
 */
public class JsonStrings {
    
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
        ArrayList<HistoriaDeUsuario> historias = p.getSprints().get(p.getSprintActual()).getSprintBacklog().getHUs();
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
        ArrayList<HistoriaDeUsuario> historias = sprntBcklg.getHUs();
        String HUs = "{\"codigo\":0001, "
                + " \"HUs\":\"{";
        for(int i=0; i<historias.size(); i++){
            if(historias.get(i).getEstado())
                HUs += "\""+(i+1)+"\":"+historias.get(i).getPuntuacion()+", ";
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
     * @return string en formato Json con el codigo 0004 para la vista de Scrum Planning.
     */
    protected static String scrumPlanning(String nombre, String descripcion) {
        String res = "{"
                + "\"codigo\":0004, "
                + "\"nombre\":\""+nombre+"\","
                + "\"descripcion\":\""+descripcion+"\""
                + "}";
        return res;
    }
    
}
