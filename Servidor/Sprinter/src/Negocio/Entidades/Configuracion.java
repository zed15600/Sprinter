/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades;

import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public class Configuracion {
    
    private Partida partida;
    private ArrayList<Proyecto> listaDeProyectos;
    
    public Configuracion(ProyectoDAO impl) throws SQLException, ClassNotFoundException{
        listaDeProyectos = impl.obtenerProyectos();
    }
    
    public void crearPartida(){
    }
    
    public void descargarDatos(){        
    }
    
    public void agregarProyecto(Proyecto proyecto){
        this.listaDeProyectos.add(proyecto);
    }
    
    public ArrayList<Proyecto> getListaDeProyectos(){
        return listaDeProyectos;
    }
}
