/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos.FuncionesDAOMySQL;

import AccesoADatos.ConexiónDBMySQL.ConexionMySQLSingleton;
import Negocio.Entidades.Modelo.Criterio;
import Negocio.Entidades.DAO.CriterioDAO;
import Negocio.Entidades.Modelo.HistoriaDeUsuario;
import Negocio.Entidades.DAO.HistoriaDeUsuarioDAO;
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
public class HistoriaDeUsuarioDAOMySQL implements HistoriaDeUsuarioDAO {
    
    private final CriterioDAO critImpl;
    
    public HistoriaDeUsuarioDAOMySQL(){
        critImpl = new CriterioDAOMySQL();
    }

    @Override
    public ArrayList<HistoriaDeUsuario> obtenerHistorias(int idProyecto) {
        ArrayList<HistoriaDeUsuario> historias = new ArrayList<>();
        Connection c = ConexionMySQLSingleton.obtenerConexion();
        try {
            try (Statement stmt = c.createStatement()) {
                ResultSet r = stmt.executeQuery
                        ("{call obtenerHistorias("+idProyecto+")}");
                while (r.next()){
                    int id =  r.getInt(1);
                    String desc = r.getString(2);
                    String puntos = String.valueOf(r.getInt(3));
                    int prioridad = r.getInt(4);
                    String nombre = r.getString(5);
                    ArrayList<Criterio> criterios = critImpl.obtenerCriterios(id);
                    
                    HistoriaDeUsuario historia = new HistoriaDeUsuario(desc,
                            puntos, prioridad, criterios, nombre);
                    historias.add(historia);
                }
            }
        } catch (SQLException ex) {
            Logger.getLogger
        (HistoriaDeUsuarioDAOMySQL.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        return historias;
    }
    
}
