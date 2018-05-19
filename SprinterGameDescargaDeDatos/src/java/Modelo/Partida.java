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
public class Partida {
    
    private final ArrayList<Jugador> jugadores;
    private final String scrumMaster;
    private final String nombrePartida;
    private final int idPartida;
    private final int puntuacionPromedio;
    private final boolean estado;

    public Partida(ArrayList<Jugador> jugadores, String scrumMaster,
            String nombrePartida, int idPartida, int puntuacionPromedio,
            boolean estado) {
        this.jugadores = jugadores;
        this.scrumMaster = scrumMaster;
        this.nombrePartida = nombrePartida;
        this.idPartida = idPartida;
        this.puntuacionPromedio = puntuacionPromedio;
        this.estado = estado;
    }

    public ArrayList<Jugador> getJugadores() {
        return jugadores;
    }

    public String getScrumMaster() {
        return scrumMaster;
    }

    public String getNombrePartida() {
        return nombrePartida;
    }

    public int getIdPartida() {
        return idPartida;
    }

    public int getPuntuacionPromedio() {
        return puntuacionPromedio;
    }

    public boolean isEstado() {
        return estado;
    }
    
    
}
