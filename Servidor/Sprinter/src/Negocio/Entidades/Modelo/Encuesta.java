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
    
    private ArrayList<ArrayList<String>> respuestas = new ArrayList<>();
    
    /**
     *
     * @param preguntasEncuesta
     */
    public Encuesta(ArrayList<Pregunta> preguntasEncuesta){
        for(Pregunta p : preguntasEncuesta){
            preguntas.add(p.clone());
        }
    }
    
    /**
     * HOLA
     */
    public void empezarEncuesta(){
        preguntaActual = 1;
    }
    
    /**
     *
     * @return
     */
    public boolean siguientePregunta(){
        preguntaActual ++;
        return preguntaActual > preguntas.size();
    }

    /**
     *
     * @return
     */
    public int getNumeroPreguntaActual() {
        return preguntaActual;
    }
    
    public Pregunta getPreguntaActual(int id){
        return preguntas.get(id);
    }
    
    /**
     *
     */
    public void agregarJugador(){
        respuestas.add(new ArrayList<>());
    }
    
    /**
     *
     * @param jugador
     * @param opcion
     * @return
     */
    public boolean registrarRespuesta(int jugador, String opcion){
        ArrayList<String> respuestasDeJugador = respuestas.get(jugador-1);
        while((respuestasDeJugador.size()+1)<preguntaActual){
            respuestasDeJugador.add(null);
        }
        if(respuestasDeJugador.size()==(preguntaActual-1)){
            respuestasDeJugador.add(opcion);
        }
        return preguntaActual >= preguntas.size();
    }
}
