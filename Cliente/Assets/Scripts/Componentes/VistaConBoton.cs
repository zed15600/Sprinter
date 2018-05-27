using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class CambiadorBoton {

    public static void cambiarBotonesAnimados(Button boton, string text) {
        boton.GetComponentsInChildren<Text>()[0].text = text;
        boton.GetComponentsInChildren<Text>()[1].text = text;
    }
}