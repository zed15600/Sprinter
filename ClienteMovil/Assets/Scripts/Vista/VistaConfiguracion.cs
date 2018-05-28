using System.Collections;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class VistaConfiguracion : ClientElement {

    public Image icono;
    public UnityEngine.UI.InputField nombre;
    public Slider volumen;
    public UnityEngine.UI.Dropdown idioma;

    public Text txtNombre;
    public Text txtAudio;
    public Text txtLenguaje;
    public Text btnGuardar;
    public Text btnGuardarPH;
    public Text btnCancelar;
    public Text btnCancelarPH;
    

    void OnEnable () {
        actualizar();
		icono.sprite = StaticComponents.avatares[controlador.obtenerAvatar()];
        nombre.text = StaticComponents.nombre;
        volumen.value = StaticComponents.volumen;
        idioma.value = StaticComponents.idiomas[StaticComponents.idioma];
	}
	
	void Update () {
		
	}

    public void salir() {
        gameObject.SetActive(false);
    }

    public void cambiarIdioma() {
        StaticComponents.idioma = idioma.captionText.text;
        StaticComponents.instanciarIdioma();
    }

    public void guardarOpciones() {
        PlayerPrefs.SetString("nombre", nombre.text);
        PlayerPrefs.SetFloat("volumen", volumen.value);
        PlayerPrefs.SetString("idioma", idioma.captionText.text);
        PlayerPrefs.Save();
        StaticComponents.loadConfig();
        salir();
    }

    public void actualizar() {
        Type t = StaticComponents.lang.GetType();
        txtNombre.text = (string)t.GetField("nombre").GetValue(null);
        txtAudio.text = (string)t.GetField("nivelAudio").GetValue(null);
        txtLenguaje.text = (string)t.GetField("lenguaje").GetValue(null);
        btnGuardar.text = (string)t.GetField("btnGuardar").GetValue(null);
        btnGuardarPH.text = (string)t.GetField("btnGuardar").GetValue(null);
        btnCancelar.text = (string)t.GetField("btnCancelar").GetValue(null);
        btnCancelarPH.text = (string)t.GetField("btnCancelar").GetValue(null);
    }
}
