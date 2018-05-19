package AccesoADatos;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
import Modelo.IConexionBaseDeDatos;
import Modelo.Partida;
import Modelo.PartidaDAO;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;

/**
 * Singleton de la conexión a la base de datos, devuelve la conexión y tiene el
 * método conectar.
 * @author Ricardo Azopardo
 */
public final class ConexionMySQL implements IConexionBaseDeDatos{
    
    private static Connection conexion;
    private final PartidaDAO implPartida;
    
    public ConexionMySQL(){
        implPartida = new PartidaDAOMySQL();
    }
    /**
     * Método Para Hacer la Conexión a la Base de Datos de MySQL.
     * IP: sprinter-game-db.c7twxi4xnwzx.sa-east-1.rds.amazonaws.com
     * Puerto:3306
     * Base de Datos: sprinter
     * Conector: conformado por el conector jdbc de mysql, IP, puerto y bd.
     * Usuario: usuario
     * Contraseña: Azopardo234432qw
     */
    @Override
    public void conectar() {
        Connection conn = null;
        try {
            Class.forName("com.mysql.jdbc.Driver");
            String IP = "sprinter-game-db.c7twxi4xnwzx.sa-east-1.rds.amazonaws.com";
            String puerto = "3306";
            String baseDeDatos = "sprinter";
            String conector = "jdbc:mysql://"
                + IP
                + ":" + puerto 
                + "/" + baseDeDatos;
            String usuario = "rrazopardc";
            String contraseña = "Azopardo234432qw";
            try {
                conn = DriverManager.getConnection(conector, usuario, contraseña);
            } catch (SQLException ex) {
                Logger.getLogger(ConexionMySQL.class.getName()).log(Level.SEVERE, null, ex);
            }
        } catch (ClassNotFoundException ex) {                 
                JOptionPane.showMessageDialog(null, ex,
                        "Error en la conexión con la " + "base de datos: "
                            + ex.getMessage(), JOptionPane.ERROR_MESSAGE);        
        }
        ConexionMySQL.conexion = conn;
    }
        
    public static Statement crearDeclaracion() throws SQLException {
        return conexion.createStatement();
    }
    
    @Override
    public ArrayList<Partida> obtenerPartidas(){
        return implPartida.obtenerPartidas();
    }
}
