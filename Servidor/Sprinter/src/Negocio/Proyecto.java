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
    private int duracionDeSprints;
    private int diaActual;
    private int sprintActual;
    
    public Proyecto (ArrayList<Sprint> listaDeSprints, ProductBacklog productBacklog, int duracionDeSprints){
        this.listaDeSprints = listaDeSprints;
        this.productBacklog = productBacklog;
        this.duracionDeSprints = duracionDeSprints;
        this.diaActual = 1;
        this.sprintActual = 1;
    }
    
    public void terminarJuego(){        
    }
    
    public void nexSprint(){
        this.sprintActual++;
    }
    
    public ArrayList<Sprint> getSprints(){
        return this.listaDeSprints;
    }
    
    public int getSprintActual(){
        return this.sprintActual;
    }
    
}
