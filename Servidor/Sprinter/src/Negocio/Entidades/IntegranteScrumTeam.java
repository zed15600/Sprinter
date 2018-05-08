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
    
    String avatar;
    private ArrayList<Impedimento> listaImpedimento;
    
    public IntegranteScrumTeam(String nombre, int ID, String avatar) {
        super(nombre, ID);
        this.avatar = avatar;
        this.listaImpedimento = new ArrayList<>();
    }
    
    public String getAvatar(){
        return avatar;
    }
    
    public void agregarImpedimento(Impedimento impedimento){
    }
    
    public void quitarImpedimento(Impedimento impedimento){
    }
}
