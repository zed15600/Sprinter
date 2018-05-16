using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDialogoGlobal : ClientElement { 

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
                    "Ha iniciado el Sprint Planning!",
                    "Los proyectos en Scrum se realizan por ciclos (o iteraciones :3) de tiempo definido.",
                    "A estas iteraciones les llamamos Sprints.",
                    "Al final de cada Sprint debemos tener un producto funcional que el cliente pueda probar. :D",
                    "Debemos seleccionar cuales historias de usuario realizaremos en este primer Sprint.",
                    "He seleccionado las primeras basadas en prioridad y las que conformarían un buen prototipo funcional.",
                    "Debemos organizarnos como equipo para elegir entre cuales de estas trabajaran en el Sprint! (=^･ω･^=)," +
                    ""};
                break;
            //Sprint Planning advertencia de votación.
            case 3:
                lineasDeDialogo = new string[] {
                    "A continuación empezara una votación para decidir por cuales historias trabajar",
                    "Antes de votar asegúrense de haber expresado sus opiniones como equipo, es importante que todos nos comuniquemos!",
                    "Cuando estén listos, voten en sus dispositivos móviles!",
                    ""
                };
                break;
            //Sprint
            case 4:
                lineasDeDialogo = new string[] {
                    "Ha iniciado el Sprint!",
                    "Debemos completar las historias de usuario antes de que se acaben los días del Sprint.",
                    "Empecemos decidiendo cual historia de usuario trabajaremos el día de hoy.",
                    ""
                };
                break;
            case 5:
                lineasDeDialogo = new string[] {
                    "En Scrum el equipo se reúne diariamente para gestionar el trabajo e informar impedimentos",
                    "Esta reunión se conoce como la reunión diaria o el Daily Scrum",
                    "Debemos aprovechar este tiempo de reunión para discutir que haremos el día de hoy y como completaremos la historia de usuario.",
                    "Para completar la historia de usuario deben cumplir todos sus criterios de aceptación!",
                    "Al finalizar esta fase de discusión y organización empezaremos a construir la funcionalidad descrita en la historia de usuario.",
                    "Es muy importante que mantengamos el foco en completar esta tarea!",
                    "Buena suerte!  (=^ ◡ ^=)",
                    ""
                };
                break;
            case 6:
                lineasDeDialogo = new string[] {
                    "Oh no! Parece que alguien tiene un impedimento. D:",
                    "Como Scrum Team deben organizarse para apoyarse como equipo y enfrentar el problema juntos.",
                    controlador.obtenerScrumMaster() + ",como Scrum Master es muy importante que apoyes a las personas que estén en problemas y motives al equipo.",
                    ""
                };
                break;
            case 7:
                lineasDeDialogo = new string[] {
                    "Ahora empezaremos a construir la funcionalidad.",
                    "En la mayoría de los marcos ágiles incluyendo Scrum el desarrollo es iterativo.",
                    "Es decir, el proceso de diseño, construcción y pruebas se hace de acuerdo al foco del trabajo en el momento.",
                    "En este caso, el foco se trata de la historia de usuario.",
                    "El desarrollo de la historia constara de tres fases, diseño, construcción y pruebas, cada una de dos minutos.",
                    "El objetivo es completar correctamente las tres fases y cumplir todos los criterios de aceptación.",
                    "En la fase de diseño se deberá hacer un breve diseño a papel de lo que se requiere construir.",
                    "En la fase de construcción se deben utilizar los materiales al alcance para construir lo planteado en el diseño.",
                    "Por último en la fase de pruebas se deben asegurar que hayan cumplido todos los criterios y en caso de faltar algo pueden aprovechar el tiempo para completarlos.",
                    "En cada fase pueden darle \"Continuar\" para seguir a la siguiente fase o completar el minijuego.",
                    "Para completar una historia solo necesitan cumplir los criterios, pero mientras más rápido la completen más puntos ganaran!",
                    "Buena suerte!! :3",
                    ""
                };
                break;
            case 8:
                lineasDeDialogo = new string[] {
                    "El minijuego ha terminado!",
                    controlador.obtenerScrumMaster() + ", necesito que observes el producto construido y señales cuales criterios se cumplieron.",
                    ""
                };
                break;
            case 9:
                lineasDeDialogo = new string[] {
                    "Aquí se anuncian los resultados de su desarrollo.",
                    "Si lograron completar los criterios de aceptación continuaremos a desarrollar otras historias del Sprint.",
                    "Pero en el caso contrario, seguiremos desarrollando esta historia hasta que la completemos",
                    "Independientemente de los resultados, buen trabajo! :D",
                    ""
                };
                break;
            case 10:
                lineasDeDialogo = new string[] {
                    "El Sprint seguira hasta que completen las historias de usuario del Sprint o se acaben los días.",
                    "Recuerden gestionar muy bien su tiempo y auto organizarce como equipo! ฅ(＾・ω・＾ฅ)",
                    ""
                };
                break;
            case 11:
                lineasDeDialogo = new string[] {
                    "Ha terminado el Sprint y le he enseñado la funcionalidad desarrolladas al cliente",
                    "Aquí anunciare los resultados.",
                    ""
                };
                break;
            case 12:
                lineasDeDialogo = new string[] {
                    "Buen trabajo en el primer Sprint, ya les he explicado un poco sobre los conceptos básicos de Scrum.",
                    "De todas formas," + controlador.obtenerScrumMaster() + "como Scrum Master les ayudara a resolver dudas que tengan sobre el marco de trabajo y les ayudara a seguir el proceso de Scrum!.",
                    "Buena Suerte! Meow!",
                    ""
                };
                break;
        }
        trigger.dialogo.lineasDeDialogo = lineasDeDialogo;
    }

    void OnEnable() {
        trigger.TriggerDialog();
    }

    void Update() {
        if (FindObjectOfType<DialogManager>().dialogoEstaVacio()) {
            this.gameObject.SetActive(false);
        }
    }

    public bool dialogoVacio() {
        return FindObjectOfType<DialogManager>().dialogoEstaVacio();
    }
}
