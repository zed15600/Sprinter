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
public class Criterio {
    
    String descripcion;
    
    boolean completitud;

    public String getDescripcion() {
        return descripcion;
    }

    public boolean isCompletitud() {
        return completitud;
    }
    
    public Criterio(String descripcion){
        this.descripcion = descripcion;
    }
}
