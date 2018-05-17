using System.Collections.Generic;
using UnityEngine;

public class ClienteControlador : ClientElement {

    [SerializeField]
    private ClienteModelo modelo;
    [SerializeField]
    private ClienteVista vista;
    public WebClient webClient;

    //Llamadas a WebClient

    public void pedirProyectos() {
        webClient.pedirProyectos();
    }
    public void crearPartida(string jugador, string partida, string proyecto) {
        webClient.crearPartida(jugador, partida, proyecto);
    }
    public void obtenerProyectoServidor() {
        webClient.obtenerProyecto();
    }
    public void establecerVotacion(bool votar, int tipoVoto) {
        webClient.establecerVotacion(modelo.getPartida().getID(), votar, tipoVoto);
    }
    public void estadoVotacion() {
        webClient.estadoVotacion(modelo.getPartida().getID());
    }
    public void obtenerVotos(int tipoVotacion) {
        webClient.obtenerVotos(modelo.getPartida().getID(), tipoVotacion);
    }
    public void pedirJugadores() {
        webClient.pedirJugadores(modelo.getPartida().getID());
    }
    public void empezarPartida() {
        webClient.empezarPartida(modelo.getPartida().getID());
    }
    

    //Llamadas a Modelo

        public List<string> obtenerProyectos() {
            return modelo.getProyectos();
        }
        public void setProyectos(List<string> nombres) {
            modelo.setProyectos(nombres);
        }
        public List<Jugador> obtenerJugadores() {
            return modelo.getJugadores();
        }
        public void establecerMapaAvatares(Dictionary<string, Sprite> avatares) {
            modelo.setMapaAvatares(avatares);
        }
        public void establecerJugadores(List<Jugador> jugadores) {
            modelo.setJugadores(jugadores);
        }
        public Dictionary<string, Sprite> obtenerMapaAvatares() {
            return modelo.getMapaAvatares();
        }

        public void establecerScrumMaster(string nombre) {
            modelo.setScrumMaster(nombre);
        }

        public string obtenerScrumMaster() {
            return modelo.getScrumMaster();
        }

    //Partida

    public void setPartida(Partida partida) {
            modelo.setPartida(partida);
        }
        public Partida obtenerPartida() {
            return modelo.getPartida();
        }
        internal string obtenerCodigoPartida() {
            return modelo.getPartida().getID();
        }

        //proyecto

        public void establecerProyecto(Proyecto proyecto) {
            modelo.setProyecto(proyecto);
        }
        public Proyecto obtenerProyecto() {
            return modelo.getProyecto();
        }
        public string obtenerNombreProyecto() {
            return modelo.getProyecto().getNombre();
        }
        public string obtenerDescripcionProyecto(){
            return modelo.getProyecto().getDescripcion();
        }
        public List<HistoriaDeUsuario> obtenerHistorias(){
            return modelo.getProyecto().getHistorias();
        }
        public List<HistoriaDeUsuario> obtenerHistoriasSprint() {
            return modelo.getProyecto().getHistoriasSprint();
        }
        public void establecerHistoriasSprint(List<HistoriaDeUsuario> historias) {
            modelo.getProyecto().setHistoriasSprint(historias);
        }
        public string obtenerSprintsRestantes(){
            return modelo.getProyecto().getRestantes().ToString();
        }
        public string obtenerActual(){
            return modelo.getProyecto().getSprintActual().ToString();
        }
        public int obtenerDiaActual() {
            return modelo.getProyecto().getDiasRestantes();
        }

        public HistoriaDeUsuario obtenerHistoriaPorTitulo(string tituloHistoria) {
            return modelo.getProyecto().obtenerHistoria(tituloHistoria);
        }

        //Minijuego

        public Minijuego obtenerMinijuego() {
            return modelo.getMinijuego();
        }
        public string obtenerNombreHistoriaMinijuego() {
            return modelo.getMinijuego().getHistoriaActual().getNombre();   
        }
        public string obtenerDescripcionHistoriaMinijuego() {
            return modelo.getMinijuego().getHistoriaActual().getDescripcion();
        }
        public List<CriterioHU> obtenerCriteriosMinijuego(){
            return modelo.getMinijuego().getHistoriaActual().getCriterios();
        }
        public void eliminarCriterioMinijuego(string descripcion){
            modelo.getMinijuego().completarCriterio(descripcion);
        }
        public int obtenerPuntosHMinijuego(){
            //Debug.Log("ClienteControlador.obtenerPuntosHMinijuego() -> Puntos de Historia de minijuego: " + modelo.getMinijuego().getHistoriaActual().getPuntos());
            return int.Parse(modelo.getMinijuego().getHistoriaActual().getPuntos());
        }
        public int obtenerPrioridadMinijuego(){
            //Debug.Log("ClienteControlador.obtenerPuntosHMinijuego() -> Prioridad de Historia de minijuego: " + modelo.getMinijuego().getHistoriaActual().getPrioridad());
            return modelo.getMinijuego().getHistoriaActual().getPrioridad();
        }
        public void establecerTiempo(float tiempo){
            modelo.getMinijuego().setTiempoFinal(tiempo);
        }
        public float obtenerTiempoFinal(){
            return modelo.getMinijuego().getTiempoFinal();
        }
        public int obtenerIntentos(){
            return modelo.getMinijuego().getIntentos();
        }
        public void resetearIntentos() {
            modelo.getMinijuego().resetearIntentos();
        }
        public void aumentarIntento() {
            modelo.getMinijuego().aumentarIntentos();
        }

        public void obtenerPuntaje(HistoriaDeUsuario historia) {
            modelo.getProyecto().getHistorias();
        }// wtf ¿quién hizo esto?


    //Llamadas a Vista

    public void mostrarVistaUnirseAPartida() {
        vista.unirseAPartida.gameObject.SetActive(true);
    }
    public void mostrarVistaScrumPlanning() {
        vista.scrumPlanning.gameObject.SetActive(true);
    }
    public void mostrarVistaSprintPlanning() {
        vista.sprintPlanning.gameObject.SetActive(true);
    }
    public void terminarVotacionSprintPlanning() {
        vista.panelVotacionSPlanning.terminarVotacion(false);
    }
    public void mostrarVotosSprintPlanning(string[] historiasID, int[] votos) {
        vista.panelVotacionSPlanning.mostrarVotos(historiasID, votos);
    }
    public void mostrarVistaSprint() {
        vista.vistaSprint.gameObject.SetActive(true);
    }
    public void terminarVotacionDia() {
        vista.panelVotacionDia.terminarVotacion(false);
    }
    public void mostrarVotosDia(string[] historiaID, int[] votos) {
        vista.panelVotacionDia.mostrarVotos(historiaID, votos);
    }
    public void iniciarMinijuego() {
        vista.minijuegos.gameObject.SetActive(true);
    }
    public void mostrarVistaResultados() {
        vista.resultados.gameObject.SetActive(true);
    }
    public void mostrarVistaRetrospectiva() {
        vista.retrospectiva.gameObject.SetActive(true);
    }
    public void mostrarVistaFinDelJuego() {
        vista.finDelJuego.gameObject.SetActive(true);
    }
    public void mostrarPanelMensaje() {
        vista.pnlMenssage.SetActive(true);
    }
    public void ocultarPanelMensaje() {
        vista.pnlMenssage.SetActive(false);
    }

    public void cargarDialogoGlobal(int indice) {
        vista.dialogoGlobal.cargarDialogo(indice);
        vista.dialogoGlobal.gameObject.SetActive(true);
    }

    public void mostrarPanelVotacion() {
        vista.panelVotacionSPlanning.gameObject.SetActive(true);
    }

    public bool verificarDialogoVacio() {
        return vista.dialogoGlobal.dialogoVacio();
    }

    public void mostrarPanelHistoria(string titulo) {
        vista.panelHistorias.actualizarHistoria(titulo);
        vista.panelHistorias.gameObject.SetActive(true);
    }
    /*public void iniciarNuevoSprint() {
        vista.vistaSprint.gameObject.SetActive(true);
    }

    public void terminarJuego() {
        vista.finDelJuego.gameObject.SetActive(true);
    }*/


    //Llamadas que contienen procesamiento

    //Web Client

    public void terminarHistoria(HistoriaDeUsuario historia){
        historia.cambiarEstado();
        webClient.establecerCompletada(historia.getNombre());
    }

    //Modelo

    public void establecerHistoriaActual(string historiaNombre) {
        foreach(HistoriaDeUsuario historia in modelo.getProyecto().getHistorias()) {
            if(historia.getNombre().Equals(historiaNombre)) {
                modelo.getMinijuego().setHistoriaActual(historia);
                return;
            }
        }
    }
    public void terminarDia() {
        if(modelo.getProyecto().terminarDia()){
            mostrarVistaSprint();
        } else {
            mostrarVistaRetrospectiva();
        }
    }
}
