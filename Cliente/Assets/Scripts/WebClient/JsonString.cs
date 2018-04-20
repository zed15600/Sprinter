public class JsonString : ClientElement {

    public static string scrumPlanning(string partida)
    {
        string res = "{"
                + "\"codigo\":0004, "
                + "\"partidaID\":\"" + partida + "\""
                + "}";
        return res;
    }

    public static string pedirHistoria(string partida, string idHistoria)
    {
        string res = "{"
        + "\"codigo\":0005, "
        + "\"partidaID\":\"" + partida + "\","
        + "\"ID\":\"" + idHistoria + "\""
        + "}";
        return res;
    }

    public static string sprintPlanning(string partida)
    {
        string res = "{"
                + "\"codigo\":0006, "
                + "\"partidaID\":\"" + partida + "\""
                + "}";
        return res;
    }
}
