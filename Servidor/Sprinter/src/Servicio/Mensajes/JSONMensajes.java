/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio.Mensajes;

import Negocio.Entidades.Modelo.Criterio;
import Negocio.Entidades.Modelo.HistoriaDeUsuario;
import Negocio.Entidades.Modelo.Impedimento;
import Negocio.Entidades.Modelo.IntegranteScrumTeam;
import Negocio.Entidades.Modelo.Pregunta;
import Negocio.Entidades.Modelo.Proyecto;
import Negocio.Procesos.IMensajes;
import java.util.ArrayList;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

/**
 *
 * @author usuario
 */
public class JSONMensajes implements IMensajes {

    /**
     * Recibe un booleano y retorna un String con el código para la vista Fin
     * del Juego y el resultado de la partida (Victoria o Derrota), en formato
     * Json.
     *
     * @param resultado
     * @return
     */
    @Override
    public String determinarVictoria(boolean resultado) {
        JSONObject json = new JSONObject();
        json.put("codigo", 0002);
        json.put("resultado", resultado ? "Victoria" : "Derrota");
        return json.toJSONString();
    }

    /**
     * Retorna el String en formato Json con los datos del proyecto: nombre y
     * descripcion.
     *
     * @param p
     * @return string en formato Json con el codigo 0004 para la vista de Scrum
     * Planning.
     */
    @Override
    public String traerProyecto(Proyecto p) {
        JSONObject json = new JSONObject();
        //json.put("codigo", 0004);
        json.put("nombre", p.getNombre());
        json.put("descripcion", p.getDescripcion());
        json.put("duracionSprints", p.getDuracionDeSprints());
        json.put("numeroSprints", p.getNumeroSprints());
        JSONArray jHUs = new JSONArray();
        for (HistoriaDeUsuario h : p.getProductBacklog().getHistorias()) {
            JSONObject historia = new JSONObject();
            historia.put("nombre", h.getNombre());
            historia.put("descripcion", h.getDescripcion());
            historia.put("puntos", h.getPuntosHistoria());
            historia.put("estado", h.getEstado());
            historia.put("prioridad", h.getPrioridad());
            ArrayList<Criterio> criteriosH = h.getListaCriterios();
            JSONArray criterios = new JSONArray();
            for (Criterio crit : criteriosH) {
                criterios.add(crit.getDescripcion());
            }
            historia.put("criterios", criterios);
            jHUs.add(historia);
        }
        json.put("historias", jHUs);
        return json.toJSONString();
    }

    /**
     *
     * @param sprintsRestantes
     * @param numeroDeSprint
     * @return
     */
    @Override
    public String sprintPlanning(int sprintsRestantes, int numeroDeSprint) {
        JSONObject json = new JSONObject();
        json.put("codigo", 0006);
        json.put("restantes", sprintsRestantes);
        json.put("numero", numeroDeSprint);
        return json.toJSONString();
    }

    @Override
    public String unirsePartida(IntegranteScrumTeam jugador, boolean aceptado) {
        JSONObject json = new JSONObject();
        
        json.put("jugadorID", jugador.getAssignedID());
        json.put("aceptado", aceptado);
        json.put("avatar", jugador.getAvatar());
        return json.toJSONString();
    }

    @Override
    public String actualizarEstadoJugador(boolean votar, String estadoPartida,
            HistoriaDeUsuario[] posibles, Impedimento imp) {
        JSONObject json = new JSONObject();
        JSONArray HUs = new JSONArray();
        for (HistoriaDeUsuario posible : posibles) {
            HUs.add(posible.getNombre());
        }
        json.put("HUs", HUs);
        json.put("votacion", votar);
        json.put("estadoPartida", estadoPartida);
        if (imp != null) {
            json.put("nombre", imp.getNombre());
            json.put("descripcion", imp.getEfecto());
        }
        json.put("afectado", imp != null);
        return json.toJSONString();
    }

    @Override
    public String estadoVotacion(boolean votamos, int tipoVoto) {
        JSONObject json = new JSONObject();
        json.put("votamos", votamos);
        json.put("tipoVotacion", tipoVoto);
        return json.toJSONString();
    }

    @Override
    public String enviarVotos(String[][] listaVotos) {
        JSONObject json = new JSONObject();
        JSONArray hID = new JSONArray();
        JSONArray votos = new JSONArray();
        for (int i = 0; i < listaVotos[0].length; i++) {
            hID.add(listaVotos[0][i]);
            votos.add(Integer.valueOf(listaVotos[1][i]));
        }
        json.put("historiasID", hID);
        json.put("votos", votos);
        /*System.out.println("JSONMensajes.enviarVotos() -> Json: " + 
        json.toJSONString());*/
        return json.toJSONString();
    }

    @Override
    public String enviarNombresProyectos(ArrayList<Proyecto> listaDeProyectos) {
        JSONObject json = new JSONObject();
        JSONArray proyectosN = new JSONArray();
        ArrayList<Proyecto> proyectos = listaDeProyectos;
        for (Proyecto p : proyectos) {
            proyectosN.add(p.getNombre());
        }
        json.put("proyectos", proyectosN);
        return json.toJSONString();
    }

    @Override
    public String enviarCodigoPartida(String codigo) {
        JSONObject json = new JSONObject();
        json.put("id", codigo);
        return json.toJSONString();
    }

    @Override
    public String enviarJugadoresConAvatares(ArrayList<IntegranteScrumTeam> jugadores) {

        JSONObject json = new JSONObject();
        JSONArray jJugadores = new JSONArray();
        JSONArray avatares = new JSONArray();

        for (IntegranteScrumTeam j : jugadores) {
            jJugadores.add(j.getNombre());
            avatares.add(j.getAvatar());
        }

        json.put("jugadores", jJugadores);
        json.put("avatares", avatares);
        return json.toJSONString();
    }

    //POR IMPLEMENTAR
    /*
    Recibe un Proyecto y retorna un String con el código para la vista Sprint, 
    el sprint actual, el día actual del proyecto y una lista con los identificadores
    de las historias de usaurio correspondientes, en formato Json.
    
    protected static String terminarDia(Proyecto p){
        JSONObject json = new JSONObject();
        json.put("codigo", 0003);
        json.put("sprintActual", p.getSprintActual());
        json.put("diaActual", p.getDiaActual());
        JSONArray HUs = new JSONArray();
        ArrayList<HistoriaDeUsuario> historias;
        Sprint sprint = p.getSprints().get(p.getSprintActual());
        historias = sprint.getSprintBacklog().getHistorias();
        for(HistoriaDeUsuario historia: historias){
            HUs.add(historia.getId());
        }
        json.put("HUs", HUs);
        return json.toJSONString();
    }
     */
 /*
    Recibe un SprintBacklog y retorna un String con el código para la vista 
    Retrospectiva y una lista con los identificadores de las historias de usuario,
    en formato Json.
    
    protected static String terminarSprint(Backlog sprntBcklg){
        JSONObject json = new JSONObject();
        json.put("codigo", 0001);
        JSONArray HUs = new JSONArray();
        ArrayList<HistoriaDeUsuario> historias = sprntBcklg.getHistorias();
        for(HistoriaDeUsuario historia: historias){
            if(historia.getEstado()){
                HUs.add(historia.getPuntuacion());
            }
        }
        json.put("HUs", HUs);
        return json.toJSONString();
    }
     */

    @Override
    public String empezarEncuesta(Pregunta pregunta) {
        JSONObject json = new JSONObject();
        ponerPregunta(json, pregunta);
        return json.toJSONString();
    }

    @Override
    public String siguientePregunta(boolean terminamos, Pregunta pregunta) {
        JSONObject json = new JSONObject();
        json.put("terminado", terminamos);
        ponerPregunta(json, pregunta);
        return json.toJSONString();
    }
    
    @Override
    public String responderRespuesta(boolean terminado, int preguntaActual) {
        JSONObject json = new JSONObject();
        json.put("terminamos", terminado);
        if(!terminado){
            json.put("pregunta", preguntaActual);
        }
        return json.toJSONString();
    }
    
    
    
    
    
    
    public void ponerPregunta(JSONObject json, Pregunta p){
        json.put("pregunta", p.getEnunciado());
        JSONArray arr = new JSONArray();
        for(String s : p.getRespuestas()){
            arr.add(s);
        }
        json.put("respuestas", arr);
    }

}
