/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Entidades.Configuracion;
import java.io.IOException;
import AccesoADatos.ConexionMySQL;
import Negocio.Entidades.IConexionBaseDeDatos;
import Negocio.Procesos.IConexion;
import Negocio.Procesos.IMensajes;
import Negocio.Procesos.Controlador;

/**
 *
 * @author EDISON
 */

public class Main {
    
    private static Controlador controlador;
    
    /*
    Aquí se crea la conexión del servidor hacia el mundo.
    Se crea un objeto Controlador que es el que lleva a cabo todas las acciones
    en base al String que la conexión lee desde el puerto (5173).
    socket.accept() abre el puerto y se queda esperando hasta que recibe una conexión.
    inData.readLine() almacena en una variable String el mensaje     que recibe por el puerto.
    proc.procesarJson(in) envía el String de entrada al procesador y retorna un String respuesta.
    outData.writeBytes(out + "\n") devuelve a quién inició la conexión el String respuesta,
    el \n es necesario ya que la comunicación es por líneas, debe haber un terminador de línea.
    */    
    public static void main(String args[]) throws IOException {
        /*----------------------Instanciación de Interfaces-------------------*/
        /*
         * IConexionBaseDeDatos: define el tipo de conexión con la base de datos.
         * Posibles implementaciones: ConexionMySQL
         * Actual selección: ConexionMySQL para conectarse a la DB MySQL.
         */
        IConexionBaseDeDatos implBaseDeDatos = new ConexionMySQL();
        /*
         * IMensajes: define el formato de texto para intercambio de datos, para
         * los mensajes recibidos y respuesta.
         * Posibles implementaciones: JSONMensajes
         * Actual selección: JSONMensajes para formato de texto json.
         */
        IMensajes implMensajes = new JSONMensajes();
        /*
         * IConexion: define el protocolo de transferencia que utiliza el servidor.
         * Posibles implementaciones: ConexionTCP
         * Actual selección: ConexionTCP para protocolo de transferencia TCP.
         */
        IConexion implConexion = new ConexionTCP(implMensajes);
        /*--------------------Fin De Implementaciones-------------------------*/
        Configuracion configuracion = new Configuracion(implBaseDeDatos);
        //Controlador global de la aplicación.
        controlador = new Controlador(implMensajes, implConexion, configuracion);
        controlador.conectar();
    }
    
    public static Controlador getControlador(){
        return controlador;
    }    
}