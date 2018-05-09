/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades;

/**
 *
 * @author usuario
 */
public class Sprint {
    private Backlog sprintBacklog;
    private int numeroDeSprint;
    private boolean estado;

    public Sprint(int numeroDeSprint) {
        this.sprintBacklog = new Backlog();
        this.numeroDeSprint = numeroDeSprint;
        this.estado = false;
    }
    
    public void terminarSprint(){
        this.estado = true;
    }
    
    
    public void elegirHistoria(){
        
    }
    
    public void empezarDia(){
        
    }
    
    public Backlog getSprintBacklog(){
        return this.sprintBacklog;
    }
}
