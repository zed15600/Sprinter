/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio;

import java.util.ArrayList;

/**
 *
 * @author usuario
 */
class Proyecto {
    
    private ArrayList<Sprint> listaDeSprints;
    private ProductBacklog productBacklog;
    int tiempoLimite;
    
    public Proyecto (ArrayList<Sprint> listaDeSprints, ProductBacklog productBacklog,
    int tiempoLimite){
        this.listaDeSprints = listaDeSprints;
        this.productBacklog = productBacklog;
        this.tiempoLimite = tiempoLimite;
    }
    
    public void terminarJuego(){        
    }
    
}
