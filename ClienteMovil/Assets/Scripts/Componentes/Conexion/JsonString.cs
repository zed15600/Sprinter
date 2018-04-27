public class JsonString : ClientElement {

    public static string unirseAPartida(string codigo){
        string res = "{" +
                     "\"codigo\":0008," +
                     "\"partCode\":"+codigo+"" +
                     "}";
        return res;
    }

    public static string actualizarEstado(int partidaID, int player) {
        string res = "{" +
                     "\"codigo\":0009," +
                     "\"partidaID\":"+partidaID+"," +
                     "\"player\":"+player+"" +
                     "}";
        return res;
    }

    public static string enviarVoto(int partidaID, string HUid, int player){
        string res = "{" +
                     "\"codigo\":0010," +
                     "\"partidaID\":"+partidaID+"," +
                     "\"HUid\":"+HUid+"," +
                     "\"player\":"+player+"" +
            "}";
        return res;
    }
    
}
