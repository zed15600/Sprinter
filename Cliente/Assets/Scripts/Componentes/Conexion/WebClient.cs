using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System;
using System.Text;
using Boomlagoon.JSON;

public class WebClient : ClientElement {
    public string localhost = "localhost";
    public string amazonHost = "ec2-18-231-48-175.sa-east-1.compute.amazonaws.com";
    public bool useLocal = true;
    public int port = 5173;

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
            tcp_socket = new TcpClient(useLocal?localhost:amazonHost, port);

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

    public void writeSocket(string line){
        //Debug.Log("WebClient.writeSocket() -> out: "+line);
        if (!socket_ready)
            return;

        line = line + "\r\n";
        socket_writer.Write(line);
        socket_writer.Flush();
    }

    public String readSocket(){
        if (!socket_ready){
            return "";
        }
            string inp = socket_reader.ReadLine();
        inp = socket_reader.ReadLine();
        //Debug.Log("WebClient.readSocket() -> in: "+inp);
            return inp;
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
        closeSocket();
        if (recieved_data != "") {
            JSONObject respuesta = JSONObject.Parse(recieved_data);
            
            controlador.establecerJugadores(hacerListaDeJugadores(respuesta));
        }
    }

    public void pedirProyectos() {
        setupSocket();
        string json = JsonString.pedirProyectos();
        writeSocket(json);
        string recieved_data = readSocket();
        closeSocket();
        if (recieved_data != "") {
            JSONObject respuesta = JSONObject.Parse(recieved_data);
            JSONArray proyectos = respuesta.GetArray("proyectos");
            List<string> proyectosNombres = new List<string>();
            for (int i = 0; i < proyectos.Length; i++) {
                string nombre = proyectos[i].Str;
                proyectosNombres.Add(nombre);
            }
            controlador.setProyectos(proyectosNombres);
        }
    }

    public void crearPartida(string jugador, string deviceID, string partida, string proyecto) {
        setupSocket();
        string json = JsonString.crearPartida(jugador, deviceID, partida, proyecto);
        writeSocket(json);
        string recieved_data = readSocket();
        closeSocket();
        if (recieved_data != "") {
            JSONObject respuesta = JSONObject.Parse(recieved_data);
            string codigo = respuesta.GetString("id");
            controlador.setIdPartida(codigo);
        }

    }

    public void establecerCompletada(String HUNombre, int puntos){
        setupSocket();
        string json = JsonString.establecerCompletada(controlador.obtenerPartida().Id, HUNombre, puntos);
        writeSocket(json);
        closeSocket();
    }

    /*public void obtenerSprint(){
        setupSocket();
        string json = JsonString.sprintPlanning(controlador.obtenerPartida().getID());
        writeSocket(json);
        string receieved_data = readSocket();
        closeSocket();

        if (receieved_data != ""){
            JSONObject respuesta = JSONObject.Parse(receieved_data);
            int restantes = (int)respuesta["restantes"].Number;
            int numero = (int)respuesta["numero"].Number;
            controlador.obtenerProyecto().setSprintRestante(restantes);
            controlador.obtenerProyecto().setSprintActual(numero);
        }
    }*/

    public void obtenerProyecto() {
        setupSocket();
        string json = JsonString.pedirProyecto(controlador.obtenerPartida().Id);
        writeSocket(json);
        string received_data = readSocket();
        closeSocket();
        
        if (received_data != ""){
            JSONObject respuesta = JSONObject.Parse(received_data);
            string nombre = respuesta["nombre"].Str;
            string descripcion = respuesta["descripcion"].Str;
            JSONArray jHistorias = respuesta.GetArray("historias");
            List<HistoriaDeUsuario> historias = new List<HistoriaDeUsuario>();

            for (int i = 0; i < jHistorias.Length; i++){
                JSONObject historia = jHistorias[i].Obj;
                List<CriterioHU> criterios = new List<CriterioHU>();
                string nombreHU = historia["nombre"].Str;
                string descripcionHU = historia["descripcion"].Str;
                string puntos = historia["puntos"].Str;
                int prioridad = (int)historia["prioridad"].Number;
                //Debug.Log("WebClient.obtenerProyecto() -> Prioridad HU:" + prioridad);
                JSONArray crit = historia.GetArray("criterios");
                bool estado = historia["estado"].Boolean;
                for (int j = 0; j < crit.Length; j++){
                    criterios.Add(new CriterioHU(crit[j].Str));
                    //Debug.Log("WebClient.obtenerProyecto() -> Descripción de criterio: " + criterios[j].getDescripcion());
                }

                HistoriaDeUsuario historiaDeUsuario = new HistoriaDeUsuario(nombreHU, descripcionHU, prioridad, puntos, criterios, estado);
                historias.Add(historiaDeUsuario);
            }
            Proyecto proyecto = new Proyecto(nombre, descripcion, historias, (int)respuesta["numeroSprints"].Number, (int)respuesta["duracionSprints"].Number);
            controlador.establecerProyecto(proyecto);
        }
    }

    public void establecerVotacion(string partidaID, bool votar, int tipoVoto) {
        string json = JsonString.establecerVotacion(partidaID, votar, tipoVoto);
        setupSocket();
        writeSocket(json);
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
                controlador.terminarVotacionSprintPlanning();
            }
            if(!jsRes["votamos"].Boolean &&(int)jsRes["tipoVotacion"].Number==2) {
                controlador.terminarVotacionDia();
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
            if(historiasID.Length == votos.Length) {
                int size = votos.Length;
                String[] husID = new String[size];
                int[] vots = new int[size];
                List<HistoriaDeUsuario> historias = new List<HistoriaDeUsuario>();
                HistoriaDeUsuario hActual = new HistoriaDeUsuario("", "", 0, "", null, false);
                for(int i=0; i<size;i++) {
                    husID[i] = historiasID[i].Str;
                    vots[i] = (int)votos[i].Number;
                    foreach(HistoriaDeUsuario historia in controlador.obtenerHistorias()){
                        //Debug.Log("WebClient.obtenerVotos() -> Nombre historia de usuario: " + historia.getNombre());
                        if(historia.getNombre().Equals(husID[i])) {
                            historias.Add(historia);
                            hActual = historia;
                            break;
                        }
                    }
                }
                if(tipoVotacion == 1){
                    controlador.establecerHistoriasSprint(historias);
                    controlador.mostrarVotosSprintPlanning(husID, vots);
                }
                if(tipoVotacion == 2) {
                    controlador.mostrarVotosDia(husID, vots);
                    controlador.obtenerMinijuego().setHistoriaActual(hActual);
                }
            } else {
                Debug.Log("WebClient.obtenerVotos() -> diferente número de historias y contadores de votos.");
            }
        } else {
            Debug.Log("WebClient.obtenerVotos() -> Json vacío.");
        }
    }

    public void empezarPartida(string partidaID) {
        string json = JsonString.empezarPartida(partidaID);
        setupSocket();
        writeSocket(json);
        closeSocket();
    }

    public void terminarDia(string partidaID) {
        string json = JsonString.terminarDia(partidaID);
        setupSocket();
        writeSocket(json);
        string dataIn = readSocket();
        closeSocket();
        if(dataIn !="") {
            JSONObject jsRes = JSONObject.Parse(dataIn);
            controlador.establecerJugadoresEnProblemas(hacerListaDeJugadores(jsRes));
        }
    }

    public void iniciarEncuesta(string partidaID) {
        string json = JsonString.empezarEncuesta(partidaID);
        setupSocket();
        writeSocket(json);
        string dataIn = readSocket();
        closeSocket();
        if(dataIn !="") {
            JSONObject jsRes = JSONObject.Parse(dataIn);
            establecerPregunta(jsRes);
        }
    }

    public void siguientePregunta(string partidaID) {
        string json = JsonString.siguientePregunta(partidaID);
        setupSocket();
        writeSocket(json);
        string dataIn = readSocket();
        closeSocket();
        if(dataIn !="") {
            JSONObject jsRes = JSONObject.Parse(dataIn);
            if(!jsRes["terminado"].Boolean) {
                establecerPregunta(jsRes);
            } else {
                controlador.ocultarVistaEncuesta();
                controlador.salirDePartida();
            }
        }
    }

    public List<Jugador> hacerListaDeJugadores(JSONObject json) {
        JSONArray nombres = json.GetArray("jugadores");
        JSONArray avatares = json.GetArray("avatares");
        List<Jugador> jugadores = new List<Jugador>();
        for (int i = 0; i < nombres.Length; i++) {
            string nombre = nombres[i].Str;
            string avatar = avatares[i].Str;
            Jugador jugador = new Jugador(nombre, avatar);
            jugadores.Add(jugador);
        }
        return jugadores;
    }

    public void establecerPregunta(JSONObject json) {
        Pregunta p = controlador.obtenerPregunta();
        p.Descripcion = json["pregunta"].Str;
        JSONArray res = json["respuestas"].Array;
        for(int i=0; i<4;i++) {
            p.Respuestas[i] = res[i].Str;
        }
    }
}
