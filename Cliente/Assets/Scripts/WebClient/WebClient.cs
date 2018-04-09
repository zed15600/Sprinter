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

    void Update()
    {
        
    }


    void Awake()
    {

    }

    void Start()
    {

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
        {
            Debug.Log("Socketno estálisto");
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

    public void obtenerSprint()
    {
        setupSocket();
        string json = JsonString.sprintPlanning(app.modelo.getPartida().getID());
        writeSocket(json);
        string receieved_data = readSocket();

        if (receieved_data != "")
        {
            JSONObject respuesta = JSONObject.Parse(receieved_data);
            int restantes = (int)respuesta["restantes"].Number;
            int numero = (int)respuesta["numero"].Number;
            app.modelo.getProyecto().setSprintRestante(restantes);
            app.modelo.getProyecto().setSprintActual(numero);
        }
        closeSocket();
    }

    public void obtenerProyecto() {
        setupSocket();
        string json = JsonString.scrumPlanning(app.modelo.getPartida().getID());
        writeSocket(json);
        string received_data = readSocket();
        
        if (received_data != "")
        {
            JSONObject respuesta = JSONObject.Parse(received_data);
            string nombre = respuesta["nombre"].Str;
            string descripcion = respuesta["descripcion"].Str;
            JSONArray IDs = respuesta.GetArray("HUs");
            List<HistoriaDeUsuario> historias = new List<HistoriaDeUsuario>();

            for (int i = 0; i < IDs.Length; i++)
            {
                string historia = JsonString.pedirHistoria(app.modelo.getPartida().getID(), IDs[i].Str);
                setupSocket();
                writeSocket(historia);
                string recibida = readSocket();
                JSONObject histRespuesta = JSONObject.Parse(recibida);
                List<string> criterios = new List<string>();
                string nombreHU = histRespuesta["descripcion"].Str;
                string puntos = histRespuesta["puntos"].Str;
                string prioridad = histRespuesta["prioridad"].Str;
                JSONArray crit = histRespuesta.GetArray("criterios");

                for (int j = 0; j < crit.Length; j++)
                {
                    criterios.Add(crit[j].Str);
                }

                HistoriaDeUsuario historiaDeUsuario = new HistoriaDeUsuario(nombreHU, puntos, prioridad, criterios);
                historias.Add(historiaDeUsuario);
            }
            Proyecto proyecto = new Proyecto(nombre, descripcion, historias);
            app.modelo.setProyecto(proyecto);
        }
        closeSocket();
    }
}
