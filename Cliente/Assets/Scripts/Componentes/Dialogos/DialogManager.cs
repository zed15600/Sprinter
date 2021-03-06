﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text textoUI;

    private Queue<string> lineasDeDialogo = new Queue<string>() ;

    public void limpiarDialogo() {
        lineasDeDialogo.Clear();
    }
    public void StartDialogue(Dialogo dialogo)
    {
        limpiarDialogo();

        if (dialogo.lineasDeDialogo == null) {
            return;
        }

        foreach (string linea in dialogo.lineasDeDialogo)
        {
            lineasDeDialogo.Enqueue(linea);
        }

        MostrarLineaSiguiente();
    }

    public void MostrarLineaSiguiente()
    {
        if (lineasDeDialogo.Count == 0)
        {
            return;
        }

        string linea = lineasDeDialogo.Dequeue();
        textoUI.text = linea;
    }

    public bool dialogoEstaVacio() {
        if (lineasDeDialogo.Count == 0) {
            return true;
        }
        return false;
    }
}
