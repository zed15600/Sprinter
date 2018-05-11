/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Configuracion;
import Negocio.Entidades.Proyecto;
import Negocio.Entidades.Sprint;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class ControladorProyecto extends Controlador {
    
    public ControladorProyecto(IMensajes respuestas,
            Configuracion configuracion){
        super(respuestas, configuracion);
    }

    void terminarSprint(int partidaID) {
        Proyecto p = configuracion.obtenerProyectoDePartida(partidaID);
        Sprint actual = p.getSprints().get(p.getSprintActual()-1);
        actual.terminarSprint();
        p.nextSprint();
    }

    String enviarProyecto(int partidaID) {
        Proyecto proyecto = configuracion.obtenerProyectoDePartida(partidaID);
        return respuestas.traerProyecto(proyecto);
    }

    String sprintPlanning(int partidaID) {
        Proyecto p = configuracion.obtenerProyectoDePartida(partidaID);
        ArrayList<Sprint> sprints = p.getSprints();
        int actual = p.getSprintActual();
        int restantes = Math.abs(sprints.size() - actual);
        return respuestas.sprintPlanning(restantes, actual);
    }
    
    
}
