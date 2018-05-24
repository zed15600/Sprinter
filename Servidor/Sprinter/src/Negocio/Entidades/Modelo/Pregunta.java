/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades.Modelo;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author usuario
 */
public class Pregunta implements Cloneable{
    
    private int id;
    private String enunciado;
    private String[] respuestas;
    
    public Pregunta(int id, String enunciado, String[] respuestas){
        this.id = id;
        this.enunciado = enunciado;
        this.respuestas = respuestas;
    }

    public int getId() {
        return id;
    }

    public String getEnunciado() {
        return enunciado;
    }

    public String[] getRespuestas() {
        return respuestas;
    }
    
    @Override
    public Pregunta clone(){
        try {
            return (Pregunta) super.clone();
        } catch (CloneNotSupportedException ex) {
            Logger.getLogger(Pregunta.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }
}
