using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class ClienteModelo : ClientElement {
    public Dictionary<string, Sprite> mapaAvatares = new Dictionary<string, Sprite>();
    private List<string> proyectos = new List<string>();

    private Partida partida = new Partida("");
    private Proyecto proyecto = new Proyecto("", "", null);
    private List<Jugador> jugadores = new List<Jugador>();
    private Minijuego minijuego = new Minijuego();

    public Dictionary<string, Sprite> getMapaAvatares() {
        return mapaAvatares;
    }
    public List<string> getProyectos() {
        return proyectos;
    }
    public Partida getPartida(){
        return partida;
    }
    public Proyecto getProyecto() {
        return proyecto;
    }
    public List<Jugador> getJugadores() {
        return jugadores;
    }
    public Minijuego getMinijuego() {
        return minijuego;
    }

    public void setMapaAvatares(Dictionary<string, Sprite> mapaAvatares) {
        this.mapaAvatares = mapaAvatares;
    }
    public void setProyectos(List<string> proyectos) {
        this.proyectos = proyectos;
    }
    public void setPartida(Partida partida) {
        this.partida = partida;
    }
    public void setProyecto(Proyecto proyecto) {
        this.proyecto = proyecto;
    }
    public void setJugadores(List<Jugador> jugadores) {
        this.jugadores = jugadores;
    }
}

public class Proyecto {

    public ClienteControlador controlador;

    private string nombre;
    private string descripcion;
    private List<HistoriaDeUsuario> historias;
    private int NumeroSprints;
    private int duracionSprints;
    private List<HistoriaDeUsuario> historiasDeSprint;

    private int SprintActual;
    private int diaSprint;


    private int SprintRestantes = 0;

    public Proyecto(string nombre, string descripcion, List<HistoriaDeUsuario> historias){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.historias = historias;
        SprintActual = 1;
        diaSprint = 1;
    }

    public string getNombre(){
        return nombre;
    }
    public string getDescripcion(){
        return descripcion;
    }
    public List<HistoriaDeUsuario> getHistorias(){
        return historias;
    }
    public int getNumeroSprints() {
        return NumeroSprints;
    }
    public List<HistoriaDeUsuario> getHistoriasSprint() {
        return historiasDeSprint;
    }
    public int getSprintActual(){
        return SprintActual;
    }
    public int getRestantes(){
        return SprintRestantes;
    }

    public void setHistoriasSprint(List<HistoriaDeUsuario> historias) {
        historiasDeSprint = historias;
    }
    public void setSprintActual (int actual){
        this.SprintActual = actual;
    }
    public void setSprintRestante(int restante){
        this.SprintRestantes = restante;
    }

    public bool terminarDia() {
        if(diaSprint<duracionSprints) {
            diaSprint ++;
            return true;
        } else {
            SprintActual ++;
            diaSprint = 1;
            return false;
        }
    }
}


public class Partida{
    private string id;

    public Partida(string id) { 
        this.id = id;
    }

    public string getID(){
        return id;
    }
}

public class HistoriaDeUsuario{
    private string ID;
    private string nombre;
    private string descripcion;
    private string puntos;
    private string prioridad;
    private List<string> criterios;
    private bool estado;
    private int puntaje;

    public HistoriaDeUsuario (string ID, string nombre, string descripcion, string prioridad, string puntos, List<string> criterios, bool estado) {
        this.ID = ID;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.prioridad = prioridad;
        this.puntos = puntos;
        this.criterios = criterios;
        this.estado = estado;
    }

    public string getID(){
        return ID;
    }
    public string getNombre() {
        return nombre;
    }
    public string getDescripcion(){
        return descripcion;
    }
    public string getPuntos(){
        return puntos;
    }
    public string getPrioridad(){
        return prioridad;
    }
    public List<string> getCriterios(){
        return criterios;
    }
    public bool getEstado(){
        return estado;
    }
    public int getPuntaje() {
        return puntaje;
    }

    public void setPuntaje(int puntaje) {
        this.puntaje = puntaje;
    }

    public void cambiarEstado() {
        estado = true;
    }
}

public class Minijuego{
    private HistoriaDeUsuario historiaActual;
    private float tiempoFinal = 0;
    private int intentos = 1;

    public HistoriaDeUsuario getHistoriaActual(){
        return historiaActual;
    }
    public float getTiempoFinal(){
        return tiempoFinal;
    }
    public int getIntentos(){
        return intentos;
    }

    public void setHistoriaActual(HistoriaDeUsuario historiax){
        this.historiaActual = historiax;
    }
    public void setTiempoFinal(float tiempoFinal){
        this.tiempoFinal = tiempoFinal;
    }

    public void eliminarCriterio(int indice){
        List<string> criterios = historiaActual.getCriterios();
        criterios[indice] = null;
    }
    public void aumentarIntentos() {
        this.intentos++;
    }
    public void resetearIntentos() {
        this.intentos = 0;
    }
}

public class Jugador {
    private string nombre;
    private string avatar;

    public Jugador(string nombre, string avatar) {
        this.nombre = nombre;
        this.avatar = avatar;
    }

    public string getNombre() {
        return nombre;
    }
    public string getAvatar() {
        return avatar;
    }

    public void setNombre(string nombre) {
        this.nombre = nombre;
    }
    public void setAvatar(string avatar) {
        this.avatar = avatar;
    }
}




