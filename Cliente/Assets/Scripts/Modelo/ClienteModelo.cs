public class Proyecto {
    private string nombre;
    private string descripcion;

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

public class ClienteModelo : ClientElement {
    private Proyecto proyecto = new Proyecto("Castillo", "Construir un Castillo");


    public Proyecto getProyecto() {
        return proyecto;
    }
}
