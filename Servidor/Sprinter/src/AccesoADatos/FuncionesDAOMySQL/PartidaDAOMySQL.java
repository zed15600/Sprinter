/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos.FuncionesDAOMySQL;

import AccesoADatos.ConexiónDBMySQL.ConexionMySQLSingleton;
import Negocio.Entidades.DAO.PartidaDAO;
import Negocio.Entidades.Modelo.Partida;
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
public class PartidaDAOMySQL implements PartidaDAO {

    @Override
    public void enviarResultadosPartida(Partida partida) {
        Connection c = ConexionMySQLSingleton.abrirConexion();
        Statement stmt = null;
        try {  
            stmt = c.createStatement();
            stmt.executeUpdate("{INSERT INTO Partidas (nombre_partida, estado,"
                    + " Proyectos_id_proyecto, puntuacion, scrumMaster) VALUES "
                    + "("+partida.getNombre() + ", " + partida.getEstado() + ", "
                    + partida.getProyecto().getNombre() + ", " 
                    + partida.calcularPuntuacion() + ", "  
                    + partida.getScrumMaster() + ")}");

        } catch (SQLException ex) {
            Logger.getLogger(ProyectoDAOMySQL.class.getName()).log(Level.SEVERE,
                    null, ex);
        } finally {
            if (stmt != null && c != null)
            ConexionMySQLSingleton.cerrar(stmt, c);
        }
    }
    
}
