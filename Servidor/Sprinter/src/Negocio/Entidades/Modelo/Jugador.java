/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades.Modelo;

/**
 *
 * @author usuario
 */
public class Jugador {
    
    private final String nombre;
    private final int assignedID;
    private final String deviceID;
    
    public Jugador(String nombre, int assignedID, 
            String deviceID) {
        this.nombre = nombre;
        this.assignedID = assignedID;
        this.deviceID = deviceID;
    }

    public String getNombre() {
        return nombre;
    }
    
    public int getAssignedID(){
        return assignedID;
    }

    public String getDeviceID() {
        return deviceID;
    }
}
