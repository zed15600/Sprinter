/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio;

import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class Proyecto {
    
    private ArrayList<Sprint> listaDeSprints;
    private ProductBacklog productBacklog;
    private String nombre;
    private String descripcion;
    private int duracionDeSprints;
    private int diaActual;
    private int sprintActual;
    
    public Proyecto (String nombre, String descripcion, int duracionDeSprints){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.listaDeSprints = new ArrayList();
        this.productBacklog = new ProductBacklog();
        this.duracionDeSprints = duracionDeSprints;
        this.diaActual = 1;
        this.sprintActual = 1;
    }
    
    public boolean terminarJuego(){
        boolean victoria = true;
        ArrayList<HistoriaDeUsuario> historias = productBacklog.getHistorias();
        for(int i=0; i<historias.size(); i++){
            victoria &= historias.get(i).getEstado();
        }
        return victoria;
    }
    
    public void nextDia(){
        this.diaActual++;
    }
    
    public void nextSprint(){
        this.sprintActual++;
    }
    
    public ArrayList<Sprint> getSprints(){
        return this.listaDeSprints;
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
    
}
