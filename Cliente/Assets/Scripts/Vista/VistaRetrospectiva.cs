using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaRetrospectiva : MonoBehaviour {

    public GameObject tabla;
    int[][] a;

	// Use this for initialization
	void Start () {
		a = new int[][] {new int[]{5, 2745}, new int[]{7, 1890}, new int[]{8, 1530}};
	}
	
	// Update is called once per frame
	void Update () {
		mostrarHistorias(a);
	}

    public void mostrarHistorias(int[][] historias) {
        for(int i=0; i<historias.Length; i++) {
            Text txt1 = (Text)GetComponent("Text");
            txt1.text = "5";
            txt1.transform.parent = tabla.transform;
            Text txt2 = (Text)GetComponent("Text");
            txt2.text = historias[i][1].ToString();
            txt2.transform.parent = tabla.transform;
        }
    }
}
