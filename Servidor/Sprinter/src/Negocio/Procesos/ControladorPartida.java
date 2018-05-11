/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Configuracion;
import Negocio.Entidades.Proyecto;

/**
 *
 * @author usuario
 */
public class ControladorPartida extends Controlador {
    
    public ControladorPartida(IMensajes respuestas,Configuracion configuracion){
        super(respuestas, configuracion);
    }
    
    public String determinarVictoria(int partidaID){
        Proyecto p = configuracion.obtenerProyectoDePartida(partidaID);
        boolean resultado = p.terminarJuego();
        configuracion.quitarPartida(partidaID);
        return respuestas.determinarVictoria(resultado);
    }
    
}
