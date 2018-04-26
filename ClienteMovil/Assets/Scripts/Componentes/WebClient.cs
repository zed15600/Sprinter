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
    
    public bool unirsePartida(int codigo) {
        string json = JsonString.unirseAPartida(codigo);
        setupSocket();
        writeSocket(json);
        string dataIn = readSocket();
        closeSocket();
        if(dataIn != "") {
            JSONObject jsRes = JSONObject.Parse(dataIn);
            return jsRes["aceptado"].Boolean;
        }
        return false;
    }

}
