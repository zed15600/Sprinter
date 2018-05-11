/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades;

import java.util.concurrent.ThreadLocalRandom;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

/**
 *
 * @author usuario
 */
public class Configuracion {
    
    private static final Map<Integer, Partida> partidas = new HashMap<>();
    //local
    private final ArrayList<Proyecto> listaDeProyectos;
    private final IConexionBaseDeDatos impl;

    public Configuracion(IConexionBaseDeDatos impl){
        this.impl = impl;
        this.impl.conectar();
        listaDeProyectos = this.impl.obtenerProyectos();
    }
    
    public String crearPartida(String nombreJugador, String nombrePartida, String nombreProyecto){
        int codigo = ThreadLocalRandom.current().nextInt(100000, 999998 + 1);
        Set keys = partidas.keySet();
        while (keys.contains(codigo)){
            codigo = ThreadLocalRandom.current().nextInt(100000, 999998 + 1);
        }
        Proyecto proyecto = this.impl.obtenerProyecto(nombreProyecto);
        ScrumMaster scrumMaster = new ScrumMaster(nombreJugador, 0);
        Partida partida = new Partida(codigo, nombrePartida, proyecto, scrumMaster);
        partidas.put(codigo, partida);
        String codigoPartida = String.valueOf(codigo);
        return codigoPartida;
    }
    public Proyecto obtenerProyectoDePartida(int idPartida){
        return partidas.get(idPartida).getProyecto();
    }
    
    public Partida obtenerPartida(int idPartida){
        return partidas.get(idPartida);
    }
    
    public Collection<Partida> obtenerPartidas(){
        return partidas.values();
    }
    
    public void quitarPartida(int idPartida){
        partidas.remove(idPartida);
    }
    
    public void agregarProyecto(Proyecto proyecto){
        this.listaDeProyectos.add(proyecto);
    }
    
    public ArrayList<Proyecto> getListaDeProyectos(){
        return listaDeProyectos;
    }
}
