using System.Collections.Generic;

public class ClienteControlador : ClientElement {

    public void conectarPartida(string codigo) {
        app.webClient.unirsePartida(codigo);
    }

    public void responderConexion(bool aceptado) {
        app.vista.conectarse.respuestaConexion(aceptado);
    }

    public void crearPartida(int pID) {
        app.modelo.setPartida(pID);
    }

    public void actualizarEstado(int codigo) {
        app.webClient.actualizarEstado(codigo, app.modelo.getJugador().getId());
    }

    public void mostrarVotacion(int[] HUsId, string[] HUsDesc) {
        app.vista.estado.mostrarVotacion(HUsId, HUsDesc);
    }

    public void enviarVoto(int pId, string HUid) {
        app.webClient.enviarVoto(pId, HUid, app.modelo.getJugador().getId());
    }
}
