using System.Collections.Generic;
using UnityEngine;

public class ClienteModelo : ClientElement {

    private Partida partida = new Partida("1234");
    
    public Partida getPartida()
    {
        return partida;
    }

}


public class Partida
{
    private string id;

    public Partida(string id) { 
        this.id = id;
    }

    public string getID()
    {
        return id;
    }
}

public class HistoriaDeUsuario{

    private string ID;

    private string nombre;

    public HistoriaDeUsuario (string ID, string nombre) {
        this.ID = ID;
        this.nombre = nombre;
        }

    public string getID()
    {
        return ID;
    }

    public string getDescripcion()
    {
        return nombre;
    }
}
