/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Entidades.DAO;

import Negocio.Entidades.Modelo.Pregunta;
import java.util.ArrayList;

/**
 *
 * @author usuario
 */
public interface PreguntaDAO {
    public ArrayList<Pregunta> obtenerPreguntas();
}
