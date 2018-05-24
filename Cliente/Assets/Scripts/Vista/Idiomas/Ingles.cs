
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