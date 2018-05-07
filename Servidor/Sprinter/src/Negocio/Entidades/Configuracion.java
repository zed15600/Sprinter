/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades;

import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class Configuracion {
    
    private Partida partida;
    private final ArrayList<Proyecto> listaDeProyectos;
    private ProyectoDAO impl;

    public Configuracion(ProyectoDAO impl){
        this.impl = impl;
        listaDeProyectos = impl.obtenerProyectos();
    }
    
    public void crearPartida(String nombreJugador, String nombrePartida, String nombreProyecto){
        impl.obtenerProyecto(nombreProyecto);
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
