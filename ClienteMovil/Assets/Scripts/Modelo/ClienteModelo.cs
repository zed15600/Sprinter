using System.Collections.Generic;
using UnityEngine;

public class ClienteModelo : ClientElement {

    private Partida partida = new Partida(15600);
    private Jugador jugador = new Jugador();
    
    public Partida getPartida(){
        return partida;
    }

    public void setPartida(int pID) {
        partida = new Partida(pID);
    }

    public Jugador getJugador() {
        return jugador;
    }

    public void setJugador(int id) {
        jugador.setId(id);
    }

}


public class Partida
{
    private int id;

    public Partida(int id) { 
        this.id = id;
    }

    public int getID()
    {
        return id;
    }


}

public class Jugador {

    private int id;
    private string nombre;

    public void setId(int id) {
        this.id = id;
    }

    public int getId() {
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
