
using System.Collections.Generic;

public class ClienteEspañol: Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("idioma","español");
        return determinadorDeIdiomas;
    }
}

public class PerfilEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Seleccione su tipo de Usuario:");
        determinadorDeIdiomas.Add("jugador", "Jugador");
        determinadorDeIdiomas.Add("investigador", "Investigador");
        determinadorDeIdiomas.Add("salida", "Salir");
        return determinadorDeIdiomas;
    }
}

public class MenuJugadorEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("iniciar", "Iniciar Partida");
        determinadorDeIdiomas.Add("configuracion", "Configuración");
        determinadorDeIdiomas.Add("volver", "Volver");
        return determinadorDeIdiomas;
    }
}

public class MenuInvestigadorEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("datos", "Visualizar Datos");
        determinadorDeIdiomas.Add("volver", "Volver");
        return determinadorDeIdiomas;
    }
}

public class ConfiguracionEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Configuración");
        determinadorDeIdiomas.Add("volumen", "Volumen");
        determinadorDeIdiomas.Add("idioma", "Idioma");
        determinadorDeIdiomas.Add("dialogos", "Diálogos");
        determinadorDeIdiomas.Add("volver", "Volver");
        determinadorDeIdiomas.Add("aplicar", "Aplicar");
        return determinadorDeIdiomas;
    }
}

public class ConfPartidaEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Configuración de Partida");
        determinadorDeIdiomas.Add("nombre", "Tu Nombre:");
        determinadorDeIdiomas.Add("partida", "Nombre de Partida:");
        determinadorDeIdiomas.Add("proyecto", "Selecciona un Proyecto:");
        determinadorDeIdiomas.Add("continuar", "Continuar");
        determinadorDeIdiomas.Add("volver", "Volver");
        return determinadorDeIdiomas;
    }
}

public class ScrumPlanningEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("historia", "Historia");
        determinadorDeIdiomas.Add("prioridad", "Prioridad");
        determinadorDeIdiomas.Add("puntos", "Puntos");
        determinadorDeIdiomas.Add("continuar","Continuar");
        return determinadorDeIdiomas;
    }
}

public class SprintPlanningEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("historia", "Historia");
        determinadorDeIdiomas.Add("prioridad", "Prioridad");
        determinadorDeIdiomas.Add("puntos", "Puntos");
        determinadorDeIdiomas.Add("status", "Estado");
        determinadorDeIdiomas.Add("numeroSTR1", "Sprint Número: ");
        determinadorDeIdiomas.Add("numeroSTR2", ".");
        determinadorDeIdiomas.Add("restantesSTR1", "Quedan ");
        determinadorDeIdiomas.Add("restantesSTR2", " Sprints.");
        determinadorDeIdiomas.Add("votos", "Elegir Historias del Sprint");
        return determinadorDeIdiomas;
    }
}

public class SprintEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("historia", "Historia");
        determinadorDeIdiomas.Add("prioridad", "Prioridad");
        determinadorDeIdiomas.Add("puntos", "Puntos");
        determinadorDeIdiomas.Add("continuar", "Elegir Historia del Día");
        determinadorDeIdiomas.Add("STRtrestante", "Tiempo restante: ");
        determinadorDeIdiomas.Add("STRDia", " día.");
        determinadorDeIdiomas.Add("STRDias", " días.");
        return determinadorDeIdiomas;
    }
}

public class UnirseEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Código de Partida");
        determinadorDeIdiomas.Add("volver", "Volver");
        determinadorDeIdiomas.Add("continuar", "Continuar");
        return determinadorDeIdiomas;
    }
}

public class DailyEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Reunión Diaria");
        determinadorDeIdiomas.Add("criterios", "Criterios de Aceptación");
        determinadorDeIdiomas.Add("problemas", "En Problemas;");
        determinadorDeIdiomas.Add("desarrollo", "El desarrollo empieza en:");
        determinadorDeIdiomas.Add("continuar", "Continuar");
        determinadorDeIdiomas.Add("dia","Día: ");
        return determinadorDeIdiomas;
    }
}

public class MinijuegoEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Minijuego");
        determinadorDeIdiomas.Add("diseño","Diseño");
        determinadorDeIdiomas.Add("construccion", "Construcción");
        determinadorDeIdiomas.Add("pruebas", "Pruebas");
        determinadorDeIdiomas.Add("criterios","Criterios de Aceptación");
        determinadorDeIdiomas.Add("seleccionar","Selecciona los criterios cumplidos");
        determinadorDeIdiomas.Add("continuar","Continuar");
        return determinadorDeIdiomas;
    }
}

public class ResultadosEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Resultados");
        determinadorDeIdiomas.Add("puntos", "Puntos");
        determinadorDeIdiomas.Add("criterios", "Criterios de Aceptación");
        determinadorDeIdiomas.Add("continuar", "Continuar");
        determinadorDeIdiomas.Add("completa", "¡Completada!");
        determinadorDeIdiomas.Add("incompleta", "¡Incompleta!");
        return determinadorDeIdiomas;
    }
}

public class RetrospectivaEspañol : Idioma {
    public Dictionary<string, string> traerRecursos() {
        Dictionary<string, string> determinadorDeIdiomas = new Dictionary<string, string>();
        determinadorDeIdiomas.Add("titulo", "Retrospectiva");
        determinadorDeIdiomas.Add("buen trabajo", "Lograron completar todas las historias del Sprint! \n" +
                        "El cliente esta muy satisfecho con el trabajo hecho, Felicidades. :D");
        determinadorDeIdiomas.Add("mal trabajo", "Parece que faltaron algunas historias por completar. :( \n" +
                        "El cliente espera más compromiso de parte de ustedes.");
        determinadorDeIdiomas.Add("continuar", "Continuar");
        return determinadorDeIdiomas;
    }
}