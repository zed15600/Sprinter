/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

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
 * @author EDISON
 */
public class ConexionTCP {
    
    public static void main(String args[]) throws IOException{
        ServerSocket socket = new ServerSocket(5173);
        while(true){
            Socket connectionSocket = socket.accept();
            InputStreamReader isr = new InputStreamReader(connectionSocket.getInputStream());
            BufferedReader inData = new BufferedReader(isr);
            DataOutputStream outData = new DataOutputStream(connectionSocket.getOutputStream());
            connectionSocket = socket.accept();
            isr = new InputStreamReader(connectionSocket.getInputStream());
            inData = new BufferedReader(isr);
            outData = new DataOutputStream(connectionSocket.getOutputStream());
            inData.readLine();
            //do something
            outData.writeBytes("");
        }
    }
}
