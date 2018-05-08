using System.Collections.Generic;

public class ClienteControlador : ClientElement {

    public void conectarPartida(string codigo, string nombreJugador) {
        app.webClient.unirsePartida(codigo, nombreJugador);
    }

    public void crearPartida(string partidaID) {
        app.modelo.setPartida(partidaID);
    }

    public void responderConexion(bool aceptado) {
        app.vista.conectarse.respuestaConexion(aceptado);
    }

    public void establecerIdJugador(int id) {
        app.modelo.getJugador().setId(id);
    }

    public void establecerAvatarJugador(string avatar) {
        app.modelo.getJugador().setAvatar(avatar);
    }

    public void actualizarEstado() {
        app.webClient.actualizarEstado(app.modelo.getPartida().getID(), app.modelo.getJugador().getId());
    }

    public void mostrarVotacion(int[] HUsId, string[] HUsDesc) {
        app.vista.estado.mostrarVotacion(HUsId, HUsDesc);
    }

    public void enviarVoto(string HUid) {
        app.webClient.enviarVoto(app.modelo.getPartida().getID(), HUid, app.modelo.getJugador().getId());
    }
}
