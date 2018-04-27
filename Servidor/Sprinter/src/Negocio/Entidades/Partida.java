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
    private int codigo;
    private int codigoUnirse;
    private ArrayList<Jugador> listaJugadores;
    private String nombre;
    private Proyecto proyecto;
    private boolean votacion;
    private int tipoVotacion;
    
    public Partida(int codigo, String nombre, Proyecto proyecto){
        this.codigo = codigo;
        this.listaJugadores = new ArrayList();
        this.nombre = nombre;
        this.proyecto = proyecto;
        //generar código aleatorio
        codigoUnirse = 837085;
        votacion = false;
        tipoVotacion = 0;
    }
    
    public int agregarJugador (){
        int id = listaJugadores.size()+1;
        Jugador jugador = new Jugador("Edison", id);
        listaJugadores.add(jugador);
        return id;
    }
    
    public void quitarJugador (Jugador jugador){        
    }
    
    public int getCodigo(){
        return this.codigo;
    }
    
    public Proyecto getProyecto(){
        return this.proyecto;
    }
    
    public String getNombre(){
        return this.nombre;
    }
    
    public int getUnion(){
        return this.codigoUnirse;
    }
    
    public boolean getVotacion(){
        return votacion;
    }
    
    public void setVotacion(boolean votacion){
        this.votacion = votacion;
    }
    
    public ArrayList<Jugador> getJugadores(){
        return listaJugadores;
    }
    
    public int getTipoVotacion(){
        return tipoVotacion;
    }
    
    public void setTipoVotación(int tipoVotacion){
        this.tipoVotacion = tipoVotacion;
    }
    
}
