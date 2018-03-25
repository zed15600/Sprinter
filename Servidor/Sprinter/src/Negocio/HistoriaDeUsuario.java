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
    
    private int puntuaciónRequerida;
    private int puntuacion;
    private boolean estado;
    private String descripcion;
    private int contadorVotos;
    private ArrayList<Criterio> listaCriterios;

    public HistoriaDeUsuario(String descripcion) {
        this.puntuacion = 0;
        this.estado = false;
        this.descripcion = descripcion;
        this.contadorVotos = 0;
        this.listaCriterios = new ArrayList();
    }
    
    public void terminarHU(){
        this.estado = true;
    }
    
    public int getPuntuacion(){
        return this.puntuacion;
    }
    
    public boolean getEstado(){
        return this.estado;
    }
    
    public void aumentarVoto(){
    }
}
