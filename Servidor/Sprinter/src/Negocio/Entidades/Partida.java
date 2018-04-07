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



public class Partida {
    private String codigo;
    private ArrayList<Jugador> listaJugadores;
    private String nombre;
    private Proyecto proyecto;
    
    public Partida(String codigo, String nombre, Proyecto proyecto){
        this.codigo = codigo;
        this.listaJugadores = new ArrayList();
        this.nombre = nombre;
        this.proyecto = proyecto;
    }
    
    public void agregarJugador (Jugador jugador){    
    }
    
    public void quitarJugador (Jugador jugador){        
    }
    
    public Proyecto getProyecto(){
        return this.proyecto;
    }
    
    public String getNombre(){
        return this.nombre;
    }
    
}
