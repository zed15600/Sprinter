/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.HistoriaDeUsuario;
import Negocio.Entidades.Backlog;
import Negocio.Entidades.IntegranteScrumTeam;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public interface IMensajes {
    public String terminarSprint(Backlog sprntBcklg);
    public String determinarVictoria(boolean resultado);
    public String traerProyecto(String nombre, String descripcion, ArrayList<HistoriaDeUsuario> historias);
    public String sprintPlanning(int sprintsRestantes, int numeroDeSprint);
    public String unirsePartida(int jugadorId, boolean aceptado, String avatar);
    public String actualizarEstadoJugador(boolean votar, HistoriaDeUsuario[] posibles);
    public String estadoVotacion(boolean votamos, int tipoVoto);
    public String enviarVotos(String[][] listaVotos);
    public String enviarNombresProyectos();
    public String enviarCodigoPartida(int codigo);
    public String enviarJugadoresConAvatares(ArrayList<IntegranteScrumTeam> jugadores);
}
