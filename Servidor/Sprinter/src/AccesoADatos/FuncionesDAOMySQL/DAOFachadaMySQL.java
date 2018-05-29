/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos.FuncionesDAOMySQL;

import Negocio.Entidades.DAO.DAOFachada;
import Negocio.Entidades.DAO.ImpedimentoDAO;
import Negocio.Entidades.DAO.PartidaDAO;
import Negocio.Entidades.DAO.PreguntaDAO;
import Negocio.Entidades.DAO.ProyectoDAO;
import Negocio.Entidades.Modelo.Impedimento;
import Negocio.Entidades.Modelo.Partida;
import Negocio.Entidades.Modelo.Pregunta;
import Negocio.Entidades.Modelo.Proyecto;
import java.util.ArrayList;
import java.util.Map;

/**
 *
 * @author usuario
 */
public class DAOFachadaMySQL implements DAOFachada {
    
    private final ProyectoDAO proDAO;
    private final ImpedimentoDAO impDAO;
    private final PreguntaDAO preDAO;
    private PartidaDAO parDAO;
    
    public DAOFachadaMySQL(){
        this.proDAO = new ProyectoDAOMySQL();
        this.impDAO = new ImpedimentoDAOMySQL();
        this.preDAO = new PreguntaDAOMySQL();
    }
    
    @Override
    public ArrayList<Proyecto> obtenerProyectos() {
        return proDAO.obtenerProyectos();
    }

    @Override
    public ArrayList<Impedimento> obtenerImpedimentos() {
        return impDAO.obtenerImpedimentos();
    }

    @Override
    public Proyecto obtenerProyecto(String nombre) {
        return proDAO.obtenerProyecto(nombre);
    }

    @Override
    public ArrayList<Pregunta> obtenerPreguntasEncuesta() {
        return preDAO.obtenerPreguntas();
    }

    @Override
    public void enviarResultadosPartida(Partida partida, Map mapa) {
        parDAO = new PartidaDAOMySQL(partida, mapa);
        new Thread(parDAO).start();
    }
    
    
    
}
