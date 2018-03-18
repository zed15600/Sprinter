/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 *
 * @author usuario
 */
public class Conexion {
    
    /**
     * Método Para Hacer la Conexión a la Base de Datos de MySQL.
     * @return Conexión a la base de datos.
     * @throws ClassNotFoundException
     * @throws SQLException
     */
    public Connection conectar() throws ClassNotFoundException, SQLException {
        Class.forName("com.mysql.jdbc.Driver");
        //Insertar aqui los datos de su base de datos: puerto de localhost, usuario de base de datos en MySQL, contraseña.
        Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/sprinter", "root", "Azopardo234432qw");
        return conn;
    }
}
