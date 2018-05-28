/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Servicio.ElementosConexión.ConexionTCP;
import Servicio.Mensajes.JSONMensajes;
import Negocio.Entidades.Modelo.Configuracion;
import java.io.IOException;
import AccesoADatos.FuncionesDAOMySQL.DAOFachadaMySQL;
import Negocio.Entidades.DAO.DAOFachada;
import Negocio.Entidades.Modelo.Pregunta;
import Negocio.Procesos.IConexion;
import Negocio.Procesos.IMensajes;
import Negocio.Procesos.ControladorPrincipal;

/**
 *
 * @author EDISON
 */

public class Main {
    
    private static ControladorPrincipal controlador;
    
    /*
    Aquí se crea la conexión del servidor hacia el mundo.
    Se crea un objeto ControladorPrincipal que es el que lleva a cabo todas las acciones
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
         * DAOFachada: interfaz encargada de abstraer el modelo de la capa de 
         * acceso a datos, define el tipo de conexión de la base de datos.
         * Posibles implementaciones: DAOFachadaMySQL.
         * Actual selección: DAOFachadaMySQL para conectarse a la DB MySQL.
         */
        DAOFachada DAO = new DAOFachadaMySQL();
        /*
         * IMensajes: define el formato de texto para intercambio de datos, para
         * los mensajes recibidos y respuesta.
         * Posibles implementaciones: JSONMensajes
         * Actual selección: JSONMensajes para formato de texto json.
         */
        IMensajes implMensajes = new JSONMensajes();
        /*
         * IConexion: define el protocolo de transferencia que utiliza el 
         * servidor.
         * Posibles implementaciones: ConexionTCP
         * Actual selección: ConexionTCP para protocolo de transferencia TCP.
         */
        IConexion implConexion = new ConexionTCP(implMensajes);
        /*--------------------Fin De Implementaciones-------------------------*/
        Configuracion configuracion = new Configuracion(DAO);
        //Controlador global de la aplicación.
        controlador = new ControladorPrincipal(implMensajes,implConexion,configuracion);
        controlador.conectar();
    }
    
    public static ControladorPrincipal getControlador(){
        return controlador;
    }    
}