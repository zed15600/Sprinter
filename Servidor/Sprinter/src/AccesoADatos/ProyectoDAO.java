/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import Negocio.Entidades.Proyecto;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 * 
 * @author usuario
 */
public interface ProyectoDAO {
    public ArrayList<Proyecto> obtenerProyectos()throws ClassNotFoundException, SQLException ;
    public ArrayList<Proyecto> obtenerProyecto(String nombre)throws ClassNotFoundException, SQLException ;
}
