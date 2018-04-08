/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Procesos.Proceso;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import Negocio.Procesos.IMensajes;

/**
 *
 * @author usuario
 */
public class Procesador {
    
    /*
    Recibe un String y lo transforma a Json.
    Si el Json está en el formato correcto, se pasa a un Swich case donde se
    determina la acción a ejecutar, dependiendo de un código que se encuentra a
    dentro del mismo Json.
    Los métodos a ejecutar retornan un String en formato Json que será la
    resouesta para el Cliente.
    */
    public String procesarJson(String mensaje){
        IMensajes mensajes = new ImplMensajes();
        Proceso proceso = new Proceso(mensajes);
        JSONParser parser = new JSONParser();
        JSONObject json;
        try {
            json = (JSONObject)parser.parse(mensaje);
        } catch (ParseException ex) {
            json = null;
            Logger.getLogger(ConexionTCP.class.getName()).log(Level.SEVERE, null, ex);
        }
        if(json!=null){
            int pID = Integer.valueOf(json.get("partidaID").toString());
            switch(Integer.valueOf(json.get("codigo").toString())){
                case 1: return proceso.terminarSprint(pID);
                case 2: return proceso.determinarVictoria(pID);
                case 3: return proceso.terminarDia(pID);
                case 4: return proceso.enviarProyecto(pID);
                case 5:
                    String hID = (String)json.get("ID");
                    return proceso.enviarHistoria(pID, hID);
            }
        }
        return "";
    }
}
