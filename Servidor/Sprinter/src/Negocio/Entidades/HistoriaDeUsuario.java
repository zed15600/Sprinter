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
public class HistoriaDeUsuario implements Comparable<HistoriaDeUsuario>{
    
    private int id;
    private int puntuacion;
    private int prioridad;
    private int contadorVotos;
    private boolean estado;
    private String nombre;
    private String descripcion;
    private String puntosHistoria;
    private ArrayList<Criterio> listaCriterios;
    
    public HistoriaDeUsuario(){
    }
    
    public HistoriaDeUsuario(int id, String descripcion, String puntosHistoria, int prioridad){
        this.id = id;
        this.puntosHistoria = puntosHistoria;
        this.prioridad = prioridad;
        this.puntuacion = 0;
        this.estado = false;
        this.descripcion = descripcion;
        this.contadorVotos = 0;
        this.listaCriterios = new ArrayList();
        this.puntosHistoria = puntosHistoria;
    }
    
    public HistoriaDeUsuario(int id, String descripcion, String puntosHistoria, int prioridad,
            ArrayList<Criterio> listaCriterios, String nombre){
        this.nombre = nombre;
        this.id = id;
        this.puntosHistoria = puntosHistoria;
        this.prioridad = prioridad;
        this.puntuacion = 0;
        this.estado = false;
        this.descripcion = descripcion;
        this.contadorVotos = 0;
        this.listaCriterios = listaCriterios;
        this.puntosHistoria = puntosHistoria;
    }
    
    public void setNombre(String nombre){
        this.nombre = nombre;
    }
    
    public String getNombre(){
        return nombre;
    }
    
    public String getDescripcion() {
        return descripcion;
    }

    public ArrayList<Criterio> getListaCriterios() {
        return listaCriterios;
    }

    public String getPuntosHistoria() {
        return puntosHistoria;
    }

    public int getPrioridad() {
        return prioridad;
    }
    
    public void terminarHU(){
        this.estado = true;
    }
    
    public int getId(){
        return this.id;
    }
    
    public int getPuntuacion(){
        return this.puntuacion;
    }
    
    public boolean getEstado(){
        return this.estado;
    }
    
    public void setEstado(boolean estado){
        this.estado = estado;
    }
    
    public int getVotos(){
        return contadorVotos;
    }
    
    public void aumentarVoto(){
        contadorVotos+=1;
    }
    
    public void reiniciarVotos(){
        contadorVotos = 0;
    }
    
    public void agregarCriterio(Criterio criterio){
        this.listaCriterios.add(criterio);
    }

    
    @Override
    public int compareTo(HistoriaDeUsuario o) {
        if(this.contadorVotos > o.contadorVotos){
            return -1;
        }
        if(this.contadorVotos < o.contadorVotos){
            return 1;
        }
        if(this.prioridad > o.prioridad){
            return -1;
        }
        if(this.contadorVotos < o.prioridad){
            return 1;
        }
        return 0;
    }


}
