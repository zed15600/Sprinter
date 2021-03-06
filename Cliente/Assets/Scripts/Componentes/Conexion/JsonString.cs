﻿using UnityEngine;

public class JsonString : ClientElement {

    public static string terminarDia(string partidaID) {
        string res = "{" +
            "\"codigo\":0003," +
            "\"partidaID\":\"" + partidaID + "\"" +
            "}";
        return res;
    }

    public static string pedirProyecto(string partida){
        string res = "{"
                + "\"codigo\":0004, "
                + "\"partidaID\":\"" + partida + "\""
                + "}\n";
        return res;
    }

    /*public static string pedirHistoria(string partida, string idHistoria){
        string res = "{"
        + "\"codigo\":0005, "
        + "\"partidaID\":\"" + partida + "\","
        + "\"ID\":\"" + idHistoria + "\""
        + "}\n";
        return res;
    }*/

    /*public static string sprintPlanning(string partida){
        string res = "{"
                + "\"codigo\":0006, "
                + "\"partidaID\":\"" + partida + "\""
                + "}\n";
        return res;
    }*/

    public static string establecerCompletada(string partida, string historiaNombre, int puntos){
        string res = "{"
        + "\"codigo\":0007, "
        + "\"partidaID\":\"" + partida + "\","
        + "\"nombre\":\"" + historiaNombre + "\""
        + "\"puntos\":" + puntos 
        + "}";
        return res;
    }

    public static string establecerVotacion(string partidaID, bool votar, int tipoVotacion) {
        string res = "{" +
                     "\"codigo\":0011," +
                     "\"partidaID\":"+partidaID+"," +
                     "\"votar\":\""+votar+"\"," +
                     "\"tipoVoto\":"+tipoVotacion+"" +
                     "}";
        return res;
    }

    public static string terminarVotacion(string partidaID) {
        string res = "{" +
                     "\"codigo\":0012," +
                     "\"partidaID\":"+partidaID +
                     "}";
        return res;
    }

    public static string obtenerVotos(string partidaID, int tipoVotacion) {
        string res = "{" +
                     "\"codigo\":0013," +
                     "\"partidaID\":"+partidaID +
                     "}";
        return res;
    }

    public static string pedirProyectos() {
        string res = "{\"codigo\":0014}";
        return res;
    }

    public static string crearPartida(string nombreJugador, string deviceID, string nombrePartida, string nombreProyecto) {
        string res = "{" +
             "\"codigo\":0015," +
             "\"jugador\":\"" + nombreJugador + "\"," +
             "\"deviceID\":\"" + deviceID + "\"," +
             "\"partida\":\"" + nombrePartida + "\"," +
             "\"proyecto\":\"" + nombreProyecto + "\"" +
             "}";
        return res;
    }

    public static string pedirJugadores(string partidaID) {
        string res = "{" +
             "\"codigo\":0016," +
             "\"partidaID\":" + partidaID +
             "}";
        return res;
    }

    public static string empezarPartida(string partidaID) {
        string res = "{" +
            "\"codigo\":0017," +
            "\"partidaID\":" + partidaID +
            "}";
        return res;
    }
    
    public static string empezarEncuesta(string partidaID) {
        string res = "{" +
            "\"codigo\":0018," +
            "\"partidaID\":" + partidaID +
            "}";
        return res;
    }

    public static string siguientePregunta(string partidaID) {
        string res = "{" +
            "\"codigo\":0019," +
            "\"partidaID\":" + partidaID +
            "}";
        return res;
    }

    public static string actualizarEstadoPartida(string partidaID, string resultado) {
        string res = "{" +
            "\"codigo\":0022, " +
            "\"partidaID\":" + partidaID + ", " +
            "\"resultado\":\"" + resultado + "\""+
            "}";
        return res;
    }
}
