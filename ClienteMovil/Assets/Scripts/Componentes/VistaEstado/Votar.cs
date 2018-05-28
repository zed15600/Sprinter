using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Votar : ClientElement {

    public Text txt;

    public void enviarVoto() {
        controlador.enviarVoto(txt.text);
        controlador.ocultarVotacion();
    }
}
