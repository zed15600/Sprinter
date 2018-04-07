/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Sprint;
import Negocio.Entidades.SprintBacklog;
import Negocio.Entidades.Proyecto;
import Negocio.Entidades.ProductBacklog;
import Negocio.Entidades.HistoriaDeUsuario;
import Negocio.Entidades.Partida;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author EDISON
 */
public class Proceso {
    private final IMensajes mensajes;
    private static Map<Integer, Partida> partidas = new HashMap<>();

    public Proceso(IMensajes mensajes) {
        this.mensajes = mensajes;
    }
    
    
    /*
    Termina el día actual del proyecto.
    Recibe el ID de la partida y obtiene el proyecto correspondiente.
    p.nextDia() incrementa el día actual del proyecto.
    JsonString.terminarDia(p) recibe un proyecto y retorna un String en formato
    Json.
    */
    public String terminarDia(int partidaID){
        Proyecto p = partidas.get(partidaID).getProyecto();
        p.nextDia();
        return mensajes.terminarDia(p);
    }
    
    /*
    Termina el sprint actual del proyecto.
    Recibe el ID de la partida y obtiene el proyecto correspondiente.
    p.getSprints retorna un ArrayList con todos los sprints del proyecto.
    p.getSprintActual retorna un entero que es el id del sprint actual.
    actual.terminarSprint() cambia un booleano a true que representa un sprint
    terminado.
    p.nextSprint() incrementa el contador de sprints del proyecto.
    JsonString.terminarSprint(actual.getSprintBacklog()) recibe un SprintBacklog
    y retorna un String en formato Json.
    */
    public String terminarSprint(int partidaID){
        Proyecto p = partidas.get(partidaID).getProyecto();
        Sprint actual = p.getSprints().get(p.getSprintActual()-1);
        actual.terminarSprint();
        p.nextSprint();
        return mensajes.terminarSprint(actual.getSprintBacklog());
    }
    
    /*
    Determina si la partida actual terminó en victoria o derrota.
    Recibe el ID de la partida y obtiene el proyecto correspondiendte.
    p.terminarJuego() analiza las condiciones de victoria y retorna un booleano
    que representa victoria (true) o derrota (false).
    partidas.remove(partidaID) elimina de la lista de partidas en curso la partida
    indicada.
    JsonString.determinarVictoria(resultado) recibe un booleano y retorna un
    String en formato Json.
    */
    public String determinarVictoria(int partidaID){
        Proyecto p = partidas.get(partidaID).getProyecto();
        boolean resultado = p.terminarJuego();
        partidas.remove(partidaID);
        return mensajes.determinarVictoria(resultado);
    }
    
    /**
    * Recibe el id de una partida y obtiene los datos de su proyecto asociado, 
    * llama el metodo scrumPlanning de JsonString para crear el Json de la vista
    * correspondiente.
    * @param partidaID id de la partida.
    * @return string en formato Json con el codigo 0004 para la vista de Scrum Planning.
    */
    public String scrumPlanning(int partidaID){
        Partida par = (Partida)partidas.get(partidaID);
        Proyecto p = (Proyecto)par.getProyecto();
        String nombre = p.getNombre();
        String descripcion = p.getDescripcion();
        return mensajes.scrumPlanning(nombre, descripcion);
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
        Proyecto proyectoGanado = new Proyecto("Puente", "Descripcion del Puente", 5);
        Partida partidaGanada = new Partida("15600", "Partida de Edison", proyectoGanado);
        partidas.put(1234, partidaGanada);
    }
    
}
