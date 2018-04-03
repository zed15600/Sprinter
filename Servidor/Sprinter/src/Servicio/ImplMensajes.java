/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Entidades.Proyecto;
import Negocio.Entidades.SprintBacklog;
import Negocio.Procesos.InterfazMensajes;

/**
 *
 * @author usuario
 */
public class ImplMensajes implements InterfazMensajes {

    @Override
    public String terminarDia(Proyecto p) {
        return Mensaje.terminarDia(p);
    }

    @Override
    public String terminarSprint(SprintBacklog sprntBcklg) {
        return Mensaje.terminarSprint(sprntBcklg);
    }

    @Override
    public String determinarVictoria(boolean resultado) {
        return Mensaje.determinarVictoria(resultado);
    }

    @Override
    public String scrumPlanning(String nombre, String descripcion) {
        return Mensaje.scrumPlanning(nombre, descripcion);
    }
    
}
