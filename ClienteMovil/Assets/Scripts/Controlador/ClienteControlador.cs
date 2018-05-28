using System.Collections.Generic;
using UnityEngine;

public class ClienteControlador : MonoBehaviour {
    [SerializeField]
    private WebClient webClient;
    [SerializeField]
    private ClienteModelo modelo;
    [SerializeField]
    private ClienteVista vista;

    public string obtenerAvatar() {
        return modelo.getJugador().getAvatar();
    }

    public void establecerTipoPregunta(bool tipoPregunta) {
        modelo.getPartida().TipoPregunta = tipoPregunta;
    }
    public bool obtenerTipoPregunta() {
        return modelo.getPartida().TipoPregunta;
    }

    public void conectarPartida(string codigo, string nombreJugador) {
        webClient.unirsePartida(codigo, nombreJugador, modelo.getPartida().DeviceID);
    }

    public void crearPartida(string partidaID) {
        modelo.setPartida(partidaID);
    }

    public void cambiarEstadoPartida(string estado) {
        modelo.getPartida().setEstado(estado);
    }

    public string obtenerEstadoPartida() {
        return modelo.getPartida().getEstado();
    }


    public void establecerIdJugador(int id) {
        modelo.getJugador().setId(id);
    }

    public void establecerAvatarJugador(string avatar) {
        modelo.getJugador().setAvatar(avatar);
    }

    public void actualizarEstado() {
        webClient.actualizarEstado(modelo.getPartida().getID(), modelo.getJugador().getId());
    }


    public void enviarVoto(string HUid) {
        webClient.enviarVoto(modelo.getPartida().getID(), HUid, modelo.getJugador().getId());
    }

    public Impedimento obtenerImpedimento() {
        return modelo.getJugador().Estado;
    }

    public void modificarImpedimento(bool afectado, string nombre, string descripcion) {
        Impedimento i = obtenerImpedimento();
        if(afectado) {
            i.Nombre = nombre;
            i.Descripcion = descripcion;
        } else {
            i.Nombre = "Estado: Normal";
            i.Descripcion = "No estás siendo afectado por ninguna eventualidad.";
        }
        i.Afectado = afectado;
    }
    public void enviarRespuesta(string opcion) {
        Partida p = modelo.getPartida();
        webClient.enviarRespuesta(p.getID(), modelo.getJugador().getId(), opcion);
    }

    //llamadas a Vista
    public void mostrarVistaInicio() {
        vista.inicio.gameObject.SetActive(true);
    }
    public void mostrarVistaConectarse() {
        vista.conectarse.gameObject.SetActive(true);
    }
    public void mostrarVistaEstado() {
        vista.estado.gameObject.SetActive(true);
    }
    public void mostrarVistaEncuesta() {
        vista.encuesta.gameObject.SetActive(true);
    }
    public void mostrarVistaConfiguracion() {
        vista.configuracion.gameObject.SetActive(true);
    }
    public void ocultarVistaConectarse() {
        vista.conectarse.gameObject.SetActive(false);
    }
    public void ocultarVistaEstado() {
        vista.estado.gameObject.SetActive(false);
    }
    public void ocultarVistaEncuesta() {
        vista.encuesta.gameObject.SetActive(false);
    }
    public void mostrarVotacion(string[] HUNombres) {
        vista.estado.mostrarVotacion(HUNombres);
    }
    public void ocultarVotacion() {
        vista.estado.ocultarVotacion();
    }
    public void verificarCodigo(string codigo) {
        vista.conectarse.verificarCodigo(codigo);
    }
    public void responderConexion(bool aceptado) {
        vista.conectarse.respuestaConexion(aceptado);
    }
    public void actualizarLenguaje() {
        vista.inicio.actualizar();
        vista.conectarse.actualizar();
        vista.estado.actualizar();
        vista.encuesta.actualizar();
        vista.configuracion.actualizar();
    }
    public void abandonarJuego() {
        ocultarVistaConectarse();
        ocultarVistaEstado();
        ocultarVistaEncuesta();
        mostrarVistaInicio();
        modelo.getPartida().borrarDatos();
        modelo.getJugador().borrarDatos();
    }
}
