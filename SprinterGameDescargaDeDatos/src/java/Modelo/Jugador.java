/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Modelo;

import java.util.ArrayList;

/**
 *
 * @author Ricardo Azopardo
 */
public class Jugador {
    String nombreJugador;
    String idJugador;
    ArrayList<String> respuestas;

    public Jugador(String nombreJugador, String idJugador,
            ArrayList<String> respuestas) {
        this.nombreJugador = nombreJugador;
        this.idJugador = idJugador;
        this.respuestas = respuestas;
    }

    public String getNombreJugador() {
        return nombreJugador;
    }

    public String getIdJugador() {
        return idJugador;
    }

    public ArrayList<String> getRespuestas() {
        return respuestas;
    }
}
