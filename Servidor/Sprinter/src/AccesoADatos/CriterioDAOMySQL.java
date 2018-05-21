/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import Negocio.Entidades.Criterio;
import Negocio.Entidades.CriterioDAO;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Implementación del DAO de la clase Criterio.
 * @author Ricardo Azopardo
 */
public class CriterioDAOMySQL implements CriterioDAO {

    /**
     * Consulta la base de datos MySQL, llama el procedimiento obtenerCriterios.
     * Trae los criterios de aceptación de la historia de usuario con el ID
     * proporcionado.
     * @param idHU id de la historia de usuario en la base de datos.
     * @return ArrayList con todos los Criterios de la Historia de Usuario.
     */
    @Override
    public ArrayList<Criterio> obtenerCriterios(int idHU){
        ArrayList<Criterio> criterios = new ArrayList<>();
        Connection c = ConexionMySQL.obtenerConexion();
        try {
            try (Statement stmt = c.createStatement(); 
                    ResultSet criteriosObtenidos = stmt
                    .executeQuery("{call obtenerCriterios("+idHU+")}")) {
                while (criteriosObtenidos.next()){
                    Criterio criterio = new Criterio(criteriosObtenidos.getString(1));
                    criterios.add(criterio);
                }
            }
        } catch (SQLException ex) {
            Logger.getLogger(CriterioDAOMySQL.class.getName()).log(Level.SEVERE,
                    null, ex);
        }
        return criterios;
    }
    
}
