﻿using System.Collections;
using System;
using UnityEngine.UI;

public class VistaInicio : ClientElement {
	
    public Text btnUnirse;
    public Text btnUnirsePH;
    public Text btnConfiguracion;
    public Text btnConfiguracionPH;

    void OnEnable() {
        actualizar();
    }

    public void iniciarPartida() {
        this.gameObject.SetActive(false);
        controlador.mostrarVistaConectarse();
    }

    public void abrirConfiguracion() {
        controlador.mostrarVistaConfiguracion();
    }

    public void actualizar(){
        Type t = StaticComponents.lang.GetType();
        btnUnirse.text = (string)t.GetField("btnUnirseAPartida").GetValue(null);
        btnUnirsePH.text = (string)t.GetField("btnUnirseAPartida").GetValue(null);
        btnConfiguracion.text = (string)t.GetField("btnConfiguracion").GetValue(null);
        btnConfiguracionPH.text = (string)t.GetField("btnConfiguracion").GetValue(null);
    }
}
