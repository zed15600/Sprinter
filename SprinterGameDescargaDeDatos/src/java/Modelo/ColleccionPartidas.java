/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Modelo;

import java.util.ArrayList;

/**
 *
 * @author Ricardo Azopardo
 */
public class ColleccionPartidas {
    
    private final IConexionBaseDeDatos conexion;
    private final ArrayList<Partida> partidas;
    
    public ColleccionPartidas(IConexionBaseDeDatos conexion){
       this.conexion = conexion;
       conexion.conectar();
       partidas = conexion.obtenerPartidas();
    }
    
    public void actualizar(){
        conexion.obtenerPartidas();
    }
    
    public ArrayList<Partida>getPartidas(){
        return conexion.obtenerPartidas();
    }
}
