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
public class Impedimento {

    private String nombre;
    private String efecto;
    
    public Impedimento(String nombre, String efecto){
        this.nombre = nombre;
        this.efecto = efecto;
    }
    
    public String getNombre() {
        return nombre;
    }

    public String getEfecto() {
        return efecto;
    }
}
