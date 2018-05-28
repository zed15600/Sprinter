using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaEncuesta : ClientElement {
    
    public GameObject bB;
    public GameObject bC;
    public Text txtA;
    public Text txtAPH;
    public Text txtD;
    public Text txtDPH;

    void Update() {
        if(controlador.obtenerTipoPregunta()) {
            bB.SetActive(false);
            bC.SetActive(false);
            txtA.text = "V";
            txtAPH.text = "V";
            txtD.text = "F";
            txtDPH.text = "F";
        } else {
            bB.SetActive(true);
            bC.SetActive(true);
            txtA.text = "A";
            txtAPH.text = "A";
            txtD.text = "D";
            txtDPH.text = "D";
        }
    }

    public void enviarRespuesta(string opcion) {
        controlador.enviarRespuesta(opcion);
    }

    public void actualizar(){ }
}
