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

    public int obtenerPuntosHMinijuego()
    {
        int puntos = 0;
        puntos = int.Parse(app.modelo.getMinijuego().getHistoriaActual().getPuntos());
        return puntos;
    }

    public int obtenerPrioridadMinijuego()
    {
        int prioridad = 0;
        prioridad = int.Parse(app.modelo.getMinijuego().getHistoriaActual().getPrioridad());
        return prioridad;
    }

    public void establecerTiempo(float tiempo)
    {
        app.modelo.getMinijuego().setTiempoFinal(tiempo);
    }

    public float obtenerTiempoFinal()
    {
        float tiempoFinal = 0;
        tiempoFinal = app.modelo.getMinijuego().getTiempoFinal();
        return tiempoFinal;
    }

    public int obtenerIntentos()
    {
        return app.modelo.getMinijuego().getIntentos();
    }

    public void resetearIntentos() {
        app.modelo.getMinijuego().resetearIntentos();
    }

    public void aumentarIntento() {
        app.modelo.getMinijuego().aumentarIntentos();
    }

    public void obtenerPuntaje(HistoriaDeUsuario historia) {
        app.modelo.getProyecto().getHistorias();
    }
}
