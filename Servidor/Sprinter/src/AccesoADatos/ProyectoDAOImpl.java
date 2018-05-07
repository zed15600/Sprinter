/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import Negocio.Entidades.Backlog;
import Negocio.Entidades.HistoriaDeUsuarioDAO;
import Negocio.Entidades.ProyectoDAO;
import Negocio.Entidades.Proyecto;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author usuario
 */
public class ProyectoDAOImpl implements ProyectoDAO {
    
    private HistoriaDeUsuarioDAO impl;
    
    public ProyectoDAOImpl(){
        impl = new HistoriaDeUsuarioDAOImpl();
    }
    
    @Override
    public ArrayList<Proyecto> obtenerProyectos(){
        ArrayList<Proyecto> proyectos = new ArrayList<>();
        try {
            ResultSet r = ConexionSingleton.getConexionSingleton().createStatement().executeQuery("{call obtenerTodosLosProyectos()}");
            while (r.next()){
                String nombre =  r.getString(1);
                String descripcion = r.getString(2);
                Proyecto proyecto = new Proyecto(nombre, descripcion);
                proyectos.add(proyecto);
            }
        } catch (ClassNotFoundException | SQLException ex) {
            Logger.getLogger(ProyectoDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return proyectos;
    }

    @Override
    public Proyecto obtenerProyecto(String nombre) {
        Proyecto proyecto = null;
        try {
            Statement stmt = ConexionSingleton.getConexionSingleton().createStatement();
            ResultSet r = stmt.executeQuery("{call obtenerProyecto(\""+nombre+"\")}");
            while (r.next()){
                int id =  r.getInt(1);
                String descripcion = r.getString(2);
                int nSprints = r.getInt(3);
                int durSprints = r.getInt(4);
                Backlog backlog = new Backlog(impl.obtenerHistorias(id));
                proyecto = new Proyecto(nombre, descripcion, durSprints, backlog, nSprints);
            }
        } catch (ClassNotFoundException | SQLException ex) {
            Logger.getLogger(ProyectoDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return proyecto;
    }
}
