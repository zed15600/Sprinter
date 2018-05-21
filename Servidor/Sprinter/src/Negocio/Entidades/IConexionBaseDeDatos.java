/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades;

import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public interface IConexionBaseDeDatos {
    public Proyecto obtenerProyecto(String nombre);
    public ArrayList<Proyecto> obtenerProyectos();
    public ArrayList<Impedimento> obtenerImpedimentos();
}
