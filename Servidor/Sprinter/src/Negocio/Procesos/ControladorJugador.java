/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Modelo.Configuracion;
import Negocio.Entidades.Modelo.HistoriaDeUsuario;
import Negocio.Entidades.Modelo.IntegranteScrumTeam;
import Negocio.Entidades.Modelo.Jugador;
import Negocio.Entidades.Modelo.Partida;
import Negocio.Entidades.Modelo.Proyecto;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;

/**
 *
 * @author usuario
 */
public class ControladorJugador extends Controlador {
    
    public ControladorJugador(IMensajes respuestas,Configuracion configuracion){
        super(respuestas, configuracion);
    }
    
    public String actualizarEstadoJugador(int partidaID, int jugadorID){
        Partida p = configuracion.obtenerPartida(partidaID);
        String estadoPartida = p.getEstado();
        if(estadoPartida.equals("conexion")){
            return respuestas.actualizarEstadoJugador(false, estadoPartida,
                new HistoriaDeUsuario[]{}, null); 
        }
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
        size = Math.min(size, py.getNumeroHistoriasPorCompletar());
        historias.sort(null);
        Collections.reverse(historias);
        HistoriaDeUsuario[] posibles = new HistoriaDeUsuario[size];
        int i = 0;
        for(HistoriaDeUsuario historia: historias){
            if(!historia.getEstado()){
                posibles[i] = historia;
                i++;
            }else{
                continue;
            }
            if(i >= size){
                break;
            }
        }
        boolean validar;
        IntegranteScrumTeam jugador = p.getListaJugadores().get(jugadorID-1);
        validar = p.getVotacion()
                && jugador.getVotar();
        return respuestas.actualizarEstadoJugador(validar, estadoPartida,
                posibles, jugador.getImpedimento());        
    }

    public String unirsePartida(int codigo, String nombreJugador, 
            String deviceID) {
        Collection<Partida> parts = configuracion.obtenerPartidas();
        for(Partida partida: parts){
            if(partida.getUnion()==codigo){
                IntegranteScrumTeam jugador = 
                        partida.agregarJugador(nombreJugador, deviceID);
                return respuestas.unirsePartida(jugador, true);
            }
        }
        return respuestas.unirsePartida(new IntegranteScrumTeam("", 0, "", ""),
                false);
    }

    public void registrarVoto(int partidaID, String historiaNombre, int jugador) {
        Partida p = configuracion.obtenerPartida(partidaID);
        Proyecto proyecto = p.getProyecto();
        ArrayList<HistoriaDeUsuario> bcklog = proyecto.obtenerHistorias();
        p.getListaJugadores().get(jugador-1).setVotar(false);
        for(HistoriaDeUsuario historia: bcklog){
            if(historia.getNombre().equals(historiaNombre)){
                historia.aumentarVoto();
                /*System.out.println("ControladorJugador.registrarVoto() -> "+
                "Nombre HU: " + historiaNombre + "->" + historia.getNombre());*/
                return;
            }
        }
    }
}
