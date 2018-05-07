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
        //Debug.Log("WebClient.writeSocket() -> out: "+line);
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
        //Debug.Log("WebClient.readSocket() -> in: "+inp);
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

    public void pedirJugadores(string partidaID) {
        setupSocket();
        string json = JsonString.pedirJugadores(partidaID);
        writeSocket(json);
        string recieved_data = readSocket();
        if (recieved_data != "") {
            JSONObject respuesta = JSONObject.Parse(recieved_data);
            JSONArray nombres = respuesta.GetArray("jugadores");
            JSONArray avatares = respuesta.GetArray("avatares");
            for (int i = 0; i < nombres.Length; i++) {
                string nombre = nombres[i].Str;
                string avatar = avatares[i].Str;
                Jugador jugador = new Jugador(nombre, avatar);
                app.controlador.obtenerJugadores().Add(jugador);
            }
        }
    }

    public void pedirProyectos() {
        setupSocket();
        string json = JsonString.pedirProyectos();
        writeSocket(json);
        string recieved_data = readSocket();
        if (recieved_data != "") {
            JSONObject respuesta = JSONObject.Parse(recieved_data);
            JSONArray proyectos = respuesta.GetArray("proyectos");
            List<string> proyectosNombres = new List<string>();
            for (int i = 0; i < proyectos.Length; i++) {
                string nombre = proyectos[i].Str;
                proyectosNombres.Add(nombre);
            }
            app.modelo.setProyectos(proyectosNombres);
        }
        closeSocket();
    }

    public void crearPartida(string jugador, string partida, string proyecto) {
        setupSocket();
        string json = JsonString.crearPartida(jugador, partida, proyecto);
        writeSocket(json);
        string recieved_data = readSocket();
        if (recieved_data != "") {
            JSONObject respuesta = JSONObject.Parse(recieved_data);
            string codigo = respuesta.GetString("id");
            Partida partidaCliente = new Partida(codigo);
            app.modelo.setPartida(partidaCliente);
        }

        closeSocket();
    }

    public void establecerCompletada(String huID)
    {
        setupSocket();
        string json = JsonString.establecerCompletada(app.modelo.getPartida().getID(), huID);
        writeSocket(json);
        closeSocket();
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
                string ID = IDs[i].Str;
                string nombreHU = histRespuesta["descripcion"].Str;
                string puntos = histRespuesta["puntos"].Str;
                string prioridad = histRespuesta["prioridad"].Str;
                JSONArray crit = histRespuesta.GetArray("criterios");
                bool estado = histRespuesta["estado"].Boolean;
                for (int j = 0; j < crit.Length; j++)
                {
                    criterios.Add(crit[j].Str);
                }

                HistoriaDeUsuario historiaDeUsuario = new HistoriaDeUsuario(ID, nombreHU, puntos, prioridad, criterios, estado);
                historias.Add(historiaDeUsuario);
            }
            Proyecto proyecto = new Proyecto(nombre, descripcion, historias);
            app.modelo.setProyecto(proyecto);
        }
        closeSocket();
    }

    public void establecerVotacion(string partidaID, bool votar, int tipoVoto) {
        string json = JsonString.establecerVotacion(partidaID, votar, tipoVoto);
        setupSocket();
        writeSocket(json);
        //string dataIn = readSocket();
        closeSocket();

    } 

    public void estadoVotacion(string partidaID) {
        string json = JsonString.terminarVotacion(partidaID);
        setupSocket();
        writeSocket(json);
        string dataIn = readSocket();
        closeSocket();
        if(dataIn !="") {
            JSONObject jsRes = JSONObject.Parse(dataIn);
            if(!jsRes["votamos"].Boolean && (int)jsRes["tipoVotacion"].Number==1) {
                app.controlador.terminarVotacionSprintPlanning();
            }
            if(!jsRes["votamos"].Boolean &&(int)jsRes["tipoVotacion"].Number==2) {
                app.controlador.terminarVotacionDia();
            }
        } else {
            Debug.Log("WebClient.estadoVotacion() -> Json vacío.");
        }
    }

    public void obtenerVotos(string partidaID, int tipoVotacion) {
        string json = JsonString.obtenerVotos(partidaID, tipoVotacion);
        setupSocket();
        writeSocket(json);
        string dataIn = readSocket();
        closeSocket();
        if(dataIn !="") {
            JSONObject jsRes = JSONObject.Parse(dataIn);
            JSONArray historiasID = jsRes["historiasID"].Array;
            JSONArray votos = jsRes["votos"].Array;
            if(historiasID.Length ==votos.Length) {
                int size = votos.Length;
                int[] husID = new int[size];
                int[] vots = new int[size];
                for(int i=0; i<size;i++) {
                    husID[i] = (int)historiasID[i].Number;
                    vots[i] = (int)votos[i].Number;
                }
                if(tipoVotacion == 1){
                    app.controlador.mostrarVotosSprintPlanning(husID, vots);
                }
                if(tipoVotacion == 2) {
                    app.controlador.mostrarVotosDia(husID[0], vots[0]);
                    app.modelo.getMinijuego().setHistoriaActual(app.modelo.getProyecto().getHistorias()[0]);
                }
            } else {
                Debug.Log("WebClient.obtenerVotos() -> diferente número de historias y contadores de votos.");
            }
        } else {
            Debug.Log("WebClient.obtenerVotos() -> Json vacío.");
        }
    }
}
