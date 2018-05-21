/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades.Modelo;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Stack;
import java.util.concurrent.ThreadLocalRandom;

/**
 *
 * @author usuario
 */



public class Partida {    
    private final int codigo;
    private final String nombre;
    private final ArrayList<IntegranteScrumTeam> listaJugadores;
    private final ScrumMaster scrumMaster;
    private final Stack<String> avatares;
    private Proyecto proyecto;
    private boolean votacion;
    private int tipoVotacion; /* Tipos de Votaciones:
                               * 1 || 2
                               * 1 -> votar historias de Sprint, 
                               * 2 -> votar historia de día
                               */
    private String estado;

    public ArrayList<IntegranteScrumTeam> getListaJugadores() {
        return listaJugadores;
    }

    public boolean isVotacion() {
        return votacion;
    }
    
    public Partida(int codigo, String nombre, Proyecto proyecto,
            ScrumMaster scrumMaster){
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
        Collections.shuffle(avatares);
        votacion = false;
        tipoVotacion = 0;
        estado = "conexion";
    }

    public ScrumMaster getScrumMaster() {
        return scrumMaster;
    }
    
    public int agregarJugador (String nombre, String avatar){
        int id = listaJugadores.size()+1;
        IntegranteScrumTeam jugador = new IntegranteScrumTeam(nombre,id,avatar);
        listaJugadores.add(jugador);
        return id;
    }
    
    public String tomarAvatar(){
        return avatares.pop();
    }
    
    public void reiniciarVotaciones(){
        for(IntegranteScrumTeam jugador: listaJugadores){
            jugador.setVotar(true);
        }
        proyecto.reiniciarVotacion();
    }
    
    public void asignarImpedimentos(ArrayList<Impedimento> imps){
        int sprints = proyecto.getNumeroSprints();
        int dias = proyecto.getDuracionDeSprints();
        int sActual = proyecto.getSprintActual();
        int dActual = proyecto.getDiaActual();
        double probabilidad = ((sActual-1)*dias+dActual)*0.5/(sprints*dias);
        probabilidad = sActual==0?0:probabilidad;
        for(IntegranteScrumTeam jugador: listaJugadores){
            if(probabilidad > 0 && Math.random() < probabilidad){
                int impedimento = ThreadLocalRandom.current().nextInt(imps.size());
                jugador.setImpedimento(imps.get(impedimento));
            }else{
                jugador.setImpedimento(null);
            }
        }
    }
    
    public ArrayList<IntegranteScrumTeam> getJugadoresConImpedimentos(){
        ArrayList<IntegranteScrumTeam> jugadores = new ArrayList<>();
        for(IntegranteScrumTeam j: listaJugadores){
            if(j.getImpedimento() != null){
                jugadores.add(j);
            }
        }
        return jugadores;
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
    
    public String getEstado(){
        return estado;
    }
    
    public void setEstado(String estado){
        this.estado = estado;
    }
    
}
