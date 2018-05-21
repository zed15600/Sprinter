/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Negocio.Procesos;

import Negocio.Entidades.Modelo.Configuracion;

/**
 *
 * @author usuario
 */
public class Controlador {
    IMensajes respuestas;
    Configuracion configuracion;
    
    public Controlador(IMensajes respuestas, Configuracion configuracion){
        this.respuestas = respuestas;
        this.configuracion = configuracion;
    }
}
