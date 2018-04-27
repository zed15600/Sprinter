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
public class IntegranteScrumTeam extends Jugador {
    
    private ArrayList<Impedimento> listaImpedimento;
    
    public IntegranteScrumTeam(String nombre, int ID) {
        super(nombre, ID);
        this.listaImpedimento = new ArrayList<>();
    }
    
    public void agregarImpedimento(Impedimento impedimento){
    }
    
    public void quitarImpedimento(Impedimento impedimento){
    }
}
