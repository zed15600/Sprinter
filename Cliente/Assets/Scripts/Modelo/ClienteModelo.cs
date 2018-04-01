public class Proyecto {
    private string nombre = "";
    private string descripcion = "";

    public Proyecto(string nombre, string descripcion)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
    }

    public string getNombre()
    {
        return nombre;
    }

    public string getDescripcion()
    {
        return descripcion;
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

public class ClienteModelo : ClientElement {

    private Partida partida = new Partida("1234");

    private Proyecto proyecto = new Proyecto("", "");

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
