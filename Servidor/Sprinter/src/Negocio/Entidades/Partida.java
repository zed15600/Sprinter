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
    private ArrayList<Jugador> listaJugadores;
    private String nombre;
    private Proyecto proyecto;
    private boolean votacion;
    private int tipoVotacion; //1 -> votar historias de Sprint, 2 -> votar historia de día
    private ScrumMaster scrumMaster;
    
    public Partida(int codigo, String nombre, Proyecto proyecto){
        this.codigo = codigo;
        this.listaJugadores = new ArrayList();
        this.nombre = nombre;
        this.proyecto = proyecto;
        this.scrumMaster = new ScrumMaster("",0);
        //generar código aleatorio
        //codigoUnirse = 837085;
        votacion = false;
        tipoVotacion = 0;
    }
    
    public Partida(int codigo, String nombre, Proyecto proyecto, ScrumMaster scrumMaster){
        this.codigo = codigo;
        this.listaJugadores = new ArrayList();
        this.nombre = nombre;
        this.proyecto = proyecto;
        this.scrumMaster = scrumMaster;
        //generar código aleatorio
        //codigoUnirse = 837085;
        votacion = false;
        tipoVotacion = 0;
    }

    public ScrumMaster getScrumMaster() {
        return scrumMaster;
    }
    
    public int agregarJugador (){
        int id = listaJugadores.size()+1;
        Jugador jugador = new Jugador("Edison", id);
        listaJugadores.add(jugador);
        return id;
    }
    
    public void reiniciarVotaciones(){
        for(Jugador jugador: listaJugadores){
            jugador.setVotar(true);
        }
        proyecto.reiniciarVotacion();
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
        return this.codigo;
    }
    
    public boolean getVotacion(){
        boolean jugadoresPorVotar = false;
        for(Jugador jugador: listaJugadores){
            jugadoresPorVotar |= jugador.getVotar()&&jugador.getEstado();
        }
        votacion &= jugadoresPorVotar;
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
