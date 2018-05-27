
using System.Collections.Generic;

public class ClienteIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("idioma", "ingles");
        return determinadorDeIdiomas;
    }
}

public class PerfilIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Select your user type:");
        determinadorDeIdiomas.Add("jugador", "Player");
        determinadorDeIdiomas.Add("investigador", "Researcher");
        determinadorDeIdiomas.Add("salida", "Exit");
        return determinadorDeIdiomas;
    }
}

public class MenuJugadorIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("iniciar", "Start Game");
        determinadorDeIdiomas.Add("configuracion", "Options");
        determinadorDeIdiomas.Add("volver", "Back");
        return determinadorDeIdiomas;
    }
}

public class MenuInvestigadorIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("datos", "View Data");
        determinadorDeIdiomas.Add("volver", "Back");
        return determinadorDeIdiomas;
    }
}

public class ConfiguracionIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Options");
        determinadorDeIdiomas.Add("volumen", "Volume");
        determinadorDeIdiomas.Add("idioma", "Language");
        determinadorDeIdiomas.Add("dialogos", "Dialogues");
        determinadorDeIdiomas.Add("volver", "Back");
        determinadorDeIdiomas.Add("aplicar", "Apply");
        return determinadorDeIdiomas;
    }
}

public class ConfPartidaIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Game Setup");
        determinadorDeIdiomas.Add("nombre", "Your Name:");
        determinadorDeIdiomas.Add("partida", "Game Name:");
        determinadorDeIdiomas.Add("proyecto", "Choose a Project:");
        determinadorDeIdiomas.Add("continuar", "Continue");
        determinadorDeIdiomas.Add("volver", "Back");
        return determinadorDeIdiomas;
    }
}

public class ScrumPlanningIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("historia", "Story");
        determinadorDeIdiomas.Add("prioridad", "Priority");
        determinadorDeIdiomas.Add("puntos", "Points");
        determinadorDeIdiomas.Add("continuar", "Continue");
        return determinadorDeIdiomas;
    }
}

public class SprintPlanningIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("historia", "Story");
        determinadorDeIdiomas.Add("prioridad", "Priority");
        determinadorDeIdiomas.Add("puntos", "Points");
        determinadorDeIdiomas.Add("status", "Status");
        determinadorDeIdiomas.Add("numeroSTR1", "Sprint Number: ");
        determinadorDeIdiomas.Add("numeroSTR2", ".");
        determinadorDeIdiomas.Add("restantesSTR1", "Sprints Left: ");
        determinadorDeIdiomas.Add("restantesSTR2", ".");
        determinadorDeIdiomas.Add("votos", "Choose Sprint Stories");
        return determinadorDeIdiomas;
    }
}

public class SprintIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("historia", "Story");
        determinadorDeIdiomas.Add("prioridad", "Priority");
        determinadorDeIdiomas.Add("puntos", "Points");
        determinadorDeIdiomas.Add("continuar", "Choose Current Story");
        determinadorDeIdiomas.Add("STRtrestante", "Time Left: ");
        determinadorDeIdiomas.Add("STRDia", " day.");
        determinadorDeIdiomas.Add("STRDias", " days.");
        return determinadorDeIdiomas;
    }
}

public class UnirseIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Game Code");
        determinadorDeIdiomas.Add("volver", "Back");
        determinadorDeIdiomas.Add("continuar", "Continue");
        return determinadorDeIdiomas;
    }
}

public class DailyIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Daily Scrum");
        determinadorDeIdiomas.Add("criterios", "Acceptance Criteria");
        determinadorDeIdiomas.Add("problemas", "In Trouble:");
        determinadorDeIdiomas.Add("desarrollo", "Development Starts in:");
        determinadorDeIdiomas.Add("dia", "Day: ");
        determinadorDeIdiomas.Add("continuar", "Continue");
        return determinadorDeIdiomas;
    }
}

public class MinijuegoIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Minigame");
        determinadorDeIdiomas.Add("diseño", "Design");
        determinadorDeIdiomas.Add("construccion", "Development");
        determinadorDeIdiomas.Add("pruebas", "Testing");
        determinadorDeIdiomas.Add("criterios", "Acceptance Criteria");
        determinadorDeIdiomas.Add("seleccionar", "Toggle the Completed Criteria");
        determinadorDeIdiomas.Add("continuar", "Continue");
        return determinadorDeIdiomas;
    }
}

public class ResultadosIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Results");
        determinadorDeIdiomas.Add("puntos", "Points");
        determinadorDeIdiomas.Add("criterios", "Acceptance Criteria");
        determinadorDeIdiomas.Add("continuar", "Continue");
        determinadorDeIdiomas.Add("completa","Done!");
        determinadorDeIdiomas.Add("incompleta","Incomplete!");
        return determinadorDeIdiomas;
    }
}

public class RetrospectivaIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Retrospective");
        determinadorDeIdiomas.Add("buen trabajo", "You completed all stories in the Sprint! \n" +
                        "The client is very satisfied with the work done, Congratulations. :D");
        determinadorDeIdiomas.Add("mal trabajo", "It seems some stories in the Sprint remain uncompleted. :( \n" +
                        "The client is expecting more commitment from you.");
        determinadorDeIdiomas.Add("continuar", "Continue");
        return determinadorDeIdiomas;
    }
}

public class FinIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo","Game Over");
        determinadorDeIdiomas.Add("victoria", "Victory!");
        determinadorDeIdiomas.Add("derrota", "Defeat!");
        determinadorDeIdiomas.Add("descripcion", "Congratulations, you completed a project in Sprinter Game!" +
                                    "\n Independently of the results, you learned and improved in Scrum, you will do better next time!" +
                                    "See you soon!");
        determinadorDeIdiomas.Add("continuar", "Continue");
        return determinadorDeIdiomas;
    }
}

public class EncuestaIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("poll", "Poll");
        determinadorDeIdiomas.Add("movil", "Answer in your phone...");
        determinadorDeIdiomas.Add("siguiente", "Next question in ");
        determinadorDeIdiomas.Add("segundos", " seconds.");
        determinadorDeIdiomas.Add("segundo", " second.");
        return determinadorDeIdiomas;
    }
}

public class PanelHistoriasIngles : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("prioridad", "Priority: ");
        determinadorDeIdiomas.Add("puntos", "Points: ");
        return determinadorDeIdiomas;
    }
}