/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio;

import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class ProductBacklog extends Backlog{

    private ArrayList<HistoriaDeUsuario> listaDeCompletadas;
    
    public ProductBacklog(){
        this.listaDeCompletadas = new ArrayList();
    }
    
    public void agregarACompletadas(HistoriaDeUsuario historia){
        
    }
    
}
