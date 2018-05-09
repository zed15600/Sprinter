/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Procesos.IConexion;
import Negocio.Procesos.Proceso;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import Negocio.Procesos.IMensajes;
import org.json.simple.JSONArray;

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
        IConexion conexion = new ConexionTCP();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        Proceso proceso = new Proceso(mensajes, conexion);
        JSONParser parser = new JSONParser();
        JSONObject json;
        try {
            json = (JSONObject)parser.parse(mensaje);
        } catch (ParseException ex) {
            json = null;
            Logger.getLogger(ConexionTCP.class.getName()).log(Level.SEVERE, null, ex);
        }
        if(json!=null){
            int pID;
            try{
                pID = Integer.valueOf(json.get("partidaID").toString());
            }catch(Exception ex){
                pID = 0;
            }
            switch(Integer.valueOf(json.get("codigo").toString())){
                case 1:  return proceso.terminarSprint(pID);
                case 2:  return proceso.determinarVictoria(pID);
                case 3:  return proceso.terminarDia(pID);
                case 4:  return proceso.enviarProyecto(pID);
                case 5:  return proceso.enviarHistoria(pID, (String)json.get("ID"));
                case 6:  return proceso.sprintPlanning(pID);
                case 7:  proceso.establecerCompletada(pID, (String)json.get("ID"));
                    break;
                case 8:  return proceso.unirsePartida((int)(long)json.get("partCode"), (String)json.get("nombreJugador"));
                case 9:  return proceso.actualizarEstadoJugador(pID, (int)(long)json.get("player"));
                case 10: proceso.registrarVoto(pID, (int)(long)json.get("HUid"), (int)(long)json.get("player"));
                    break;
                case 11: proceso.establecerVotación(pID, json.get("votar").equals("True"), (int)(long)json.get("tipoVoto"));
                    break;
                case 12: return proceso.estadoVotacion(pID);
                case 13: return proceso.enviarVotos(pID, (int)(long)json.get("tipoVotacion"));
                case 14: return proceso.enviarProyectos();
                case 15:
                    String jugador = (String) json.get("jugador");
                    String partida = (String) json.get("partida");
                    String proyecto = (String) json.get("proyecto");
                    return proceso.crearPartida(jugador, partida, proyecto);
                case 16:
                    return proceso.enviarJugadores(pID);
            }
        }
        return "";
    }
}