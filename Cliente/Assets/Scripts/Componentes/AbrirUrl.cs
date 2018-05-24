using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirUrl : MonoBehaviour {
    public void abrirPaginaDescargas() {
        Application.OpenURL("http://sprintergame.sa-east-1.elasticbeanstalk.com/");
    }
}
