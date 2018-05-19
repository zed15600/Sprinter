/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Modelo;

import AccesoADatos.PartidaDAOMySQL;

/**
 *
 * @author usuario
 */
public class Configuracion {
    
    private static ColleccionDePartidas partidas;
    
    public static void main(String args[]){
        PartidaDAO impl = new PartidaDAOMySQL();
        partidas = new ColleccionDePartidas(impl);
    }
    
    public static ColleccionDePartidas getPartidas(){
        return partidas;
    }
}
