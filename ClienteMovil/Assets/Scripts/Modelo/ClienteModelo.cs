using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClienteModelo : ClientElement {

    public string[] nombres;
    public Texture[] avatares;

    private Partida partida = new Partida("");
    private Jugador jugador = new Jugador();
    private Dictionary<string, Texture> mapaAvatares = new Dictionary<string, Texture>();

    void Awake() {
        for(int i=0; i<nombres.Length;i++) {
            mapaAvatares.Add(nombres[i], avatares[i]);
        }
    }

    public Partida getPartida(){
        return partida;
    }

    public void setPartida(string pID) {
        partida = new Partida(pID);
    }

    public Jugador getJugador() {
        return jugador;
    }

    public void setJugador(int id) {
        jugador.setId(id);
    }

    public Texture getAvatar(string id) {
        return mapaAvatares[id];
    }

}


public class Partida{
    private string id;
    private string estado;

    public Partida(string id) { 
        this.id = id;
        estado = "conexion";
    }

    public string getID() {
        return id;
    }
    public string getEstado() {
        return estado;
    }
    public void setEstado(string estado) {
        this.estado = estado;
    }

}

public class Jugador {

    private int id;
    private string nombre;
    private string avatar;

    public void setId(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }

    public void setNombre(string nombre) {
        this.nombre = nombre;
    }

    public string getNombre() {
        return nombre;
    }

    public void setAvatar(string avatar) {
        //Debug.Log("ClienteModelo.Jugador.setAvatar() -> avatar: " + avatar);
        this.avatar = avatar;
    }

    public string getAvatar() {
        return avatar;
    }
}

public class HistoriaDeUsuario{

    private string nombre;

    private string descripcion;

    public HistoriaDeUsuario (string nombre, string descripcion) {
        this.nombre = nombre;
        this.descripcion = descripcion;
        }

    public string getNombre()
    {
        return nombre;
    }

    public string getDescripcion()
    {
        return descripcion;
    }
}
