using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaConfiguracion : ClientElement {

    public Image icono;
    public UnityEngine.UI.InputField nombre;
    public Slider volumen;
    public UnityEngine.UI.Dropdown idioma;

    public Text txtAudio;
    public Text txtLenguaje;
    

    void OnEnable () {
		icono.sprite = StaticComponents.avatares[controlador.obtenerAvatar()];
        nombre.text = PlayerPrefs.GetString("nombre", "");
        volumen.value = PlayerPrefs.GetFloat("volumen", 0f);
        idioma.value = StaticComponents.idiomas[PlayerPrefs.GetString("idioma", "Español")];
	}
	
	void Update () {
		
	}

    public void salir() {
        gameObject.SetActive(false);
    }

    public void guardarOpciones() {
        PlayerPrefs.SetString("nombre", nombre.text);
        PlayerPrefs.SetFloat("volumen", volumen.value);
        PlayerPrefs.SetString("idioma", idioma.captionText.text);
        PlayerPrefs.Save();
        salir();
    }
}
