/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Modelo.Configuracion;
import Negocio.Entidades.Modelo.Encuesta;
import Negocio.Entidades.Modelo.Partida;

/**
 *
 * @author usuario
 */
public class ControladorEncuesta extends Controlador{
    
    public ControladorEncuesta(IMensajes respuestas, Configuracion configuracion) {
        super(respuestas, configuracion);
    }
    
    public String empezarEncuesta(int partidaID){
        Partida p = configuracion.obtenerPartida(partidaID);
        p.setEstado("encuesta");
        Encuesta e = p.getEncuesta();
        e.empezarEncuesta();
        return respuestas.empezarEncuesta(e.getPreguntaActual
            (e.getNumeroPreguntaActual()-1));
    }
    
    public String siguientePregunta(int partidaID){
        Partida p = configuracion.obtenerPartida(partidaID);
        Encuesta e = p.getEncuesta();
        boolean terminamos = e.siguientePregunta();
        return respuestas.siguientePregunta(terminamos,
                e.getPreguntaActual(e.getNumeroPreguntaActual()-1));
    }
    
}
