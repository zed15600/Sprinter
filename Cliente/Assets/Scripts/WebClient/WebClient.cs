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



    void Update()
    {
        obtenerProyecto();
    }


    void Awake()
    {
        setupSocket();
        string json = JsonString.scrumPlanning(app.modelo.getPartida().getID());
        Debug.Log("Sending: " + json);
        writeSocket(json);
    }

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
            return "";

        if (net_stream.DataAvailable)
            return socket_reader.ReadLine();
        return "";
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

    public void obtenerProyecto() {
        string received_data = readSocket();
        
        
        if (received_data != "")
        {
            Debug.Log(received_data);
            JSONObject respuesta = JSONObject.Parse(received_data);
            String nombre = respuesta["nombre"].Str;
            String descripcion = respuesta["descripcion"].Str;
            Debug.Log(nombre);
            Debug.Log(descripcion);
            Proyecto proyecto = new Proyecto(nombre, descripcion);
            app.modelo.setProyecto(proyecto);
        }
    }
}
