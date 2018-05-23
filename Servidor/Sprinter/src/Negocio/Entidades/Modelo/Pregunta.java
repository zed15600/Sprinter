/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades.Modelo;

/**
 *
 * @author usuario
 */
public class Pregunta {
    
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
}
