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
public class Backlog {
    
    private final ArrayList<HistoriaDeUsuario> listaDeHistorias;
    
    public Backlog (){
        this.listaDeHistorias = new ArrayList<>();
    }
    
    public Backlog(ArrayList<HistoriaDeUsuario> listaDeHistorias){
        this.listaDeHistorias = listaDeHistorias;
    }
    
    public void agregarHistoria(HistoriaDeUsuario historia){
        this.listaDeHistorias.add(historia);
        
    }
    
    public void quitarHistoria(HistoriaDeUsuario historia){
        
    }
    
    public ArrayList<HistoriaDeUsuario> getHistorias() {
        return this.listaDeHistorias;
    }
}
