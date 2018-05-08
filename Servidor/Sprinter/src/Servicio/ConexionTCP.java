/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Entidades.Configuracion;
import Negocio.Procesos.Proceso;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.ServerSocket;
import java.net.Socket;
import Negocio.Procesos.IMensajes;
import AccesoADatos.ProyectoDAOImpl;
import Negocio.Procesos.IConexion;

/**
 *
 * @author EDISON
 */
public class ConexionTCP implements IConexion{
    
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
        
        //Instancias de Implementaciones de Interfaces.
        ProyectoDAOImpl impl = new ProyectoDAOImpl();
        configuracion = new Configuracion(impl);
        Procesador proc = new Procesador();        
        IMensajes mensajes = new ImplMensajes();
        IConexion conexion = new ConexionTCP();
        proceso = new Proceso(mensajes, conexion);
        
        //Conexión TCP
        ServerSocket socket = new ServerSocket(5173);
        String in, out;
        while(true){
            Socket connectionSocket = socket.accept();
            InputStreamReader isr = new InputStreamReader(connectionSocket.getInputStream());
            BufferedReader inData = new BufferedReader(isr);
            DataOutputStream outData = new DataOutputStream(connectionSocket.getOutputStream());
            in = inData.readLine();
            out = proc.procesarJson(in);
            System.out.println("ConexionTCP.main()-> in: " + in);
            System.out.println("ConexionTCP.main()-> out: " + out);
            outData.writeBytes(out + "\n");
        }
    }

    @Override
    public Configuracion obtenerConfiguracion() {
        return configuracion;
    }

    public static Proceso getProceso() {
        return proceso;
    }
    
    
}