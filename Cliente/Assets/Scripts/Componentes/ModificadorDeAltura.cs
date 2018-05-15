using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificadorDeAltura : MonoBehaviour {

    public GameObject contenidoAModificar;
    public VerticalLayoutGroup alturaACopiar;

    public void cambiarAltura() {
        float altura = 0;
        Text[] hijos = alturaACopiar.GetComponentsInChildren<Text>(false);
        foreach (Text hijo in hijos) {
            altura += hijo.gameObject.transform.localScale.y;
        }
        contenidoAModificar.transform.localScale = new Vector3
            (contenidoAModificar.transform.localScale.x,
             altura,
             contenidoAModificar.transform.localScale.z);
    }

    void OnEnable() {
        cambiarAltura();
    }
}
