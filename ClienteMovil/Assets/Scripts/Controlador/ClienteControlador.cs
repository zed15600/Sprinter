using System.Collections.Generic;

public class ClienteControlador : ClientElement {

    public WebClient webClient;
    public ClienteModelo modelo;
    public ClienteVista vista;

    public void conectarPartida(string codigo, string nombreJugador) {
        webClient.unirsePartida(codigo, nombreJugador);
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

    public void responderConexion(bool aceptado) {
        vista.conectarse.respuestaConexion(aceptado);
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

    public void mostrarVotacion(string[] HUNombres) {
        vista.estado.mostrarVotacion(HUNombres);
    }

    public void ocultarVotacion() {
        vista.estado.ocultarVotacion();
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
}
