using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDialogoGlobal : MonoBehaviour { 

    public DialogTrigger trigger;
    private string[] lineasDeDialogo;

    public void cargarDialogo(int indice) {
        switch (indice) {
            //Scrum Planning
            case 1:
                lineasDeDialogo = new string[] {
                    "Bienvenidos al Scrum Team!",
                    "Vamos a construir un proyecto en equipo utilizando el Marco Ágil Scrum!",
                    "Yo seré el Product Owner del equipo y he recopilado los deseos del cliente!",
                    "Debemos cumplirlos para completar el proyecto y ganar!",
                    "Mucha Suerte!\n" +
                    "Meow! (=^･ｪ･^=))ﾉ彡☆ ",
                    ""};
                break;
            //Sprint Planning
            case 2:
                lineasDeDialogo = new string[] {
                    "Los proyectos en Scrum se realizan por ciclos (o iteraciones :3) de tiempo definido.",
                    "A estas iteraciones les llamamos Sprints.",
                    "Al final de cada Sprint debemos tener un producto funcional que el cliente pueda probar. :D",
                    "Debemos seleccionar cuales historias de usuario realizaremos en este primer Sprint.",
                    "He seleccionado las primeras basadas en prioridad y las que conformarían un buen prototipo funcional.",
                    "Debemos organizarnos como equipo para elegir entre cuales de estas trabajaran en el Sprint! (=^･ω･^=)," +
                    ""};
                break;
        }
        trigger.dialogo.lineasDeDialogo = lineasDeDialogo;
        Debug.Log("ME LLAMARON!!!!");
    }

    void OnEnable() {
        Debug.Log("AQUI TAMBIEN!!!");
        Debug.Log(lineasDeDialogo.Length);
        trigger.TriggerDialog();
    }

    void Update() {
        if (FindObjectOfType<DialogManager>().dialogoVacio()) {
            this.gameObject.SetActive(false);
        }
    }
}
