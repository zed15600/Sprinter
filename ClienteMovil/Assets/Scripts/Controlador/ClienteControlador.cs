using System.Collections.Generic;

public class ClienteControlador : ClientElement {

    public bool conectarPartida(int codigo) {
        return app.webClient.unirsePartida(codigo);
    }
}
