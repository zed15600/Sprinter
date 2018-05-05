/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import Negocio.Entidades.ProyectoDAO;
import Negocio.Entidades.Proyecto;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class ProyectoDAOImpl implements ProyectoDAO {

    @Override
    public ArrayList<Proyecto> obtenerProyectos() throws ClassNotFoundException, SQLException {
        ResultSet r = ConexionSingleton.getConexionSingleton().createStatement().executeQuery("{call obtenerTodosLosProyectos()}");
        ArrayList<Proyecto> proyectos = new ArrayList<>();
        while (r.next()){
            String nombre =  r.getString(5);
            String descripcion = r.getString(2);
            int nSprints = r.getInt(3);
            int durSprints = r.getInt(4);
            Proyecto proyecto = new Proyecto(nombre, descripcion, durSprints, null, nSprints);
            proyectos.add(proyecto);
        }
        return proyectos;
    }

    @Override
    public ArrayList<Proyecto> obtenerProyecto(String nombre) {
        return null;
    }
    
}
