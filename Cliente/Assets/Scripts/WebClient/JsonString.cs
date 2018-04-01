using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonString : ClientElement {

    public static string scrumPlanning(string partida)
    {
        string res = "{"
                + "\"codigo\":0004, "
                + "\"partidaID\":\"" + partida + "\""
                + "}";
        return res;
    }
}
