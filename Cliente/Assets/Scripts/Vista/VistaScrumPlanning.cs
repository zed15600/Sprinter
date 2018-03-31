using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaScrumPlanning : ClientElement {

    [SerializeField]
    private Text proyecto = null;
    [SerializeField]
    private Text descripcion = null;

    public void establecerProyecto() {
        proyecto.text = app.controlador.obtenerNombreProyecto();
        descripcion.text = app.controlador.obtenerDescripcionProyecto();
    }
	// Use this for initialization
	public void Start () {
        establecerProyecto();
	}
}
