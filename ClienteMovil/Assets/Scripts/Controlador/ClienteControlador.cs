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

    public void mostrarVotacion(int[] HUsId, string[] HUsDesc) {
        vista.estado.mostrarVotacion(HUsId, HUsDesc);
    }

    public void enviarVoto(string HUid) {
        webClient.enviarVoto(modelo.getPartida().getID(), HUid, modelo.getJugador().getId());
    }
}
