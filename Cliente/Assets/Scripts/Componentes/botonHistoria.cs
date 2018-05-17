using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botonHistoria : ClientElement {

    public void mostrarDatosHistoria() {
        string titulo = GetComponentInChildren<Text>().text;
        controlador.mostrarPanelHistoria(titulo);
    }
}
