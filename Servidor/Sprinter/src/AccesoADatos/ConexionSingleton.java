/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import javax.swing.JOptionPane;

/**
 *
 * @author usuario
 */
public class ConexionSingleton {
    
    private static Connection conexionSingleton;
    
    /**
     * Método Para Hacer la Conexión a la Base de Datos de MySQL.
     * @throws ClassNotFoundException
     * @throws SQLException
     */
    public static void conectar() throws ClassNotFoundException, SQLException {
        Connection conn = null;
        try {
        Class.forName("com.mysql.jdbc.Driver");
        String servidor = "jdbc:mysql://localhost:3306/sprinter";
        String usuario = "root";
        String contraseña = "Azopardo234432qw";
        conn = DriverManager.getConnection(servidor, usuario, contraseña);
        } catch (ClassNotFoundException | SQLException ex) {
            JOptionPane.showMessageDialog(null, ex, "Error en la conexión con la"
                    + "base de datos: " + ex.getMessage(), JOptionPane.ERROR_MESSAGE);
        }        
        ConexionSingleton.conexionSingleton = conn;
    }
    
    public static Connection getConexionSingleton() throws ClassNotFoundException, SQLException{
        conectar();
        return conexionSingleton;
    }
    
}
