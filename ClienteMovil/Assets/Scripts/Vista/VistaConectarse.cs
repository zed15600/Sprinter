using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaConectarse : ClientElement {

    public bool verificarCodigo(int codigo) {
        if(codigo<100000) {
            return false;
        }
        if(!app.controlador.conectarPartida(codigo))
            return false;
        return true;
    }
}
