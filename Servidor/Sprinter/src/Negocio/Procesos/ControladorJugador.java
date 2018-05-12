/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Configuracion;
import Negocio.Entidades.HistoriaDeUsuario;
import Negocio.Entidades.Partida;
import Negocio.Entidades.Proyecto;
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
            System.out.println("ControladorJugador.actualizarEstadoJugador()" + 
        "-> Orden de historias: " + historia.getNombre());
        }*/
        HistoriaDeUsuario[] posibles = new HistoriaDeUsuario[size];
        for(int i=0; i<size; i++){
            if(i < historias.size())
                posibles[i] = historias.get(i);
        }
        boolean validar;
        validar = p.getVotacion()
                && p.getListaJugadores().get(jugador-1).getVotar();
        return respuestas.actualizarEstadoJugador(validar, posibles);        
    }

    public String unirsePartida(int codigo, String nombreJugador) {
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

    public void registrarVoto(int partidaID, int historiaID, int jugador) {
        Partida p = configuracion.obtenerPartida(partidaID);
        Proyecto proyecto = p.getProyecto();
        ArrayList<HistoriaDeUsuario> bcklog = proyecto.obtenerHistorias();
        p.getListaJugadores().get(jugador-1).setVotar(false);
        for(HistoriaDeUsuario historia: bcklog){
            if(historia.getId()==historiaID){
                historia.aumentarVoto();
                /*System.out.println("ControladorPrincipal.registrarVoto() -> +
                REGISTRÉ UN VOTO.");*/
                return;
            }
        }
    }
}
