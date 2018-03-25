/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.HistoriaDeUsuario;
import Negocio.SprintBacklog;
import java.util.ArrayList;

/**
 *
 * @author EDISON
 */
public class JsonStrings {
    
    protected static String terminarSprint(SprintBacklog sprntBcklg){
        ArrayList<HistoriaDeUsuario> historias = sprntBcklg.getHUs();
        String HUs = "{\"HUs\":\"{";
        for(int i=0; i<historias.size(); i++){
            if(historias.get(i).getEstado())
                HUs += "\""+(i+1)+"\":\""+historias.get(i).getPuntuacion()+"\", ";
        }
        HUs += "}\"}";
        return HUs;
    }
    
}
