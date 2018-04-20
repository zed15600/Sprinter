﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaSprint : ClientElement {

    public GameObject prefabDesc;
    public GameObject prefabPrio;
    public GameObject prefabPunt;

    public VerticalLayoutGroup colDesc;
    public VerticalLayoutGroup colPrio;
    public VerticalLayoutGroup colPunt;

    public void llenarTabla()
    {

        List<HistoriaDeUsuario> historias = app.controlador.obtenerHistorias();
        for (int i = 0; i < historias.ToArray().Length; i++)
        {
            GameObject contenidoHistoria = Instantiate(prefabDesc);
            GameObject contenidoPrioridad = Instantiate(prefabPrio);
            GameObject contenidoPuntos = Instantiate(prefabPunt);

            Text descripcion = contenidoHistoria.GetComponentInChildren<Text>();
            Text prioridad = contenidoPrioridad.GetComponentInChildren<Text>();
            Text puntos = contenidoPuntos.GetComponentInChildren<Text>();

            descripcion.text = historias[i].getDescripcion();
            prioridad.text = historias[i].getPrioridad();
            puntos.text = historias[i].getPuntos();

            contenidoHistoria.transform.SetParent(colDesc.transform, false);
            contenidoPrioridad.transform.SetParent(colPrio.transform, false);
            contenidoPuntos.transform.SetParent(colPunt.transform, false);

        }
    }

    void Start()
    {
        while (app.controlador.obtenerHistorias().ToArray().Length == 0)
        {
            Debug.Log(app.controlador.obtenerHistorias().Capacity);
        }
        llenarTabla();
    }

    // Update is called once per frame
    void Update()
    {

    }
}