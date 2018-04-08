using System.Collections.Generic;

public class Proyecto {

    private string nombre = "";

    private string descripcion = "";

    private List<HistoriaDeUsuario> historias;

    public Proyecto(string nombre, string descripcion, List<HistoriaDeUsuario> historias)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.historias = historias;
    }

    public string getNombre()
    {
        return nombre;
    }

    public string getDescripcion()
    {
        return descripcion;
    }

    public List<HistoriaDeUsuario> getHistorias()
    {
        return historias;
    }
}

public class Partida
{
    private string id;

    public Partida(string id) { 
        this.id = id;
    }

    public string getID()
    {
        return id;
    }
}

public class HistoriaDeUsuario {

    private string nombre;

    private string prioridad;

    private string puntos;

    private List<string> criterios;

    public HistoriaDeUsuario (string nombre, string prioridad, string puntos, List<string> criterios) {
        this.nombre = nombre;
        this.prioridad = prioridad;
        this.puntos = puntos;
        this.criterios = criterios;
    }

    public string getDescripcion()
    {
        return nombre;
    }

    public string getPrioridad()
    {
        return prioridad;
    }

    public string getPuntos()
    {
        return puntos;
    }
} 

public class ClienteModelo : ClientElement {

    private Partida partida = new Partida("1234");

    private Proyecto proyecto = new Proyecto("", "", null);

    public Proyecto getProyecto() {
        return proyecto;
    }

    public void setProyecto(Proyecto proyecto)
    {
        this.proyecto = proyecto;
    }
    public Partida getPartida()
    {
        return partida;
    }
}
