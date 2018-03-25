/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servicio;

import Negocio.*;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

/**
 *
 * @author EDISON
 */
public class ConexionTCP {
    
    public static void main(String args[]) throws IOException{
        Procesador proc = new Procesador();
        ServerSocket socket = new ServerSocket(5173);
            //System.out.println("Creado");
        String in, out;
        while(true){
            //System.out.println("Abriendo socket");
            Socket connectionSocket = socket.accept();
            //System.out.println("Abierto");
            InputStreamReader isr = new InputStreamReader(connectionSocket.getInputStream());
            BufferedReader inData = new BufferedReader(isr);
            DataOutputStream outData = new DataOutputStream(connectionSocket.getOutputStream());
            //System.out.println("Leyendo");
            in = inData.readLine();
            out = proc.procesarJson(in);
            //System.out.println("Leido");
            outData.writeBytes(out + "\n");
        }
    }
}
