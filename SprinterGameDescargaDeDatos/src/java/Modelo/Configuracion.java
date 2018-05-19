/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Modelo;

import AccesoADatos.ConexionMySQL;

/**
 *
 * @author Ricardo Azopardo
 */
public class Configuracion {
    
    private static ColleccionPartidas partidas;
    
    public static void main(String args[]){
        IConexionBaseDeDatos conexion = new ConexionMySQL();
        partidas = new ColleccionPartidas(conexion);
    }
    
    public static void actualizarPartidas(){
        partidas.actualizar();
    }
}
