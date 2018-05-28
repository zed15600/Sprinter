/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos.FuncionesDAOMySQL;

import AccesoADatos.ConexiónDBMySQL.ConexionMySQLSingleton;
import Negocio.Entidades.DAO.PreguntaDAO;
import Negocio.Entidades.Modelo.Pregunta;
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
public class PreguntaDAOMySQL implements PreguntaDAO{

    @Override
    public ArrayList<Pregunta> obtenerPreguntas() {
        ArrayList<Pregunta> preguntas = new ArrayList<>();
        Connection c = ConexionMySQLSingleton.abrirConexion();
        Statement s = null;
        ResultSet r = null;
        try {  
            s = c.createStatement();
            r = s.executeQuery("{call obtenerTodasLasPreguntas()}");
            while (r.next()){
                int id = r.getInt(1);
                String pregunta =  r.getString(2);
                String B = r.getString(4);
                String C = r.getString(5);
                String[] respuestas = new String[]{r.getString(3), B!=null?B:"",
                    C!=null?C:"", r.getString(6)};
                boolean tipo = r.getBoolean(7);
                Pregunta p = new Pregunta(id, pregunta, respuestas, tipo);
                preguntas.add(p);
            }
        } catch (SQLException ex) {
            Logger.getLogger(ProyectoDAOMySQL.class.getName()).log(Level.SEVERE,
                    null, ex);
        } finally {
            if (r != null && s != null && c != null)
            ConexionMySQLSingleton.cerrar(r, s, c);
        }
        return preguntas;
    }
    
}
