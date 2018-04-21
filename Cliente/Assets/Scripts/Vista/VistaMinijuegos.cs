using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaMinijuegos : MonoBehaviour {

    public GameObject table;
    public Text timer;
    public Image gato;
    public Text category;
    public GameObject HUnumber;
    public GameObject continuar;
    public float targetTime = 0;
    public Sprite gatoAzul;
    public Sprite gatoNaranja;
    public Sprite gatoVerde;


    int count = 0;

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
        timer.text = ((int)(targetTime/60)).ToString()+":"+((int)targetTime%60).ToString();

        if (targetTime <= 0.0f) {

            timerEnded();
        }
    }
    void timerEnded()
    {
       //UIText timerText = Timer.Get
        //mer.text = "tiempo";
    }
    public void restart() {
        targetTime=120.0f;
    }

    public void actualizar() {

        switch (count) {

            case 0:
                incrementarContador();
                category.text = "Diseño";
                category.color = new Color(246, 161, 11, 255);
                gato.sprite = gatoNaranja;
                count++;
                break;
            case 1:

            case 2:
            break;
        } 

    }

    public void incrementarContador() {

        targetTime += 120;
    }
}
