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
 * Singleton de la conexión a la base de datos, devuelve la conexión y tiene el
 * método conectar.
 * @author Ricardo Azopardo
 */
public final class ConexionSingletonMySQL {
    
    private static Connection conexionSingleton;
    
    private ConexionSingletonMySQL(){}
    
    /**
     * Método Para Hacer la Conexión a la Base de Datos de MySQL.
     * IP: sprinter-game-db.c7twxi4xnwzx.sa-east-1.rds.amazonaws.com
     * Puerto:3306
     * Base de Datos: sprinter
     * Conector: conformado por el conector jdbc de mysql, IP, puerto y bd.
     * Usuario: usuario
     * Contraseña: Azopardo234432qw
     */
    public static void conectar() {
        Connection conn = null;
        try {
        Class.forName("com.mysql.jdbc.Driver");
        String IP = "sprinter-game-db.c7twxi4xnwzx.sa-east-1.rds.amazonaws.com";
        String puerto = "3306";
        String baseDeDatos = "sprinter";
        String conector = "jdbc:mysql://" + IP + ":" + puerto + "/" + baseDeDatos;
        String usuario = "rrazopardc";
        String contraseña = "Azopardo234432qw";
        conn = DriverManager.getConnection(conector, usuario, contraseña);
        } catch (ClassNotFoundException | SQLException ex) {
            JOptionPane.showMessageDialog(null, ex, "Error en la conexión con la"
               + "base de datos: " + ex.getMessage(), JOptionPane.ERROR_MESSAGE);
        }        
        ConexionSingletonMySQL.conexionSingleton = conn;
    }
    
    /**
     * Método getter de la conexión a la base de datos.
     * @return conexión a la base de datos.
     * @throws ClassNotFoundException
     * @throws SQLException
     */
    public static Connection getConexionSingleton() throws ClassNotFoundException, 
    SQLException{
        return conexionSingleton;
    }
    
}
