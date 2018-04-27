using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaConectarse : ClientElement {

    public void verificarCodigo(string codigo) {
        if(codigo.Contains("-2")) {
            Debug.Log("Código inválido");
        }
        app.controlador.conectarPartida(codigo);
    }

    public void respuestaConexion(bool respuesta) {
        if(respuesta) {
            this.gameObject.SetActive(false);
            app.vista.estado.gameObject.SetActive(true);
        }
    }
}
