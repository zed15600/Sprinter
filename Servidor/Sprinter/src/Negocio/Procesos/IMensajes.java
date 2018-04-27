/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Criterio;
import Negocio.Entidades.HistoriaDeUsuario;
import Negocio.Entidades.Proyecto;
import Negocio.Entidades.SprintBacklog;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public interface IMensajes {
    
    public String terminarDia(Proyecto p);
    public String terminarSprint(SprintBacklog sprntBcklg);
    public String determinarVictoria(boolean resultado);
    public String traerProyecto(String nombre, String descripcion, ArrayList<HistoriaDeUsuario> historias);
    public String enviarHU(String descripcion, String puntos, String prioridad,
    ArrayList<Criterio> criterios, boolean estado);
    public String sprintPlanning(int sprintsRestantes, int numeroDeSprint);
    public String unirsePartida(int partidaID, int jugadorId, boolean aceptado);
}
