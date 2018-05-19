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
public class ColleccionDePartidas {
    
    private final PartidaDAO partidaDAO;
    private final ArrayList<Partida> partidas;
    
    public ColleccionDePartidas(PartidaDAO partidaDAO){
       this.partidaDAO = partidaDAO; 
       partidas = partidaDAO.obtenerPartidas();
    }
    
    public void actualizar(){
        partidaDAO.obtenerPartidas();
    }
    
    public ArrayList<Partida>getPartidas(){
        return partidas;
    }
}
