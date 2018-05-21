/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades.Modelo;

import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class Backlog {
    private final ArrayList<HistoriaDeUsuario> listaDeHistorias;
    private final int tamaño;
    
    public Backlog (int tamaño){
        this.tamaño = tamaño;
        this.listaDeHistorias = new ArrayList<>(tamaño);
    }
    
    public Backlog(ArrayList<HistoriaDeUsuario> listaDeHistorias){
        this.tamaño = listaDeHistorias.size();
        this.listaDeHistorias = listaDeHistorias;
    }
    
    public void agregarHistoria(HistoriaDeUsuario historia){
        this.listaDeHistorias.add(historia);   
    }
    
    public int getTamaño(){
        return tamaño;
    }
    
    public ArrayList<HistoriaDeUsuario> getHistorias() {
        return this.listaDeHistorias;
    }
}
