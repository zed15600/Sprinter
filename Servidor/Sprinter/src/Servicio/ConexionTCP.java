/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.Procesos.IConexion;
import Negocio.Procesos.IMensajes;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author usuario
 */
public class ConexionTCP implements IConexion{
    private final IProceso procesador;
    
    public ConexionTCP(IMensajes formatoDeMensajes){
        this.procesador = new Procesador(formatoDeMensajes);
    }

    @Override
    public void conectar() {
        try {
            ServerSocket socket = new ServerSocket(5173);
            String in, out;
            while(true){
                Socket connectionSocket = socket.accept();
                InputStreamReader isr =
                       new InputStreamReader(connectionSocket.getInputStream());
                BufferedReader inData = new BufferedReader(isr);
                DataOutputStream outData = 
                       new DataOutputStream(connectionSocket.getOutputStream());
                in = inData.readLine();
                System.out.println("ConexionTCP.conectar()-> in: " + in);
                out = procesador.procesar(in);
                System.out.println("ConexionTCP.conectar()-> out: " + out);
                outData.writeBytes(out + "\n");
            }
        } catch (IOException ex) {
            Logger.getLogger(ConexionTCP.class.getName()).log(Level.SEVERE,
                    null, ex);
        }
    }    
}
