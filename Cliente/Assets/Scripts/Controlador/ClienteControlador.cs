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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
