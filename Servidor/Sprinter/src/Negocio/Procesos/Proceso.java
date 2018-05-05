/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Criterio;
import Negocio.Entidades.Sprint;
import Negocio.Entidades.Proyecto;
import Negocio.Entidades.Backlog;
import Negocio.Entidades.HistoriaDeUsuario;
import Negocio.Entidades.Partida;
import java.util.ArrayList;
import java.util.Collection;
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
    
    public String enviarProyecto(int partidaID){
        Partida par = partidas.get(partidaID);
        Proyecto p = par.getProyecto();
        String nombre = p.getNombre();
        String descripcion = p.getDescripcion();
        ArrayList<HistoriaDeUsuario>  lista = p.getProductBacklog().getHistorias();
        return mensajes.traerProyecto(nombre, descripcion, lista);
    }
    
    public String enviarHistoria(int partidaID, String ID){
        Partida par = partidas.get(partidaID);
        Proyecto p = par.getProyecto(); 
        ArrayList<HistoriaDeUsuario> historias = p.getProductBacklog().getHistorias();
        HistoriaDeUsuario historia = null;
        for (int i = 0; i<historias.size();i++){
            if (historias.get(i).getId() == Integer.valueOf(ID)){
                historia = historias.get(i);
            }
        }
        String descHU = historia.getDescripcion();
        int prioHU = historia.getPrioridad();
        String punHU = historia.getPuntosHistoria();
        boolean estado = historia.getEstado();
        ArrayList<Criterio> criterios = historia.getListaCriterios();
        return mensajes.enviarHU(descHU, punHU, prioHU, criterios, estado);
    }
    
    public String sprintPlanning(int ID){
        Partida par = partidas.get(ID);
        Proyecto p = par.getProyecto();
        ArrayList<Sprint> sprints = p.getSprints();
        int actual = p.getSprintActual();
        int restantes = Math.abs(sprints.size() - actual);
        return mensajes.sprintPlanning(restantes, actual);
    }
    
    public void establecerCompletada(int pID, String completadaID) {
        Partida par = partidas.get(pID);
        Proyecto p = par.getProyecto(); 
        ArrayList<HistoriaDeUsuario> historias = p.getProductBacklog().getHistorias();
        HistoriaDeUsuario historia = null;
        for (int i = 0; i<historias.size();i++){
            if (historias.get(i).getId() == Integer.valueOf(completadaID)){
                historia = historias.get(i);
            }
        }
        historia.terminarHU();
    }
    
    public String unirsePartida(int codigo){
        Collection<Partida> parts = partidas.values();
        for(Partida partida: parts){
            if(partida.getUnion()==codigo){
                return mensajes.unirsePartida(partida.getCodigo(), partida.agregarJugador(), true);
            }
        }
        return mensajes.unirsePartida(0000, 0, false);
    }
    
    public String actualizarEstadoJugador(int partidaID, int jugador){
        Partida p = partidas.get(partidaID);
        Proyecto py = p.getProyecto();
        boolean votar = p.getVotacion();
        int tipoVotacion = p.getTipoVotacion();
        ArrayList<HistoriaDeUsuario> historias = new ArrayList<>();
        int size = 0;
        if(votar && tipoVotacion == 1){
            size = 6;
            historias = py.getProductBacklog().getHistorias();
        }
        if(votar && tipoVotacion == 2){
            historias = py.getSprints().get(py.getSprintActual()-1).getSprintBacklog().getHistorias();
            size = historias.size();
        }
        size = Math.min(size, historias.size());
        HistoriaDeUsuario[] posibles = new HistoriaDeUsuario[size];
        for(int i=0; i<size; i++){
            if(i < historias.size())
                posibles[i] = historias.get(i);
        }
        return mensajes.actualizarEstadoJugador(p.getVotacion()&&p.getJugadores().get(jugador-1).getVotar(), posibles);
        
    }
    
    public void registrarVoto(int partidaID, int historiaID, int jugador){
        Partida p = partidas.get(partidaID);
        ArrayList<HistoriaDeUsuario> bcklog = p.getProyecto().getProductBacklog().getHistorias();
        p.getJugadores().get(jugador-1).setVotar(false);
        for(HistoriaDeUsuario historia: bcklog){
            if(historia.getId()==historiaID){
                historia.aumentarVoto();
                //System.out.println("Proceso.registrarVoto() -> REGISTRÉ UN VOTO.");
                return;
            }
        }
    }
    
    public void establecerVotación(int partidaID, boolean votar, int tipo){
        Partida p = partidas.get(partidaID);
        if(votar){
            p.reiniciarVotaciones();
        }
        p.setVotacion(votar);
        p.setTipoVotación(tipo);
    }
    
    public String estadoVotacion(int partidaID){
        Partida p = partidas.get(partidaID);
        return mensajes.estadoVotacion(p.getVotacion(), p.getTipoVotacion());
    }
    
    public String enviarVotos(int partidaID, int tipoVotacion){
        Proyecto p = partidas.get(partidaID).getProyecto();
        int respuestas = 0;
        if(tipoVotacion == 1){
            respuestas = p.getDuracionDeSprints();
        }
        if(tipoVotacion == 2){
            respuestas = 1;
        }
        return mensajes.enviarVotos(p.getVotos(respuestas));
    }
    
    /*
    Crea una partida básica para hacer pruebas.
    Pendiente de terminar.
    */
    public void sembrarPartida(){
        Criterio criterio1 = new Criterio ("El puente debe ser azul.");
        Criterio criterio2 = new Criterio ("El puente debe ser verde.");
        HistoriaDeUsuario huGanada1 = new HistoriaDeUsuario(1, "Como transitante deseo que el puente sea rojo.", "5", 4);
        HistoriaDeUsuario huGanada2 = new HistoriaDeUsuario(2, "Como transitante deseo que el puente sea alto.", "3", 2);
        huGanada1.agregarCriterio(criterio1);
        huGanada1.agregarCriterio(criterio2);
        huGanada2.agregarCriterio(criterio1);
        Backlog productBacklogGanado = new Backlog();
        productBacklogGanado.agregarHistoria(huGanada1);
        productBacklogGanado.agregarHistoria(huGanada2);
        Proyecto proyectoGanado = new Proyecto("Puente", "Descripcion del Puente", 5,
        productBacklogGanado, 3);
        Partida partidaGanada = new Partida(15600, "Partida de Edison", proyectoGanado);
        partidas.put(partidaGanada.getCodigo(), partidaGanada);
    }
    
}
