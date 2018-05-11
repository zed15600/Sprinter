/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Entidades.Configuracion;
import Negocio.Procesos.Proceso;
import java.io.IOException;
import Negocio.Procesos.IMensajes;
import AccesoADatos.ProyectoDAOMySQL;
import AccesoADatos.ConexionSingletonMySQL;
import Negocio.Procesos.IConexion;

/**
 *
 * @author EDISON
 */

public class Main {
    
    private static Configuracion configuracion;
    
    private static Proceso proceso;
    
    /*
    Aquí se crea la conexión del servidor hacia el mundo.
    Se crea un objeto Proceso que es el que lleva a cabo todas las acciones
    en base al String que la conexión lee desde el puerto (5173).
    socket.accept() abre el puerto y se queda esperando hasta que recibe una conexión.
    inData.readLine() almacena en una variable String el mensaje     que recibe por el puerto.
    proc.procesarJson(in) envía el String de entrada al procesador y retorna un String respuesta.
    outData.writeBytes(out + "\n") devuelve a quién inició la conexión el String respuesta,
    el \n es necesario ya que la comunicación es por líneas, debe haber un terminador de línea.
    */    
    public static void main(String args[]) throws IOException {
        //Se inicia conexion a la DB.
        ConexionSingletonMySQL.conectar();
        //Instancias de Implementaciones de Interfaces.
        ProyectoDAOMySQL impl = new ProyectoDAOMySQL();
        configuracion = new Configuracion(impl);
        
        Procesador proc = new Procesador("json");        
        IMensajes mensajes = new JSONMensajes();
        //Conexión TCP
        IConexion conexion = new ConexionTCP(proc, configuracion);
        proceso = new Proceso(mensajes, conexion);
        proceso.getConexion().conectar();
    }
    
    public static Proceso getProceso(){
        return proceso;
    }
    
    public static Configuracion getConfiguracion(){
        return configuracion;
    }
    
}