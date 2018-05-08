using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaConectarse : ClientElement {

    public InputField nombre;

    public void verificarCodigo(string codigo) {
        string nombreJugador = nombre.inputText.text;
        if(codigo.Contains("-2")) {
            Debug.Log("VistaConectarse.verficarCodigo() -> Código inválido");
        }
        app.controlador.conectarPartida(codigo, nombreJugador);
    }

    public void respuestaConexion(bool respuesta) {
        if(respuesta) {
            this.gameObject.SetActive(false);
            app.vista.estado.gameObject.SetActive(true);
        }
    }
}
