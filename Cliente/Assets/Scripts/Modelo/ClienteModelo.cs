using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class ClienteModelo : ClientElement {
    [SerializeField]
    public Dictionary<string, Sprite> mapaAvatares = new Dictionary<string, Sprite>();

    private List<string> proyectos = new List<string>();

    private Minijuego minijuego = new Minijuego();

    private Partida partida = new Partida("");

    private Proyecto proyecto = new Proyecto("", "", null);

    private List<Jugador> jugadores = new List<Jugador>();

    public Dictionary<string, Sprite> getMapaAvatares() {
        return mapaAvatares;
    }

    public void setMapaAvatares(Dictionary<string, Sprite> mapaAvatares) {
        this.mapaAvatares = mapaAvatares;
    }

    public void setPartida(Partida partida) {
        this.partida = partida;
    }

    public List<Jugador> getJugadores() {
        return jugadores;
    }

    public List<string> getProyectos() {
        return proyectos;
    }

    public void setProyectos(List<string> proyectos) {
        this.proyectos = proyectos;
    }

    public Proyecto getProyecto() {
        return proyecto;
    }

    public void setProyecto(Proyecto proyecto)
    {
        this.proyecto = proyecto;
    }

    public Partida getPartida()
    {
        return partida;
    }

    public Minijuego getMinijuego() {
        return minijuego;
    }
}

public class Proyecto {

    private string nombre = "";

    private string descripcion = "";

    private List<HistoriaDeUsuario> historias = new List<HistoriaDeUsuario>();

    private int SprintActual = 0;

    private int SprintRestantes = 0;

    public Proyecto(string nombre, string descripcion, List<HistoriaDeUsuario> historias)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.historias = historias;
    }

    public string getNombre()
    {
        return nombre;
    }

    public string getDescripcion()
    {
        return descripcion;
    }

    public List<HistoriaDeUsuario> getHistorias()
    {
        return historias;
    }

    public int getRestantes()
    {
        return SprintRestantes;
    }

    public int getActual()
    {
        return SprintActual;
    }

    public void setSprintRestante(int restante)
    {
        this.SprintRestantes = restante;
    }

    public void setSprintActual (int actual)
    {
        this.SprintActual = actual;
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

    private string prioridad;

    private string puntos;

    private List<string> criterios;

    private bool estado;

    private int puntaje;

    public HistoriaDeUsuario (string ID, string nombre, string prioridad, string puntos, List<string> criterios, bool estado) {
        this.ID = ID;
        this.nombre = nombre;
        this.prioridad = prioridad;
        this.puntos = puntos;
        this.criterios = criterios;
        this.estado = estado;
    }

    public string getID()
    {
        return ID;
    }

    public string getDescripcion()
    {
        return nombre;
    }

    public string getPrioridad()
    {
        return prioridad;
    }

    public string getPuntos()
    {
        return puntos;
    }

    public bool getEstado()
    {
        return estado;
    }

    public List<string> getCriterios()
    {
        return criterios;
    }

    public void cambiarEstado()
    {
        this.estado = true;
    }

    public int getPuntaje() {
        return puntaje;
    }

    public void setPuntaje(int puntaje) {
        this.puntaje = puntaje;
    }

}

public class Minijuego{

    private HistoriaDeUsuario historiaActual;

    private float tiempoFinal = 0;

    private int intentos = 1;

    public HistoriaDeUsuario getHistoriaActual()
    {
        return historiaActual;
    }

    public void setHistoriaActual(HistoriaDeUsuario historiax)
    {
        this.historiaActual = historiax;
    }

    public void eliminarCriterio(int indice)
    {
        List<string> criterios = historiaActual.getCriterios();
        criterios[indice] = null;
    }

    public float getTiempoFinal()
    {
        return tiempoFinal;
    }

    public void setTiempoFinal(float tiempoFinal)
    {
        this.tiempoFinal = tiempoFinal;
    }

    public void aumentarIntentos()
    {
        this.intentos++;
    }

    public void resetearIntentos() {
        this.intentos = 0;
    }

    public int getIntentos()
    {
        return intentos;
    }
}

public class Jugador {
    private string nombre;
    private string avatar;

    public Jugador(string nombre, string avatar) {
        this.nombre = nombre;
        this.avatar = avatar;
    }

    public void setAvatar(string avatar) {
        this.avatar = avatar;
    }

    public void setNombre(string nombre) {
        this.nombre = nombre;
    }

    public string getNombre() {
        return nombre;
    }

    public string getAvatar() {
        return avatar;
    }
}




