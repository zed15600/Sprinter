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
    
    protected static String determinarVictoria(boolean resultado){
        String res = "{"
                + "\"codigo\":0002, "
                + "\"resultado\":\""+(resultado?"Victoria":"Derrota")+"\""
                + "}";
        return res;
    }
    
}
