using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : ClientElement {
    
    public Text codigo;
    int[] word = new int[]{-2, -2, -2, -2, -2, -2};
    int cursor = 0;

	// Use this for initialization
	void OnEnable () {
		word = new int[]{-2, -2, -2, -2, -2, -2};
	}
	
	// Update is called once per frame
	void Update () {
        string aux = "";
		for(int i=0; i<6; i++) {
            if(i==3)
                aux += "- ";
            if(word[i]!=-2) {
                aux += word[i] + " ";
            } else {
                aux += "_ ";
            }
        }
        codigo.text = aux;
	}

    public void keyPress(int key) {
        if(key>=0 && key<=9 && cursor<6) {
            word[cursor] = key;
            cursor+=1;
        }
        if(key==-1 && cursor>0) {
            word[cursor-1] = -2;
            cursor-=1;
        } 
        if(key==10) {
            string cod = ""+word[0]+word[1]+word[2]+word[3]+word[4]+word[5];
            //Debug.Log("Keypad.keyPress() -> Código: "+cod);
            controlador.vista.conectarse.verificarCodigo(cod);
        }
    }
}
