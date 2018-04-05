/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Proyecto;
import Negocio.Entidades.SprintBacklog;

/**
 *
 * @author usuario
 */
public interface IMensajes {
    
    public String terminarDia(Proyecto p);
    public String terminarSprint(SprintBacklog sprntBcklg);
    public String determinarVictoria(boolean resultado);
    public String scrumPlanning(String nombre, String descripcion);
}
