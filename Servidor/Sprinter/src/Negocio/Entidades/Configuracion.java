/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades;

import java.util.concurrent.ThreadLocalRandom;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

/**
 *
 * @author usuario
 */
public class Configuracion {
    
    private static final Map<Integer, Partida> partidas = new HashMap<>();
    private final ArrayList<Proyecto> listaDeProyectos;
    private final ProyectoDAO impl;

    public Map<Integer, Partida> getPartidas() {
        return partidas;
    }

    public Configuracion(ProyectoDAO impl){
        this.impl = impl;
        listaDeProyectos = impl.obtenerProyectos();
    }
    
    public int crearPartida(String nombreJugador, String nombrePartida, String nombreProyecto){
        int codigo = ThreadLocalRandom.current().nextInt(100000, 999998 + 1);
        Set keys = partidas.keySet();
        while (keys.contains(codigo)){
            codigo = ThreadLocalRandom.current().nextInt(100000, 999998 + 1);
        }
        Proyecto proyecto = impl.obtenerProyecto(nombreProyecto);
        ScrumMaster scrumMaster = new ScrumMaster(nombreJugador, 0);
        Partida partida = new Partida(codigo, nombrePartida, proyecto, scrumMaster);
        partidas.put(codigo, partida);
        return codigo;
    }
    
    public void descargarDatos(){        
    }
    
    public void agregarProyecto(Proyecto proyecto){
        this.listaDeProyectos.add(proyecto);
    }
    
    public ArrayList<Proyecto> getListaDeProyectos(){
        return listaDeProyectos;
    }
}
