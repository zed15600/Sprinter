using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
