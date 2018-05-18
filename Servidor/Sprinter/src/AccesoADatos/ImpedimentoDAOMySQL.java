/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import Negocio.Entidades.Impedimento;
import Negocio.Entidades.ImpedimentoDAO;
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
public class ImpedimentoDAOMySQL implements ImpedimentoDAO{

    @Override
    public ArrayList<Impedimento> obtenerImpedimentos() {
        ArrayList<Impedimento> impedimentos = new ArrayList<>();
        try{
            Statement sttmnt = ConexionMySQL.crearDeclaracion();
            ResultSet rsltst = 
                    sttmnt.executeQuery("{call obtenerImpedimentos()}");
            while(rsltst.next()){
                Impedimento i = new Impedimento(rsltst.getString(1), 
                        rsltst.getString(2));
                impedimentos.add(i);
            }
        } catch (SQLException ex) {
            Logger.getLogger(ImpedimentoDAOMySQL.class.getName())
                    .log(Level.SEVERE, null, ex);
        }
        return impedimentos;
    }
    
}
