using System.Collections.Generic;

public class ClienteControlador : ClientElement {

    public string obtenerNombreProyecto() {
        return app.modelo.getProyecto().getNombre();
    }

    public string obtenerDescripcionProyecto(){
        return app.modelo.getProyecto().getDescripcion();
    }

    public List<HistoriaDeUsuario> obtenerHistorias()
    {
        return app.modelo.getProyecto().getHistorias();
    }

    public string obtenerSprintsRestantes()
    {
        return app.modelo.getProyecto().getRestantes().ToString();
    }

    public string obtenerActual()
    {
        return app.modelo.getProyecto().getActual().ToString();
    }

    public string obtenerHistoriaMinijuego() {
        app.modelo.getMinijuego().setHistoriaActual(app.modelo.getProyecto().getHistorias()[0]);
        return app.modelo.getMinijuego().getHistoriaActual().getDescripcion();   
    }

    public List<string> obtenerCriteriosMinijuego()
    {
        return app.modelo.getMinijuego().getHistoriaActual().getCriterios();
    }

    public void eliminarCriterioMinijuego(int indice)
    {
        app.modelo.getMinijuego().eliminarCriterio(indice);
    }

    public void cambiarEstado(HistoriaDeUsuario historia)
    {
        historia.cambiarEstado();
        app.webClient.establecerCompletada(historia.getID());
    }
}
