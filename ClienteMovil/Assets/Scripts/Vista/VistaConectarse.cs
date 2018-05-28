using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class VistaConectarse : ClientElement {

    public Text txtCodigo;
    public Text txtNombre;

    public UnityEngine.UI.InputField nombre;

    public void verificarCodigo(string codigo) {
        string nombreJugador = nombre.text;
        if(codigo.Contains("-2")) {
            Debug.Log("VistaConectarse.verficarCodigo() -> Código inválido");
        }
        controlador.conectarPartida(codigo, nombreJugador);
    }

    public void respuestaConexion(bool respuesta) {
        if(respuesta) {
            this.gameObject.SetActive(false);
            controlador.mostrarVistaEstado();
        }
    }
    public void actualizar(){
        Type t = StaticComponents.lang.GetType();
        txtNombre.text = (string)t.GetField("nombre").GetValue(null);
        txtCodigo.text = (string)t.GetField("mensajeCodigo").GetValue(null);
    }
}
