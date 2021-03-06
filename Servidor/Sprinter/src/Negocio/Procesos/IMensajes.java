/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Modelo.HistoriaDeUsuario;
import Negocio.Entidades.Modelo.Impedimento;
import Negocio.Entidades.Modelo.IntegranteScrumTeam;
import Negocio.Entidades.Modelo.Pregunta;
import Negocio.Entidades.Modelo.Proyecto;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public interface IMensajes {
    public String determinarVictoria(boolean resultado);
    public String traerProyecto(Proyecto p);
    public String sprintPlanning(int sprintsRestantes, int numeroDeSprint);
    public String unirsePartida(IntegranteScrumTeam jugador, boolean aceptado);
    public String actualizarEstadoJugador(boolean votar, String estadoPartida,
            HistoriaDeUsuario[] posibles, Impedimento imp);
    public String estadoVotacion(boolean votamos, int tipoVoto);
    public String enviarVotos(String[][] listaVotos);
    public String enviarNombresProyectos(ArrayList<Proyecto> listaDeProyectos);
    public String enviarCodigoPartida(String codigo);
    public String enviarJugadoresConAvatares
        (ArrayList<IntegranteScrumTeam> jugadores);
    public String empezarEncuesta(Pregunta pregunta);
    public String siguientePregunta(boolean terminamos, Pregunta pregunta);
    public String responderRespuesta(boolean terminado, boolean tipoPregunta);
}
