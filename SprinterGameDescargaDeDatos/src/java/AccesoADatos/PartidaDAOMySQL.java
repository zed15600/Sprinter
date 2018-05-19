/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos;

import Modelo.Partida;
import Modelo.PartidaDAO;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class PartidaDAOMySQL implements PartidaDAO {

    @Override
    public ArrayList<Partida> obtenerPartidas() {
        return new ArrayList<Partida>();
    }
    
}
