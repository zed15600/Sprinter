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
public class Proyecto {
    
    private ArrayList<Sprint> listaDeSprints;
    private Backlog productBacklog;
    private String nombre;
    private String descripcion;
    private int duracionDeSprints;
    private int diaActual;
    private int sprintActual;
    
    public Proyecto(String nombre, String descripcion){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.duracionDeSprints = 0;
        this.listaDeSprints = new ArrayList();
        this.productBacklog = new Backlog();
    }
    
    public Proyecto (String nombre, String descripcion, int duracionDeSprints, 
            Backlog productBacklog, int tamaño){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.listaDeSprints = new ArrayList(tamaño);
        this.productBacklog = productBacklog;
        this.duracionDeSprints = duracionDeSprints;
        this.diaActual = 1;
        this.sprintActual = 1;
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
    
    public void nextDia(){
        this.diaActual++;
    }
    
    public void nextSprint(){
        this.sprintActual++;
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
    
    public int getDiaActual(){
        return this.diaActual;
    }

    public String getNombre() {
        return nombre;
    }

    public String getDescripcion() {
        return descripcion;
    }
    
    public int getSprintActual(){
        return this.sprintActual;
    }
    
    public int[][] getVotos(int Maximo){
        ArrayList<HistoriaDeUsuario> historias = productBacklog.getHistorias();
        Sprint actual = new Sprint(sprintActual);
        historias.sort(null);
        if(historias.size() >= Maximo && Maximo == 4 && historias.get(3).getVotos() == 0){
            Maximo = 3;
        }
        int cantidad = Math.min(Maximo, historias.size());
        int[][] votos = new int[2][cantidad];
        for(int i=0; i<cantidad; i++){
            HistoriaDeUsuario h = historias.get(i);
            actual.getSprintBacklog().agregarHistoria(h);
            votos[0][i] = h.getId();
            votos[1][i] = h.getVotos();
        }
        listaDeSprints.add(actual);
        return votos;
    } 

    public Backlog getProductBacklog() {
        return productBacklog;
    }
    
}
