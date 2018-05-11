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
    private boolean estado; //true -> activo
    private boolean votar; //true -> puede votar
    private ArrayList<Impedimento> listaImpedimento;
    
    public void votar(HistoriaDeUsuario HU){
    }
    
    public IntegranteScrumTeam(String nombre, int ID, String avatar) {
        super(nombre, ID);
        this.avatar = avatar;
        listaImpedimento = new ArrayList<>();
        votar = true;
        estado = true;
    }
    
    public String getAvatar(){
        return avatar;
    }
    
    public void agregarImpedimento(Impedimento impedimento){
    }
    
    public void quitarImpedimento(Impedimento impedimento){
    }
    
    public boolean getEstado(){
        return estado;
    }
    
    public boolean getVotar(){
        return votar;
    }
    
    public void setVotar(boolean votar){
        this.votar = votar;
    }
}
