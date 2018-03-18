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
public class HistoriaDeUsuario {
    
    private int puntuacion;
    
    private boolean completada;
    
    private String descripcion;
    
    private int contadorVotos;
    
    private ArrayList<Criterio> listaCriterios;

    public HistoriaDeUsuario(String descripcion) {
        this.puntuacion = 0;
        this.completada = false;
        this.descripcion = descripcion;
        this.contadorVotos = 0;
        this.listaCriterios = new ArrayList();
    }
    
    public void cambiarEstado(){
    }
    
    public void aumentarVoto(){
    }
}
