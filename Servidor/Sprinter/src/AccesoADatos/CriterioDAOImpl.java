/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import Negocio.Entidades.Criterio;
import Negocio.Entidades.CriterioDAO;
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
public class CriterioDAOImpl implements CriterioDAO {

    @Override
    public ArrayList<Criterio> obtenerCriterios(int idHU){
        ArrayList<Criterio> criterios = new ArrayList<>();
        try {
            Statement stmt = ConexionSingleton.getConexionSingleton().createStatement();
            ResultSet r = stmt.executeQuery("{call obtenerCriterios("+idHU+")}");
            while (r.next()){
                String desc = r.getString(1);
                Criterio criterio = new Criterio(desc);
                criterios.add(criterio);
            }
        } catch (ClassNotFoundException | SQLException ex) {
            Logger.getLogger(CriterioDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return criterios;
    }
    
}
