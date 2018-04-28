public class JsonString : ClientElement {

    public static string scrumPlanning(string partida)
    {
        string res = "{"
                + "\"codigo\":0004, "
                + "\"partidaID\":\"" + partida + "\""
                + "}\n";
        return res;
    }

    public static string pedirHistoria(string partida, string idHistoria)
    {
        string res = "{"
        + "\"codigo\":0005, "
        + "\"partidaID\":\"" + partida + "\","
        + "\"ID\":\"" + idHistoria + "\""
        + "}\n";
        return res;
    }

    public static string sprintPlanning(string partida)
    {
        string res = "{"
                + "\"codigo\":0006, "
                + "\"partidaID\":\"" + partida + "\""
                + "}\n";
        return res;
    }

    public static string establecerCompletada(string partida, string idHistoria)
    {
        string res = "{"
        + "\"codigo\":0007, "
        + "\"partidaID\":\"" + partida + "\","
        + "\"ID\":\"" + idHistoria + "\""
        + "}\n";
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
}
