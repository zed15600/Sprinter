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
    
    private final Map<Integer, Partida> mapaDePartidas;
    private final ArrayList<Impedimento> impedimentos;
    //local
    private final ArrayList<Proyecto> listaDeProyectos;
    private final IConexionBaseDeDatos impl;

    public Configuracion(IConexionBaseDeDatos impl){
        this.mapaDePartidas = new HashMap<>();
        this.impl = impl;
        listaDeProyectos = this.impl.obtenerProyectos();
        impedimentos = this.impl.obtenerImpedimentos();
    }
    
    public String crearPartida(String nombreJugador, String nombrePartida,
            String nombreProyecto){
        int codigo = ThreadLocalRandom.current().nextInt(100000, 999998 + 1);
        Set keys = mapaDePartidas.keySet();
        while (keys.contains(codigo)){
            codigo = ThreadLocalRandom.current().nextInt(100000, 999998 + 1);
        }
        Proyecto proyecto = this.impl.obtenerProyecto(nombreProyecto);
        ScrumMaster scrumMaster = new ScrumMaster(nombreJugador, 0);
        Partida partida = new Partida(codigo, nombrePartida, proyecto,
                scrumMaster);
        mapaDePartidas.put(codigo, partida);
        String codigoPartida = String.valueOf(codigo);
        return codigoPartida;
    }
    public Proyecto obtenerProyectoDePartida(int idPartida){
        return mapaDePartidas.get(idPartida).getProyecto();
    }
    
    public Partida obtenerPartida(int idPartida){
        return mapaDePartidas.get(idPartida);
    }
    
    public Collection<Partida> obtenerPartidas(){
        return mapaDePartidas.values();
    }
    
    public void quitarPartida(int idPartida){
        mapaDePartidas.remove(idPartida);
    }
    
    public void agregarProyecto(Proyecto proyecto){
        this.listaDeProyectos.add(proyecto);
    }
    
    public ArrayList<Proyecto> getListaDeProyectos(){
        return listaDeProyectos;
    }

    public ArrayList<Impedimento> getImpedimentos() {
        return impedimentos;
    }
}
