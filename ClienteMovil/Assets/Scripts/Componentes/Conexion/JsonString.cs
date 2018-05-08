public class JsonString : ClientElement {

    public static string unirseAPartida(string codigo, string nombreJugador){
        string res = "{" +
                     "\"codigo\":0008," +
                     "\"partCode\":"+codigo+"," +
                     "\"nombreJugador\":"+nombreJugador+
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

    public static string enviarVoto(string partidaID, string HUid, int player){
        string res = "{" +
                     "\"codigo\":0010," +
                     "\"partidaID\":"+partidaID+"," +
                     "\"HUid\":"+HUid+"," +
                     "\"player\":"+player+"" +
            "}";
        return res;
    }
    
}
