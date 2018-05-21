/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio.ElementosConexión;

import Servicio.Mensajes.ProcesadorJSON;
import Servicio.Mensajes.JSONMensajes;
import Negocio.Procesos.IMensajes;

/**
 *
 * @author usuario
 */
public class Procesador implements IProceso{

    IProceso procesador;
    
    public Procesador(IMensajes tipo){
        if (tipo.getClass()==JSONMensajes.class){
        procesador = new ProcesadorJSON();
        }
    }
    
    @Override
    public String procesar(Object mensaje) {
        return procesador.procesar(mensaje);
    }    
}
