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
 * @author Ricardo Azopardo, Edison Zapata
 */
public class ProcesadorJSON implements IProceso {

    @Override
    public String procesar(Object mensaje) {
        JSONObject json = parseJson(mensaje);
        if(json!=null){
            int pID;
            try{
                //codigoProceso = ;
                pID = Integer.valueOf(json.get("partidaID").toString());
            }catch(Exception ex){
                pID = 0;
            }
            //Main.getControlador().controlar(json);
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
                case 8:
                    String nombreJugador = (String)json.get("nombreJugador");
                    return Main.getControlador().unirsePartida(pID,
                            nombreJugador);
                case 9:  
                    int jugador = (int)(long)json.get("player");
                    return Main.getControlador().actualizarEstadoJugador(pID,
                            jugador);
                case 10: 
                    int idHU = (int)(long)json.get("HUid");
                    int playerId = (int)(long)json.get("player");
                    Main.getControlador().registrarVoto(pID, idHU, playerId);
                    break;
                case 11:
                    boolean votar = json.get("votar").equals("True");
                    int tipoVoto = (int)(long)json.get("tipoVoto");
                    Main.getControlador().establecerVotación(pID,votar,
                            tipoVoto);
                    break;
                case 12: 
                    return Main.getControlador().estadoVotacion(pID);
                case 13:
                    int tipoVotacion = (int)(long)json.get("tipoVotacion");
                    return Main.getControlador().enviarVotos(pID, tipoVotacion);
                case 14: 
                    return Main.getControlador().enviarProyectos();
                case 15:
                    String scrumMaster = (String) json.get("jugador");
                    String partida = (String) json.get("partida");
                    String proyecto = (String) json.get("proyecto");
                    return Main.getControlador().crearPartida(scrumMaster,
                            partida, proyecto);
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


