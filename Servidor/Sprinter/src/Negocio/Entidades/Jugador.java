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
public class Jugador {
    
    private final String nombre;
    private final int ID;
    
    public Jugador(String nombre, int ID) {
        this.nombre = nombre;
        this.ID = ID;
    }

    public String getNombre() {
        return nombre;
    }
    
    public int getID(){
        return ID;
    }

}
