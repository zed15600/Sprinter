/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import java.util.logging.Level;
import java.util.logging.Logger;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

/**
 *
 * @author usuario
 */
public class ProcesadorJSON implements IProceso {

    @Override
    public String procesar(Object mensaje) {
        JSONObject json = parseJson(mensaje);
        if(json!=null){
            int pID;
            try{
                pID = Integer.valueOf(json.get("partidaID").toString());
            }catch(Exception ex){
                pID = 0;
            }
            switch(Integer.valueOf(json.get("codigo").toString())){
                case 1:  Main.getControlador().terminarSprint(pID);
                        break;
                case 2:  return Main.getControlador().determinarVictoria(pID);
                case 4:  return Main.getControlador().enviarProyecto(pID);
                case 6:  return Main.getControlador().sprintPlanning(pID);
                case 7:  
                    String nombre = (String)json.get("nombre");
                    Main.getControlador().establecerCompletada(pID, nombre);
                    break;
                case 8:  return Main.getControlador().unirsePartida((int)(long)json.get("partCode"), (String)json.get("nombreJugador"));
                case 9:  return Main.getControlador().actualizarEstadoJugador(pID, (int)(long)json.get("player"));
                case 10: Main.getControlador().registrarVoto(pID, (int)(long)json.get("HUid"), (int)(long)json.get("player"));
                    break;
                case 11: Main.getControlador().establecerVotación(pID, json.get("votar").equals("True"), (int)(long)json.get("tipoVoto"));
                    break;
                case 12: return Main.getControlador().estadoVotacion(pID);
                case 13: return Main.getControlador().enviarVotos(pID, (int)(long)json.get("tipoVotacion"));
                case 14: return Main.getControlador().enviarProyectos();
                case 15:
                    String jugador = (String) json.get("jugador");
                    String partida = (String) json.get("partida");
                    String proyecto = (String) json.get("proyecto");
                    return Main.getControlador().crearPartida(jugador, partida, proyecto);
                case 16:
                    return Main.getControlador().enviarJugadores(pID);
            }
        }
        return "";
    }
    
    public JSONObject parseJson(Object mensaje){
        String jMensaje = (String)mensaje;
        JSONParser parser = new JSONParser();
        JSONObject json;
        try {
            json = (JSONObject)parser.parse(jMensaje);
        } catch (ParseException ex) {
            json = null;
            Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex);
        }
        return json;
    }
}


