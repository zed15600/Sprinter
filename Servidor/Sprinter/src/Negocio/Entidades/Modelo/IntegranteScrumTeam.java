/*
* To change this license header/*, choose License Headers in Project Properties.
* To change this template file, choose Tools | Templates
* and open the template in the editor.
*/
package Negocio.Entidades.Modelo;

import java.util.ArrayList;

/*
 *
 * @author usuario
 */
public class IntegranteScrumTeam extends Jugador {
    
    String avatar;
    private final boolean estado; //true -> activo
    private boolean votar; //true -> puede votar
    private Impedimento Impedimento;
    
    public IntegranteScrumTeam(String nombre, int assignedID, String avatar,
            String deviceID) {
        super(nombre, assignedID, deviceID);
        this.avatar = avatar;
        votar = true;
        estado = true;
    }
    
    public String getAvatar(){
        return avatar;
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

    public Impedimento getImpedimento() {
        return Impedimento;
    }

    public void setImpedimento(Impedimento Impedimento) {
        this.Impedimento = Impedimento;
    }
}
