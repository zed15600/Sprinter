/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Configuracion;
import Negocio.Entidades.Sprint;
import Negocio.Entidades.Proyecto;
import Negocio.Entidades.HistoriaDeUsuario;
import Negocio.Entidades.IntegranteScrumTeam;
import Negocio.Entidades.Partida;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;

/**
 *
 * @author EDISON
 */
public class Controlador {
    private final IConexion conexion;
    private final IMensajes respuestas;
    private final Configuracion configuracion;
    
    public Controlador(IMensajes respuestas, IConexion conexion, 
    Configuracion configuracion) {
        this.configuracion = configuracion;
        this.respuestas = respuestas;
        this.conexion = conexion;
    }
    
    public void conectar(){
        conexion.conectar();
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
    public void terminarSprint(int partidaID){
        Proyecto p = configuracion.obtenerProyectoDePartida(partidaID);
        Sprint actual = p.getSprints().get(p.getSprintActual()-1);
        actual.terminarSprint();
        p.nextSprint();
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
        Proyecto p = configuracion.obtenerProyectoDePartida(partidaID);
        boolean resultado = p.terminarJuego();
        configuracion.quitarPartida(partidaID);
        return respuestas.determinarVictoria(resultado);
    }
    
    /**
    * Recibe el id de una partida y obtiene los datos de su proyecto asociado, 
    * llama el metodo scrumPlanning de JsonString para crear el Json de la vista
    * correspondiente.
    * @param partidaID id de la partida.
    * @return string en formato Json con el codigo 0004 para la vista de Scrum Planning.
    */
    
    public String enviarProyecto(int partidaID){
        Proyecto proyecto = configuracion.obtenerProyectoDePartida(partidaID);
        return respuestas.traerProyecto(proyecto);
    }
    
    public String sprintPlanning(int ID){
        Proyecto p = configuracion.obtenerProyectoDePartida(ID);
        ArrayList<Sprint> sprints = p.getSprints();
        int actual = p.getSprintActual();
        int restantes = Math.abs(sprints.size() - actual);
        return respuestas.sprintPlanning(restantes, actual);
    }
    
    public void establecerCompletada(int pID, String nombre) {
        Proyecto p = configuracion.obtenerProyectoDePartida(pID);
        ArrayList<HistoriaDeUsuario> historias = p.obtenerHistorias();
        for (HistoriaDeUsuario historia : historias){
            if (historia.getNombre().equals(nombre)){
                historia.terminarHU();
                return;
            }
        }
    }
    
    public String unirsePartida(int codigo, String nombreJugador){
        Collection<Partida> parts = configuracion.obtenerPartidas();
        for(Partida partida: parts){
            if(partida.getUnion()==codigo){
                String avatar = partida.tomarAvatar();
                int idJugador = partida.agregarJugador(nombreJugador, avatar);
                return respuestas.unirsePartida(idJugador, true, avatar);
            }
        }
        return respuestas.unirsePartida(0, false, "");
    }
    
    public String actualizarEstadoJugador(int partidaID, int jugador){
        Partida p = configuracion.obtenerPartida(partidaID);
        Proyecto py = p.getProyecto();
        boolean votar = p.getVotacion();
        int tipoVotacion = p.getTipoVotacion();
        ArrayList<HistoriaDeUsuario> historias = new ArrayList<>();
        int size = 0;
        if(votar && tipoVotacion == 1){
            size = 6;
            historias = py.obtenerHistorias();
        }
        if(votar && tipoVotacion == 2){
            historias = py.obtenerHistoriasSprint();
            size = historias.size();
            for(HistoriaDeUsuario historia : historias){
                if(historia.getEstado()){
                    size--;
                }
            }
        }
        size = Math.min(size, historias.size());
        historias.sort(null);
        Collections.reverse(historias);
        /*for(HistoriaDeUsuario historia : historias){
            System.out.println("Proceso.actualizarEstadoJugador()" + 
        "-> Orden de historias: " + historia.getNombre());
        }*/
        HistoriaDeUsuario[] posibles = new HistoriaDeUsuario[size];
        for(int i=0; i<size; i++){
            if(i < historias.size())
                posibles[i] = historias.get(i);
        }
        boolean validar;
        validar = p.getVotacion()&&p.getListaJugadores().get(jugador-1).getVotar();
        return respuestas.actualizarEstadoJugador(validar, posibles);        
    }
    
    public void registrarVoto(int partidaID, int historiaID, int jugador){
        Partida p = configuracion.obtenerPartida(partidaID);
        Proyecto proyecto = p.getProyecto();
        ArrayList<HistoriaDeUsuario> bcklog = proyecto.obtenerHistorias();
        p.getListaJugadores().get(jugador-1).setVotar(false);
        for(HistoriaDeUsuario historia: bcklog){
            if(historia.getId()==historiaID){
                historia.aumentarVoto();
                //System.out.println("Controlador.registrarVoto() -> REGISTRÉ UN VOTO.");
                return;
            }
        }
    }
    
    public void establecerVotación(int partidaID, boolean votar, int tipo){
        Partida p = configuracion.obtenerPartida(partidaID);
        if(votar){
            p.reiniciarVotaciones();
        }
        p.setVotacion(votar);
        p.setTipoVotación(tipo);
    }
    
    public String estadoVotacion(int partidaID){
        Partida p = configuracion.obtenerPartida(partidaID);
        return respuestas.estadoVotacion(p.getVotacion(), p.getTipoVotacion());
    }
    
    public String enviarVotos(int partidaID, int tipoVotacion){
        Proyecto p = configuracion.obtenerProyectoDePartida(partidaID);
        int respuestasVotos = 0;
        if(tipoVotacion == 1){
            respuestasVotos = p.getDuracionDeSprints();
        }
        if(tipoVotacion == 2){
            respuestasVotos = 1;
        }
        return this.respuestas.enviarVotos(p.getVotos(respuestasVotos));
    }
    
    public String enviarProyectos(){
        ArrayList<Proyecto> listaDeProyectos = configuracion.getListaDeProyectos();
        return respuestas.enviarNombresProyectos(listaDeProyectos);
    }
    
    public String crearPartida(String jugador, String partida, String proyecto){        
        String codigo = configuracion.crearPartida(jugador, partida, proyecto);
        return respuestas.enviarCodigoPartida(codigo);
    }

    public IConexion getConexion() {
        return conexion;
    }

    public String enviarJugadores(int idPartida) {
        Partida p = configuracion.obtenerPartida(idPartida);
        ArrayList<IntegranteScrumTeam> jugadores= p.getListaJugadores();
        return respuestas.enviarJugadoresConAvatares(jugadores);
    }
    
}
