using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class ClienteModelo : ClientElement {
    public Dictionary<string, Sprite> mapaAvatares = new Dictionary<string, Sprite>();
    private List<string> proyectos;

    private string scrumMaster;
    private Partida partida;
    private Proyecto proyecto;
    private List<Jugador> jugadores;
    private Minijuego minijuego = new Minijuego();

    public void setScrumMaster(string scrumMaster) {
        this.scrumMaster = scrumMaster;
    }

    public string getScrumMaster() {
        return scrumMaster;
    }

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
        //Debug.Log("ClienteModelo.setPartida() -> PartidaID: "+partida.getID());
        this.partida = partida;
    }
    public void setProyecto(Proyecto proyecto) {
        this.proyecto = proyecto;
    }
    public void setJugadores(List<Jugador> jugadores) {
        this.jugadores = jugadores;
    }
    public void setMinijuego(Minijuego minijuego) {
        this.minijuego = minijuego;
    }
}

public class Proyecto {

    public ClienteControlador controlador;

    private string nombre;
    private string descripcion;
    private List<HistoriaDeUsuario> historias;
    private int numeroSprints;
    private int duracionSprints;
    private List<HistoriaDeUsuario> historiasDeSprint;

    private int SprintActual;
    private int diaSprint;

    

    public Proyecto(string nombre, string descripcion, List<HistoriaDeUsuario> historias, int nSprints, int dSprints){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.historias = historias;
        numeroSprints = nSprints;
        duracionSprints = dSprints;
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
        return numeroSprints;
    }
    public List<HistoriaDeUsuario> getHistoriasSprint() {
        return historiasDeSprint;
    }
    public int getSprintActual(){
        return SprintActual;
    }
    public int getRestantes(){
        return numeroSprints - SprintActual;
    }
    public int getDiasRestantes() {
        return duracionSprints - diaSprint;
    }

    public void setHistoriasSprint(List<HistoriaDeUsuario> historias) {
        historiasDeSprint = historias;
    }
    public void setSprintActual (int actual){
        this.SprintActual = actual;
    }

    public bool terminarDia() {
        if(diaSprint<duracionSprints) {
            diaSprint ++;
            return true; //retorna true cuando el sprint sigue
        } else {
            SprintActual ++;
            diaSprint = 1;
            return false; //retorna false cuando el sprint termina
        }
    }

    public HistoriaDeUsuario obtenerHistoria(string tituloHistoria) {
        foreach (HistoriaDeUsuario hist in historias) {
            if (hist.getNombre().Equals(tituloHistoria)) {
                return hist;
            }
        }
        return new HistoriaDeUsuario();
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
    private string nombre;
    private string descripcion;
    private string puntos;
    private int prioridad;
    private List<CriterioHU> criterios;
    private bool estado;
    private int puntaje;

    public HistoriaDeUsuario() {

    }
    public HistoriaDeUsuario (string nombre, string descripcion, int prioridad, string puntos, List<CriterioHU> criterios, bool estado) {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.prioridad = prioridad;
        this.puntos = puntos;
        this.criterios = criterios;
        this.estado = estado;
        puntaje = 0;
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
    public int getPrioridad(){
        return prioridad;
    }
    public List<CriterioHU> getCriterios(){
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

public class CriterioHU {
    string descripcion;
    bool estado;

    public CriterioHU(string descripcion) {
        this.descripcion = descripcion;
        estado = false;
    }
    
    public string getDescripcion() {
        return descripcion;
    }
    public bool getEstado() {
        return estado;
    }
    public void completar() {
        estado = true;
    }
}

public class Minijuego{
    private HistoriaDeUsuario historiaActual;
    private float tiempoFinal = 0;
    private int intentos = 1;
    public List<Jugador> jugadoresEnProblemas = new List<Jugador>();

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

    public void completarCriterio(string descripcion){
        foreach(CriterioHU criterio in getHistoriaActual().getCriterios()) {
            if(criterio.getDescripcion().Equals(descripcion)) {
                criterio.completar();
                break;
            }
        }
    }
    public void aumentarIntentos() {
        this.intentos++;
    }
    public void resetearIntentos() {
        this.intentos = 1;
    }

    public List<Jugador> getJugadoresEnProblemas() {
        return jugadoresEnProblemas;
    }

    public void setJugadoresEnProblemas(List<Jugador> jugadoresEnProblemas) {
        this.jugadoresEnProblemas = jugadoresEnProblemas;
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