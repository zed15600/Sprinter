/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades.Modelo;

import Negocio.Entidades.DAO.DAOFachada;
import java.util.concurrent.ThreadLocalRandom;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

/**
 *
 * @author usuario
 */
public class Configuracion {
    
    private final Map<Integer, Partida> mapaDePartidas;
    //local
    private final ArrayList<Proyecto> listaDeProyectos;
    private final ArrayList<Impedimento> impedimentos;
    private final ArrayList<Pregunta> preguntasDeEncuesta;
    private final DAOFachada fachadaImpl;

    public Configuracion(DAOFachada fachadaImpl){
        this.mapaDePartidas = new HashMap<>();
        this.fachadaImpl = fachadaImpl;
        listaDeProyectos = this.fachadaImpl.obtenerProyectos();
        impedimentos = this.fachadaImpl.obtenerImpedimentos();
        preguntasDeEncuesta = this.fachadaImpl.obtenerPreguntasEncuesta();
    }
    
    public String crearPartida(String nombreJugador, String deviceID, 
            String nombrePartida, String nombreProyecto){
        int codigo;
        Set keys = mapaDePartidas.keySet();
        do {
            codigo = ThreadLocalRandom.current().nextInt(100000, 999998 + 1);
        }while(keys.contains(codigo));
        Proyecto proyecto = this.fachadaImpl.obtenerProyecto(nombreProyecto);
        ScrumMaster scrumMaster = new ScrumMaster(nombreJugador, 0, deviceID);
        Partida partida = new Partida(codigo, nombrePartida, proyecto,
                scrumMaster, preguntasDeEncuesta);
        mapaDePartidas.put(codigo, partida);
        String codigoPartida = String.valueOf(codigo);
        return codigoPartida;
    }
    public Proyecto obtenerProyectoDePartida(int idPartida){
        return mapaDePartidas.get(idPartida).getProyecto();
    }
    
    public Partida obtenerPartida(int idPartida){
        return mapaDePartidas.get(idPartida);
    }
    
    public Collection<Partida> obtenerPartidas(){
        return mapaDePartidas.values();
    }
    
    public void quitarPartida(int idPartida){
        mapaDePartidas.remove(idPartida);
    }
    
    public void agregarProyecto(Proyecto proyecto){
        this.listaDeProyectos.add(proyecto);
    }
    
    public ArrayList<Proyecto> getListaDeProyectos(){
        return listaDeProyectos;
    }

    public ArrayList<Impedimento> getImpedimentos() {
        return impedimentos;
    }
}
