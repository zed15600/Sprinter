using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System;
using Boomlagoon.JSON;

public class WebClient : ClientElement {
    // Use this for initialization
    public String host = "localhost";
    public Int32 port = 5173;

    internal Boolean socket_ready = false;

    TcpClient tcp_socket;
    NetworkStream net_stream;

    StreamWriter socket_writer;
    StreamReader socket_reader;

    public bool proyectoObtenido = false;

    void OnApplicationQuit()
    {
        closeSocket();
    }

    public void setupSocket()
    {
        try
        {
            tcp_socket = new TcpClient(host, port);

            net_stream = tcp_socket.GetStream();
            socket_writer = new StreamWriter(net_stream);
            socket_reader = new StreamReader(net_stream);

            socket_ready = true;
        }
        catch (Exception e)
        {
            // Something went wrong
            Debug.Log("Socket error: " + e);
        }
    }

    public void writeSocket(string line)
    {
        if (!socket_ready)
            return;

        line = line + "\r\n";
        socket_writer.Write(line);
        socket_writer.Flush();
    }

    public String readSocket()
    {
        if (!socket_ready)
        {
            return "";
        }

        //if (net_stream.DataAvailable) {
            string inp = socket_reader.ReadLine();
        inp = socket_reader.ReadLine();
            return inp;
        //}
        //return "";
    }

    public void closeSocket()
    {
        if (!socket_ready)
            return;

        socket_writer.Close();
        socket_reader.Close();
        tcp_socket.Close();
        socket_ready = false;
    }
    
    public void unirsePartida(string codigo, string nombreJugador, string deviceID) {
        string json = JsonString.unirseAPartida(codigo, nombreJugador, deviceID);
        setupSocket();
        writeSocket(json);
        string dataIn = readSocket();
        closeSocket();
        if(dataIn != "") {
            JSONObject jsRes = JSONObject.Parse(dataIn);
            controlador.crearPartida(codigo);
            controlador.establecerAvatarJugador(jsRes["avatar"].Str);
            controlador.establecerIdJugador((int)jsRes["jugadorID"].Number);
            controlador.responderConexion(jsRes["aceptado"].Boolean);
        }
    }

    public void actualizarEstado(string pId, int player) {
        string json = JsonString.actualizarEstado(pId, player);
        setupSocket();
        writeSocket(json);
        string dataIn = readSocket();
        closeSocket();
        if(dataIn != "") {
            JSONObject jsRes = JSONObject.Parse(dataIn);
            if(jsRes["votacion"].Boolean) {
                JSONArray arr = jsRes["HUs"].Array;
                int size = arr.Length;
                string[] HUNombres = new string[size];
                for(int i=0; i<size; i++) {
                    HUNombres[i] = arr[i].Str;
                }
                controlador.mostrarVotacion(HUNombres);
            } else {
                controlador.ocultarVotacion();
            }
            controlador.cambiarEstadoPartida(jsRes["estadoPartida"].Str);
            bool afectado = jsRes["afectado"].Boolean;
            if(afectado){
                controlador.modificarImpedimento(afectado, jsRes["nombre"].Str, jsRes["descripcion"].Str);
            } else {
                controlador.modificarImpedimento(afectado, "", "");
            }
        }
    }

    public void enviarVoto(string pID, string HUid, int player) {
        string json = JsonString.enviarVoto(pID, HUid, player);
        setupSocket();
        writeSocket(json);
        closeSocket();
    }

    public void enviarRespuesta(string pID, int player, string opcion) {
        string json = JsonString.enviarRespuesta(pID, player, opcion);
        setupSocket();
        writeSocket(json);
        string dataIn = readSocket();
        closeSocket();
        if(dataIn !="") {
            JSONObject jsRes = JSONObject.Parse(dataIn);
            if(jsRes["terminamos"].Boolean) {
                controlador.ocultarEncuesta();
                controlador.mostrarInicio();
            }
        }
    }

}
