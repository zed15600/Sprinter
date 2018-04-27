public class JsonString : ClientElement {

    public static string unirseAPartida(string codigo){
        string res = "{" +
                     "\"codigo\":0008," +
                     "\"partCode\":"+codigo+"" +
                     "}";
        return res;
    }

    public static string actualizarEstado(int pID, int player) {
        string res = "{" +
                     "\"codigo\":0009," +
                     "\"pID\":"+pID+"," +
                     "\"player\":"+player+"" +
                     "}";
        return res;
    }

    public static string enviarVoto(int pID, string HUid, int player){
        string res = "{" +
                     "\"codigo\":0010," +
                     "\"pID\":"+pID+"," +
                     "\"HUid\":"+HUid+"," +
                     "\"player\":"+player+"" +
            "}";
        return res;
    }
    
}
