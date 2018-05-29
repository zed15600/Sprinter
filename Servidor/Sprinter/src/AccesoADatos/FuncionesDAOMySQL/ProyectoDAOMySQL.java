/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos.FuncionesDAOMySQL;

import AccesoADatos.ConexiónDBMySQL.ConexionMySQLSingleton;
import Negocio.Entidades.Modelo.Backlog;
import Negocio.Entidades.DAO.HistoriaDeUsuarioDAO;
import Negocio.Entidades.DAO.ProyectoDAO;
import Negocio.Entidades.Modelo.Proyecto;
import java.sql.Connection;
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
public class ProyectoDAOMySQL implements ProyectoDAO {
    
    private final HistoriaDeUsuarioDAO impl;
    
    public ProyectoDAOMySQL(){
        impl = new HistoriaDeUsuarioDAOMySQL();
    }
    
    @Override
    public ArrayList<Proyecto> obtenerProyectos(){
        ArrayList<Proyecto> proyectos = new ArrayList<>();
        Connection c = ConexionMySQLSingleton.abrirConexion();
        Statement stmt = null;
        ResultSet r = null;
        try {  
            stmt = c.createStatement();
            r = stmt.executeQuery("{call obtenerTodosLosProyectos()}");
            while (r.next()){
                String nombre =  r.getString(1);
                String descripcion = r.getString(2);
                Proyecto proyecto = new Proyecto(nombre, descripcion);
                proyectos.add(proyecto);
            }
        } catch (SQLException ex) {
            Logger.getLogger(ProyectoDAOMySQL.class.getName()).log(Level.SEVERE,
                    null, ex);
        } finally {
            if (r != null && stmt != null && c != null)
            ConexionMySQLSingleton.cerrar(r, stmt, c);
        }
        return proyectos;
    }

    @Override
    public Proyecto obtenerProyecto(String nombre) {
        Proyecto proyecto = null;
        Connection c = ConexionMySQLSingleton.abrirConexion();
        Statement stmt = null;
        ResultSet r = null;
        try {      
            stmt = c.createStatement();
            r = stmt.executeQuery("{call obtenerProyecto(\""+nombre+
                    "\")}");
            while (r.next()){
                int id =  r.getInt(1);
                String descripcion = r.getString(2);
                int nSprints = r.getInt(3);
                int durSprints = r.getInt(4);
                r.close();
                Backlog backlog = new Backlog(impl.obtenerHistorias(id));
                proyecto = new Proyecto(id, nombre, descripcion, durSprints,
                        backlog, nSprints);
            }
            
        } catch (SQLException ex) {

        } finally {
            if (r != null && stmt != null && c != null)
            ConexionMySQLSingleton.cerrar(r, stmt, c);
        }
        return proyecto;
    }
}
