/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades.DAO;

import Negocio.Entidades.Modelo.Impedimento;
import Negocio.Entidades.Modelo.Pregunta;
import Negocio.Entidades.Modelo.Proyecto;
import java.util.ArrayList;

/**
 *
 * @author Ricardo
 */
public interface DAOFachada {
    public ArrayList<Proyecto> obtenerProyectos();
    public ArrayList<Impedimento> obtenerImpedimentos();
    public Proyecto obtenerProyecto(String nombre);
    public ArrayList<Pregunta> obtenerPreguntasEncuesta();
}
