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
public class ProductBacklog extends Backlog{

    private ArrayList<HistoriaDeUsuario> listaDeHistorias;
    
    public ProductBacklog(){
        this.listaDeHistorias = new ArrayList();
    }
    
    public void terminarHistoria(HistoriaDeUsuario historia){
        
    }
    
    public ArrayList<HistoriaDeUsuario> getHistorias(){
        return listaDeHistorias;
    }
    
}
