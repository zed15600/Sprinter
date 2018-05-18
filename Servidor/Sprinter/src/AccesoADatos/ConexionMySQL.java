/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import Negocio.Entidades.IConexionBaseDeDatos;
import Negocio.Entidades.Impedimento;
import Negocio.Entidades.ImpedimentoDAO;
import Negocio.Entidades.Proyecto;
import Negocio.Entidades.ProyectoDAO;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import javax.swing.JOptionPane;

/**
 * Singleton de la conexión a la base de datos, devuelve la conexión y tiene el
 * método conectar.
 * @author Ricardo Azopardo
 */
public final class ConexionMySQL implements IConexionBaseDeDatos{
    
    private static Connection conexion;
    private final ProyectoDAO implProyectoDAO;
    private final ImpedimentoDAO implImpedimentoDAO;
    
    public ConexionMySQL(){
        implProyectoDAO = new ProyectoDAOMySQL();
        implImpedimentoDAO = new ImpedimentoDAOMySQL();
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
        conn = DriverManager.getConnection(conector, usuario, contraseña);
        } catch (ClassNotFoundException | SQLException ex) {
            JOptionPane.showMessageDialog(null, ex,
                    "Error en la conexión con la" + "base de datos: "
                            + ex.getMessage(), JOptionPane.ERROR_MESSAGE);
        }        
        ConexionMySQL.conexion = conn;
    }

    @Override
    public Proyecto obtenerProyecto(String nombre) {
        return implProyectoDAO.obtenerProyecto(nombre);
    }

    @Override
    public ArrayList<Proyecto> obtenerProyectos() {
        return implProyectoDAO.obtenerProyectos();
    }

    @Override
    public ArrayList<Impedimento> obtenerImpedimentos() {
        return implImpedimentoDAO.obtenerImpedimentos();
    }
    
    public static Statement crearDeclaracion() throws SQLException{
        return conexion.createStatement();
    }
}
