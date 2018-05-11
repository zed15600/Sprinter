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
    
    private String nombre;
    private int ID;


    public String getNombre() {
        return nombre;
    }
    
    public Jugador(String nombre, int ID) {
        this.nombre = nombre;
        this.ID = ID;
    }
    
    public int getID(){
        return ID;
    }
}
