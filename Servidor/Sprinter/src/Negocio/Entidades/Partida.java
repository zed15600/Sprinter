/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades;

import java.util.ArrayList;
import java.util.Stack;

/**
 *
 * @author usuario
 */



public class Partida {    
    private int codigo;
    private ArrayList<IntegranteScrumTeam> listaJugadores;
    private String nombre;
    private Proyecto proyecto;
    private boolean votacion;
    private int tipoVotacion; //1 -> votar historias de Sprint, 2 -> votar historia de día
    private ScrumMaster scrumMaster;
    private Stack<String> avatares;

    public ArrayList<IntegranteScrumTeam> getListaJugadores() {
        return listaJugadores;
    }

    public boolean isVotacion() {
        return votacion;
    }

    public Stack<String> getAvatares() {
        return avatares;
    }
    
    public Partida(int codigo, String nombre, Proyecto proyecto){
        this.codigo = codigo;
        this.listaJugadores = new ArrayList();
        this.nombre = nombre;
        this.proyecto = proyecto;
        this.scrumMaster = new ScrumMaster("",0);
        votacion = false;
        tipoVotacion = 0;
    }
    
    public Partida(int codigo, String nombre, Proyecto proyecto, ScrumMaster scrumMaster){
        this.codigo = codigo;
        this.listaJugadores = new ArrayList();
        this.nombre = nombre;
        this.proyecto = proyecto;
        this.scrumMaster = scrumMaster;
        this.avatares = new Stack<>();
        avatares.push("lobo");
        avatares.push("zorro");
        avatares.push("oso");
        avatares.push("gato");
        avatares.push("mapache");
        avatares.push("panda");
        votacion = false;
        tipoVotacion = 0;
    }

    public ScrumMaster getScrumMaster() {
        return scrumMaster;
    }
    
    public int agregarJugador (String nombre, String avatar){
        int id = listaJugadores.size()+1;
        IntegranteScrumTeam jugador = new IntegranteScrumTeam(nombre, id, avatar);
        listaJugadores.add(jugador);
        return id;
    }
    
    public void reiniciarVotaciones(){
        for(IntegranteScrumTeam jugador: listaJugadores){
            jugador.setVotar(true);
        }
        proyecto.reiniciarVotacion();
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
        for(IntegranteScrumTeam jugador: listaJugadores){
            jugadoresPorVotar |= jugador.getVotar()&&jugador.getEstado();
        }
        votacion &= jugadoresPorVotar;
        return votacion;
    }
    
    public void setVotacion(boolean votacion){
        this.votacion = votacion;
    }
    
    public int getTipoVotacion(){
        return tipoVotacion;
    }
    
    public void setTipoVotación(int tipoVotacion){
        this.tipoVotacion = tipoVotacion;
    }
    
}
