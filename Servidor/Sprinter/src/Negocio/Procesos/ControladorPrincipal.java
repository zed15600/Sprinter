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
public class ControladorPrincipal {
    private final IConexion conexion;
    private final IMensajes respuestas;
    private final Configuracion configuracion;
    private final ControladorJugador controladorJugadores;
    private final ControladorProyecto controladorProyectos;
    private final ControladorPartida controladorPartidas;
    
    public ControladorPrincipal(IMensajes respuestas, IConexion conexion, 
    Configuracion configuracion) {
        this.controladorJugadores = new ControladorJugador(respuestas,
                configuracion);
        this.controladorProyectos = new ControladorProyecto(respuestas,
                configuracion);
        this.controladorPartidas = new ControladorPartida(respuestas,
                configuracion);
        this.configuracion = configuracion;
        this.respuestas = respuestas;
        this.conexion = conexion;
    }
    
    public void conectar(){
        conexion.conectar();
    }
    
    public void terminarSprint(int partidaID){
        controladorProyectos.terminarSprint(partidaID);
    }
    
    public String determinarVictoria(int partidaID){
        return controladorPartidas.determinarVictoria(partidaID);
    }
    
    public String enviarProyecto(int partidaID){
        return controladorProyectos.enviarProyecto(partidaID);
    }
    
    public String sprintPlanning(int partidaID){
        return controladorProyectos.sprintPlanning(partidaID);
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
                //System.out.println("ControladorPrincipal.registrarVoto() -> REGISTRÉ UN VOTO.");
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

    public String enviarJugadores(int idPartida) {
        Partida p = configuracion.obtenerPartida(idPartida);
        ArrayList<IntegranteScrumTeam> jugadores= p.getListaJugadores();
        return respuestas.enviarJugadoresConAvatares(jugadores);
    }
    
}
