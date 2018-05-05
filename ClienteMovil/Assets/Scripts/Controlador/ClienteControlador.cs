using System.Collections.Generic;

public class ClienteControlador : ClientElement {

    public void conectarPartida(string codigo) {
        app.webClient.unirsePartida(codigo);
    }

    public void responderConexion(bool aceptado) {
        app.vista.conectarse.respuestaConexion(aceptado);
    }

    public void crearPartida(int partidaID) {
        app.modelo.setPartida(partidaID);
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
