/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades;

import java.util.ArrayList;
import java.util.Collections;

/**
 *
 * @author usuario
 */
public class Proyecto {
    
    private ArrayList<Sprint> listaDeSprints;
    private Backlog productBacklog;
    //local
    private String nombre;
    //local
    private String descripcion;
    private int numeroSprints; 
    //local posiblemente
    private int duracionDeSprints;
    
    private int sprintActual;
    private int diaActual;
    
    public Proyecto(String nombre, String descripcion){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.duracionDeSprints = 0;
        this.listaDeSprints = new ArrayList();
        this.productBacklog = new Backlog(0);
    }
    
    public Proyecto (String nombre, String descripcion, int duracionDeSprints, 
            Backlog productBacklog, int numeroSprints){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.listaDeSprints = new ArrayList(numeroSprints);
        this.productBacklog = productBacklog;
        this.numeroSprints = numeroSprints;
        this.duracionDeSprints = duracionDeSprints;
        sprintActual = 0;
        diaActual = 1;
    }
    
    public void reiniciarVotacion(){
        for(HistoriaDeUsuario historia: productBacklog.getHistorias()){
            historia.reiniciarVotos();
        }
    }
    
    public boolean terminarJuego(){
        boolean victoria = true;
        
        ArrayList<HistoriaDeUsuario> historias = productBacklog.getHistorias();
        for(HistoriaDeUsuario hist: historias) {
        victoria &= hist.getEstado();
        }
        return victoria;
    }
    
    public ArrayList<HistoriaDeUsuario> obtenerHistorias(){
        return productBacklog.getHistorias();
    }
    
    public ArrayList<HistoriaDeUsuario> obtenerHistoriasSprint(){
        return listaDeSprints.get(sprintActual-1).getSprintBacklog().getHistorias();
    }
    
    public void nextDia(){
        if(diaActual < duracionDeSprints){
            diaActual++;
        }else{
            diaActual=1;
        }
    }
    
    public void nextSprint(){
        sprintActual++;
        /*System.out.println("Proyecto.nextSprint() -> Ahora estamos en el sprint"
                + " " + sprintActual);*/
    }
    
    public int getNumeroSprints(){
        return numeroSprints;
    }
    
    public int getDuracionDeSprints(){
        return duracionDeSprints;
    }
    
    public ArrayList<Sprint> getSprints(){
        return this.listaDeSprints;
    }
    
    public void agregarSprint(Sprint sp){
        listaDeSprints.add(sp);
    }
    
    /*public int getDiaActual(){
        return this.diaActual;
    }*/

    public String getNombre() {
        return nombre;
    }

    public String getDescripcion() {
        return descripcion;
    }
    
    public int getSprintActual(){
        return this.sprintActual;
    }
    
    public String[][] getVotos(int Maximo, int tipoVotacion){
        ArrayList<HistoriaDeUsuario> historias = productBacklog.getHistorias();
        
        historias.sort(null);
        Collections.reverse(historias);
        /*for(HistoriaDeUsuario historia : historias){
        System.out.println("Proyecto.getVotos() -> Orden de historias: " +
                historia.getNombre());
        }*/
        //Esto lo tengo que hacer variable
        if(historias.size() >= Maximo 
                && Maximo == duracionDeSprints 
                && historias.get(3).getVotos() == 0){
            Maximo = 3;
        }
        int cantidad = Math.min(Maximo, getNumeroHistoriasPorCompletar());
        Sprint actual = new Sprint(sprintActual, cantidad);
        String[][] votos = new String[2][cantidad];
        int i = 0;
        for(HistoriaDeUsuario historia: historias){
            if(!historia.getEstado()){
                actual.getSprintBacklog().agregarHistoria(historia);
                votos[0][i] = ""+historia.getNombre();
                votos[1][i] = ""+historia.getVotos();
                i++;
            }
            if(i >= cantidad){
                break;
            }
        }
        if(tipoVotacion == 1){
            /*System.out.println("Proyecto.getVotos() -> Agregué un sprint con " 
                    + actual.getSprintBacklog().getTamaño() + " historias.");*/
            listaDeSprints.add(actual);
            nextSprint();
        }
        return votos;
    } 

    public Backlog getProductBacklog() {
        return productBacklog;
    }
    
    public int getNumeroHistoriasPorCompletar(){
        int i=0;
        for(HistoriaDeUsuario historia: obtenerHistorias()){
            if(!historia.getEstado()){
                i++;
            }
        }
        return i;
    }

    public int getDiaActual() {
        return diaActual;
    }
    
}
