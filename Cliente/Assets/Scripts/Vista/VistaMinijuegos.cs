using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaMinijuegos : MonoBehaviour {

    public GameObject table;
    public GameObject timer;
    public GameObject category;
    public GameObject HUnumber;
    public GameObject continuar;
    public float targetTime = 120.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer();
	}

    void Continuar() {

    }

    void Timer() {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f) {

            timerEnded();
        }
    }
    void timerEnded()
    {
       //UIText timerText = Timer.Get
        //mer.text = "tiempo";
    }
}
