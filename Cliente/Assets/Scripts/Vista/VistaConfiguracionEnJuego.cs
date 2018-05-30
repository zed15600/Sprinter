using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VistaConfiguracionEnJuego : ClientElement, IVista {

    public Idioma idioma;

    public Toggle toggleDialogos;
    public Slider sliderVolumen;

    public Text titulo;
    public Text volumen;
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

    public void aplicarCambios() {
        cambiarDialogos();
        cambiarVolumen();
    }

    public void inicializarVista() {
        Dictionary<string, string> map = idioma.traerRecursos();
        titulo.text = map["titulo"];
        volumen.text = map["volumen"];
        dialogos.text = map["dialogos"];
        CambiadorBoton.cambiarBotonesAnimados(volver, map["volver"]);
        CambiadorBoton.cambiarBotonesAnimados(aplicar, map["aplicar"]);
    }

    public void cambiarIdioma(Idioma idioma) {
        this.idioma = idioma;
        inicializarVista();
    }
}
