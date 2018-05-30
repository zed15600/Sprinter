/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio.Mensajes;

import Servicio.ElementosConexión.IProceso;
import Servicio.Main;
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
                case 3:  return Main.getControlador().terminarDia(pID);
                case 4:  return Main.getControlador().enviarProyecto(pID);
                case 6:  return Main.getControlador().sprintPlanning(pID);
                case 7:  
                    String nombre = (String)json.get("nombre");
                    int puntos = (Integer)json.get("puntos");
                    Main.getControlador().establecerCompletada(pID, nombre,puntos);
                    break;
                case 8:
                    String nombreJugador = (String)json.get("nombreJugador");
                    String deviceIDi = (String)json.get("deviceID");
                    return Main.getControlador().unirsePartida(pID,
                            nombreJugador, deviceIDi);
                case 9:  
                    int jugador = (int)(long)json.get("player");
                    return Main.getControlador().actualizarEstadoJugador(pID,
                            jugador);
                case 10: 
                    String HUNombre = (String)json.get("HUNombre");
                    int playerId = (int)(long)json.get("player");
                    Main.getControlador().registrarVoto(pID, HUNombre, playerId);
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
                    return Main.getControlador().enviarVotos(pID);
                case 14: 
                    return Main.getControlador().enviarProyectos();
                case 15:
                    String scrumMaster = (String) json.get("jugador");
                    String deviceIDm = (String)json.get("deviceID");
                    String partida = (String) json.get("partida");
                    String proyecto = (String) json.get("proyecto");
                    return Main.getControlador().crearPartida(scrumMaster,
                            deviceIDm, partida, proyecto);
                case 16:
                    return Main.getControlador().enviarJugadores(pID);
                case 17:
                    Main.getControlador().empezarPartida(pID);
                    break;
                case 18:
                    return Main.getControlador().empezarEncuesta(pID);
                case 19:
                    return Main.getControlador().siguientePregunta(pID);
                case 20:
                    int player = (int)(long)json.get("player");
                    String opcion = (String)json.get("opcion");
                    return Main.getControlador().registrarRespuesta(pID, player, opcion);
                case 21:
                    Main.getControlador().enviarDatosDePartida(pID);
                    break;
                case 22:
                    String resultado = (String)json.get("resultado");
                    Main.getControlador().actualizarEstadoPartida(pID, resultado);
                    break;
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


