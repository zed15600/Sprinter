using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticComponents : MonoBehaviour {

    public string[] idiomasText;
    public int[] id;
    public string[] nombres;
    public Sprite[] avataresSprites;

    public static Dictionary<string, int> idiomas = new Dictionary<string, int>();
    public static Dictionary<string, Sprite> avatares = new Dictionary<string, Sprite>();
    public static string nombre;
    public static float volument;
    public static string idioma;

    void Awake() {
        for(int i=0; i<nombres.Length;i++) {
            avatares.Add(nombres[i], avataresSprites[i]);
        }
        for(int i=0; i<idiomasText.Length;i++) {
            idiomas.Add(idiomasText[i], id[i]);
        }
        nombre = PlayerPrefs.GetString("nombre", "");
        volument = PlayerPrefs.GetFloat("volumen", 50f);
        idioma = PlayerPrefs.GetString("idioma", "Español");
    }
    
}
