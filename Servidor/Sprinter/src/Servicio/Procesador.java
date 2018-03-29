/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

/**
 *
 * @author EDISON
 */
public class Procesador {
    private Map<Integer, Partida> partidas = new HashMap<>();
    
    /*
    Recibe un String y lo transforma a Json.
    Si el Json está en el formato correcto, se pasa a un Swich case donde se
    determina la acción a ejecutar, dependiendo de un código que se encuentra a
    dentro del mismo Json.
    Los métodos a ejecutar retornan un String en formato Json que será la
    resouesta para el Cliente.
    */
    public String procesarJson(String mensaje){
        JSONParser parser = new JSONParser();
        JSONObject json;
        try {
            json = (JSONObject)parser.parse(mensaje);
        } catch (ParseException ex) {
            json = null;
            Logger.getLogger(ConexionTCP.class.getName()).log(Level.SEVERE, null, ex);
        }
        if(json!=null){
            int pID = (int)json.get("partidaID");
            switch((int)json.get("code")){
                case 1: return terminarSprint(pID);
                case 2: return determinarVictoria(pID);
                case 3: return terminarDia(pID);
            }
        }
        return "";
    }
    
    /*
    Termina el día actual del proyecto.
    Recibe el ID de la partida y obtiene el proyecto correspondiente.
    p.nextDia() incrementa el día actual del proyecto.
    JsonStrings.terminarDia(p) recibe un proyecto y retorna un String en formato
    Json.
    */
    private String terminarDia(int partidaID){
        Proyecto p = partidas.get(partidaID).getProyecto();
        p.nextDia();
        return JsonStrings.terminarDia(p);
    }
    
    /*
    Termina el sprint actual del proyecto.
    Recibe el ID de la partida y obtiene el proyecto correspondiente.
    p.getSprints retorna un ArrayList con todos los sprints del proyecto.
    p.getSprintActual retorna un entero que es el id del sprint actual.
    actual.terminarSprint() cambia un booleano a true que representa un sprint
    terminado.
    p.nextSprint() incrementa el contador de sprints del proyecto.
    JsonStrings.terminarSprint(actual.getSprintBacklog()) recibe un SprintBacklog
    y retorna un String en formato Json.
    */
    private String terminarSprint(int partidaID){
        Proyecto p = partidas.get(partidaID).getProyecto();
        Sprint actual = p.getSprints().get(p.getSprintActual()-1);
        actual.terminarSprint();
        p.nextSprint();
        return JsonStrings.terminarSprint(actual.getSprintBacklog());
    }
    
    /*
    Determina si la partida actual terminó en victoria o derrota.
    Recibe el ID de la partida y obtiene el proyecto correspondiendte.
    p.terminarJuego() analiza las condiciones de victoria y retorna un booleano
    que representa victoria (true) o derrota (false).
    partidas.remove(partidaID) elimina de la lista de partidas en curso la partida
    indicada.
    JsonStrings.determinarVictoria(resultado) recibe un booleano y retorna un
    String en formato Json.
    */
    private String determinarVictoria(int partidaID){
        Proyecto p = partidas.get(partidaID).getProyecto();
        boolean resultado = p.terminarJuego();
        partidas.remove(partidaID);
        return JsonStrings.determinarVictoria(resultado);
    }
    
    
    
    
    
    
    /*
    Crea una partida básica para hacer pruebas.
    Pendiente de terminar.
    */
    public void sembrarPartida(){
        HistoriaDeUsuario huGanada1 = new HistoriaDeUsuario(1, "Descripción HU 1 Ganada");
        HistoriaDeUsuario huGanada2 = new HistoriaDeUsuario(2, "Descripción HU 2 Ganada");
        ProductBacklog productBacklogGanado = new ProductBacklog();
        ArrayList<Sprint> sprintsGanados = new ArrayList<Sprint>();
            SprintBacklog sprintBacklogGanado1 = new SprintBacklog();
                sprintBacklogGanado1.agregarHistoria(huGanada1);
                sprintBacklogGanado1.agregarHistoria(huGanada2);
            Sprint sprintGanado1 = new Sprint(sprintBacklogGanado1, 1);
            sprintsGanados.add(sprintGanado1);
        Proyecto proyectoGanado = new Proyecto(5);
        Partida partidaGanada = new Partida("15600", "Partida de Edison", proyectoGanado);
        partidas.put(123, partidaGanada);
    }
}
