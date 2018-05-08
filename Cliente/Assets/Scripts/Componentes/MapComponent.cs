using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapComponent : ClientElement {
    [SerializeField]
    private string[] jugadores;
    [SerializeField]
    private Sprite[] imagenes;


    void Start() {
        poblarMapa();
    }

    public void poblarMapa() {
        Dictionary<string, Sprite> avatares = new Dictionary<string, Sprite>();

        for (int i = 0; i < jugadores.Length; i++) {

            avatares.Add(jugadores[i], imagenes[i]);
        }

        app.controlador.establecerMapaAvatares(avatares);
    }
}
