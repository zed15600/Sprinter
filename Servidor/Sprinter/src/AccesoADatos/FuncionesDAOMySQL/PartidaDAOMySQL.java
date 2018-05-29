/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccesoADatos.FuncionesDAOMySQL;

import AccesoADatos.ConexiónDBMySQL.ConexionMySQLSingleton;
import Negocio.Entidades.DAO.PartidaDAO;
import Negocio.Entidades.Modelo.Jugador;
import Negocio.Entidades.Modelo.Partida;
import Negocio.Entidades.Modelo.Proyecto;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author usuario
 */
public class PartidaDAOMySQL implements PartidaDAO {
    
    Map<Integer, Partida> m;
    Partida p;
    
    public PartidaDAOMySQL(Partida p, Map m){
        this.p = p;
        this.m = m;
    }

    @Override
    public void enviarResultadosPartida() {
        long init = System.currentTimeMillis();
        Connection c = ConexionMySQLSingleton.crearConexionSecundaria();
        Statement s = null;
        ResultSet r;
        try {
            String sqlGetId = "SELECT LAST_INSERT_ID();";
            int idPartida = 0;
            ArrayList<Integer> idJugadores = new ArrayList<>();
            s = c.createStatement();
            s.execute("INSERT INTO Partidas (nombre_partida, "
                    + "estado, Proyectos_id_proyecto, puntuacion, scrumMaster)"
                    + "\nVALUES ('"+p.getNombre() + "', '"
                    + p.getEstado() + "', "
                    + p.getProyecto().getId() + ", " 
                    + p.calcularPuntuacion() + ", '"  
                    + p.getScrumMaster().getNombre() + "');");
            r = s.executeQuery(sqlGetId);
            r.next();
            idPartida = r.getInt(1);
            for(Jugador j : p.getListaJugadores()){
                s.execute("INSERT INTO Jugadores (nombre_jugador, "
                        + "Partida_id_partida)"
                        + "\nVALUES('"+j.getNombre()+"',"
                        + idPartida+");");
                r = s.executeQuery(sqlGetId);
                r.next();
                idJugadores.add(r.getInt(1));
            }
            for(int i=0; i<idJugadores.size(); i++){
                int pregID = 0;
                for(String resp : p.getEncuesta().getRespuestas().get(i)){
                    pregID ++;
                    if(resp!=null){
                        s.execute("INSERT INTO RespuestasDeJugadores "
                               + "(respuestas_J, Jugadores_id_jugador, "
                               + "Preguntas_id_pregunta)"
                               + "\nVALUES('"+resp+"', "+idJugadores.get(i)
                               +", "+pregID+");");
                    }
                }
            }
            long end = System.currentTimeMillis();
            System.out.println("Tiempo total: "+(end-init)+"ms.");
        } catch (SQLException ex) {
            Logger.getLogger(ProyectoDAOMySQL.class.getName()).log(Level.SEVERE,
                    null, ex);
        } finally {
            if (s != null && c != null)
            ConexionMySQLSingleton.cerrar(s, c);
            m.remove(p.getCodigo());
        }
    }

    @Override
    public void run() {
        enviarResultadosPartida();
    }
    
}
