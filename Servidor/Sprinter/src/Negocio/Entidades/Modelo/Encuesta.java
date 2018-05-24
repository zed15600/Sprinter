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
public class Encuesta {
    
    private ArrayList<Pregunta> preguntas = new ArrayList<>();
    private int preguntaActual;
    
    public Encuesta(ArrayList<Pregunta> preguntasEncuesta){
        for(Pregunta p : preguntasEncuesta){
            preguntas.add(p.clone());
        }
    }
    
    public void empezarEncuesta(){
        preguntaActual = 1;
    }
    
    public boolean siguientePregunta(){
        preguntaActual ++;
        return preguntaActual <= preguntas.size();
    }

    public int getNumeroPreguntaActual() {
        return preguntaActual;
    }
    
    public Pregunta getPreguntaActual(int id){
        return preguntas.get(id);
    }
}
