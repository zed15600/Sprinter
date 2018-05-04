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
public class Jugador {
    
    private String nombre;
    private int ID;
    private boolean estado; //true -> activo
    private boolean votar; //true -> puede votar

    public Jugador(String nombre, int ID) {
        this.nombre = nombre;
        this.ID = ID;
        votar = true;
        estado = true;
    }
    
    public int getID(){
        return ID;
    }
    
    public boolean getEstado(){
        return estado;
    }
    
    public boolean getVotar(){
        return votar;
    }
    
    public void setVotar(boolean votar){
        this.votar = votar;
    }
    
    public void votar(HistoriaDeUsuario HU){
    }
}
