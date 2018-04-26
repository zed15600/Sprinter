using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaConectarse : ClientElement {

    public bool verificarCodigo(int codigo) {
        if(codigo<100000) {
            Debug.Log("Código inválido");
            return false;
        }
        if(!app.controlador.conectarPartida(codigo)){
            Debug.Log("Codigo no encontrado");
            return false;
        }
        Debug.Log("Conexion exitosa");
        return true;
    }
}
