/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos.FuncionesDAOMySQL;

import Negocio.Entidades.DAO.DAOFachada;
import Negocio.Entidades.DAO.ImpedimentoDAO;
import Negocio.Entidades.DAO.ProyectoDAO;
import Negocio.Entidades.Modelo.Impedimento;
import Negocio.Entidades.Modelo.Proyecto;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class DAOFachadaMySQL implements DAOFachada {
    
    private final ProyectoDAO proDAO;
    private final ImpedimentoDAO impDAO;
    
    public DAOFachadaMySQL(){
        this.proDAO = new ProyectoDAOMySQL();
        this.impDAO = new ImpedimentoDAOMySQL();
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
    
}