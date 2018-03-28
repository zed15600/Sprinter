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
    private Map<Integer, Partida> partidas = new HashMap<Integer, Partida>();
    
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
    
    private String terminarDia(int partidaID){
        Proyecto p = partidas.get(partidaID).getProyecto();
        p.nextDia();
        return JsonStrings.terminarDia(p);
    }
    
    private String terminarSprint(int partidaID){
        Proyecto p = partidas.get(partidaID).getProyecto();
        Sprint actual = p.getSprints().get(p.getSprintActual());
        actual.terminarSprint();
        p.nextSprint();
        return JsonStrings.terminarSprint(actual.getSprintBacklog());
    }
    
    private String determinarVictoria(int partidaID){
        Proyecto p = partidas.get(partidaID).getProyecto();
        boolean resultado = p.terminarJuego();
        partidas.remove(partidaID);
        return JsonStrings.determinarVictoria(resultado);
    }
    
    
    
    
    
    
    public void sembrarPartida(){
        HistoriaDeUsuario huGanada1 = new HistoriaDeUsuario("Descripción HU 1 Ganada");
        HistoriaDeUsuario huGanada2 = new HistoriaDeUsuario("Descripción HU 2 Ganada");
        ProductBacklog productBacklogGanado = new ProductBacklog();
        ArrayList<Sprint> sprintsGanados = new ArrayList<Sprint>();
            SprintBacklog sprintBacklogGanado1 = new SprintBacklog();
                sprintBacklogGanado1.agregarHistoria(huGanada1);
                sprintBacklogGanado1.agregarHistoria(huGanada2);
            Sprint sprintGanado1 = new Sprint(sprintBacklogGanado1, 5, "1");
            sprintsGanados.add(sprintGanado1);
        Proyecto proyectoGanado = new Proyecto(5);
        Partida partidaGanada = new Partida("15600", "Partida de Edison", proyectoGanado);
        partidas.put(123, partidaGanada);
    }
}
