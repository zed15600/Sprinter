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
public class HistoriaDeUsuario implements Comparable<HistoriaDeUsuario>{
    
    //A quitar
    //private int id;
    private int puntuacion;
    //local
    private int prioridad;
    private int contadorVotos;
    private boolean estado;
    private String nombre;
    //local
    private String descripcion;
    //local
    private String puntosHistoria;
    //local
    private ArrayList<Criterio> listaCriterios;
    
    /*public HistoriaDeUsuario(){
    }*/
    
    public HistoriaDeUsuario(String descripcion, String puntosHistoria,
            int prioridad, ArrayList<Criterio> listaCriterios, String nombre){
        this.nombre = nombre;
        //this.id = id;
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
    
    public void terminarHU(int puntos){
        this.puntuacion = puntos;
        this.estado = true;
    }
    
    public int getPuntuacion(){
        return this.puntuacion;
    }
    
    public boolean getEstado(){
        return this.estado;
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
        /*System.out.println("HistoriaDeUsuario.compareTo() -> +
        Historia comparada: " + nombre + "<>" + o.nombre);*/
        if(contadorVotos != o.contadorVotos){
            /*System.out.println("HistoriaDeUsuario.compareTo() -> +
            Resultado por votos: " + (contadorVotos-o.contadorVotos));*/
            return contadorVotos - o.contadorVotos;
        }
        if(prioridad != o.prioridad){
            /*System.out.println("HistoriaDeUsuario.compareTo() -> +
            Resultado por prioridad: " + (prioridad-o.prioridad));*/
            return prioridad - o.prioridad;
        }
        /*System.out.println("HistoriaDeUsuario.compareTo() -> +
        Resultado por nombre: " + o.nombre.compareTo(nombre)); */
        return o.nombre.compareTo(nombre);
    }
}
