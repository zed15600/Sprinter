using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaReunionDiaria : ClientElement {

    public Text Historia;
    public Text diaSprint;

    public VerticalLayoutGroup criteriosLayout;
    public GridLayoutGroup jugadoresEnProblemas;

    public GameObject jugadoresPrefab;
    public GameObject criteriosPrefab;
    
    
	void OnEnable () {
        controlador.cargarDialogoGlobal(5);	
	}
	
	void Update () {
		
	}
}
