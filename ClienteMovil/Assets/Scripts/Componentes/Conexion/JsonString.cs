public class JsonString : ClientElement {

    public static string unirseAPartida(string codigo, string nombreJugador, string deviceID){
        string res = "{" +
                     "\"codigo\":0008," +
                     "\"partidaID\":"+codigo+"," +
                     "\"nombreJugador\":\""+nombreJugador+"\"," +
                     "\"deviceID\":\""+deviceID+"\""+
                     "}";
        return res;
    }

    public static string actualizarEstado(string partidaID, int player) {
        string res = "{" +
                     "\"codigo\":0009," +
                     "\"partidaID\":"+partidaID+"," +
                     "\"player\":"+player+"" +
                     "}";
        return res;
    }

    public static string enviarVoto(string partidaID, string HUNombre, int player){
        string res = "{" +
                     "\"codigo\":0010," +
                     "\"partidaID\":"+partidaID+"," +
                     "\"HUNombre\":\""+HUNombre+"\"," +
                     "\"player\":"+player+"" +
            "}";
        return res;
    }
    
}
