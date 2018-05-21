using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaConfiguracion : ClientElement {

    public Toggle toggleDialogos;
    public Slider sliderVolumen;
    public Dropdown idiomaComboBox;

    public void cambiarDialogos() {
        if (toggleDialogos.isOn) {
            controlador.activarDialogos();
        } else {
            controlador.desactivarDialogos();
        }
    }

    public void cambiarVolumen() {
        //por implementar
    }

    public void cambiarIdioma() {
        //por implementar()
    }

    public void aplicarCambios() {
        cambiarDialogos();
        cambiarIdioma();
        cambiarVolumen();
    }
}
