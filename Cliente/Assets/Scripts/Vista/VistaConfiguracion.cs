using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaConfiguracion : ClientElement, IVista {

    public Idioma idioma;

    public Toggle toggleDialogos;
    public Slider sliderVolumen;
    public Dropdown idiomaComboBox;

    public Text titulo;
    public Text volumen;
    public Text idiomaText;
    public Text dialogos;

    public Button volver;
    public Button aplicar;

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
        switch (idiomaComboBox.captionText.text) {
            case "Español":
                controlador.cambiarIdioma(new ClienteEspañol());
                break;
            case "English":
                controlador.cambiarIdioma(new ClienteIngles());
                break;
        }
    }

    public void aplicarCambios() {
        cambiarDialogos();
        cambiarIdioma();
        cambiarVolumen();
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["titulo"];
        volumen.text = map["volumen"];
        idiomaText.text = map["idioma"];
        dialogos.text = map["dialogos"];
        CambiadorBoton.cambiarBotonesAnimados(volver, map["volver"]);
        CambiadorBoton.cambiarBotonesAnimados(aplicar, map["aplicar"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
        inicializarVista();
    }
}
