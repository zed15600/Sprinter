/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;
/**
 *
 * @author usuario
 */
public class Procesador implements IProceso{

    IProceso procesador;
    
    public Procesador(String tipo){
        if (tipo.equals("json")){
            procesador = new ProcesadorJSON();
        }
    }
    
    @Override
    public String procesar(Object mensaje) {
        return procesador.procesar(mensaje);
    }    
}
