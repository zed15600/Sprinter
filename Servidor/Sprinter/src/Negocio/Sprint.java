/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio;

/**
 *
 * @author usuario
 */
public class Sprint {
    private SprintBacklog sprintBacklog;
    private int duracion;
    private String numeroDeSprint;
    private boolean estado;

    public Sprint(SprintBacklog sprintBacklog, int duracion, String numeroDeSprint) {
        this.sprintBacklog = sprintBacklog;
        this.duracion = duracion;
        this.numeroDeSprint = numeroDeSprint;
        this.estado = false;
    }
    
    public void terminarSprint(){
        this.estado = true;
    }
    
    public SprintBacklog getSprintBacklog(){
        return this.sprintBacklog;
    }
    
    public void elegirHistoria(){
        
    }
    
    public void empezarDia(){
        
    }
    
}
