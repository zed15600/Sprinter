using System.Collections.Generic;
using UnityEngine;

public class ClienteModelo : ClientElement {

    private Partida partida;
    private Jugador jugador;

    void Awake() {
        partida = new Partida("");
    }
    void Start() {
        jugador = new Jugador(StaticComponents.nombre);
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
}


public class Partida{
    private string id;
    private string estado;
    public string DeviceID { get; private set; }
    public bool TipoPregunta { get; set; }

    public Partida(string id) { 
        this.id = id;
        estado = "conexion";
        DeviceID = SystemInfo.deviceUniqueIdentifier;
        TipoPregunta = false;
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
    public Impedimento Estado { get; private set; }

    public Jugador(string nombre) {
        this.nombre = nombre;
        Estado = new Impedimento();
        avatar = "none";
    }

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

public class Impedimento {

    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public bool Afectado { get; set; }

    public Impedimento() {
        Nombre = "Estado: Normal";
        Descripcion = "No estás siendo afectado por ninguna eventualidad.";
        Afectado = false;
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
