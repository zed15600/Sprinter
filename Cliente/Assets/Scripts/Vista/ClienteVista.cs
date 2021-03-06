﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteVista : ClientElement, IVista {

    private Idioma idioma;

    public VistaPerfil vistaPerfil;
    public VistaMenuJugador vistaMenuJugador;
    public VistaMenuInvestigador vistaMenuInvestigador;
    public VistaConfiguracionDePartidas configuracionDePartida;
    public VistaUnirseAPartida unirseAPartida;
    public VistaScrumPlanning scrumPlanning;
    public VistaSprintPlanning sprintPlanning;
    public VistaSprint vistaSprint;
    public VistaResultados resultados;
    public VistaRetrospectiva retrospectiva;
    public VistaFinDelJuego finDelJuego;
    public VistaMinijuegos minijuegos;
    public VistaReunionDiaria reunion;
    public VistaConfiguracion configuracion;
    public VistaEncuesta encuesta;
    public VistaConfiguracionEnJuego vistaConfiguracionEnJuego;
    public GameObject vistaPartidas;

    public PanelHistorias panelHistorias;
    public PanelDialogoGlobal dialogoGlobal;
    public PanelVotacion panelVotacionSPlanning;
    public PanelVotacion panelVotacionDia;
    public GameObject pnlMenssage;

    public void cambiarIdioma(Idioma idioma) {
        switch (idioma.traerRecursos()["idioma"]) {
            case "español":
                vistaPerfil.cambiarIdioma(new PerfilEspañol());
                vistaMenuJugador.cambiarIdioma(new MenuJugadorEspañol());
                vistaMenuInvestigador.cambiarIdioma(new MenuInvestigadorEspañol());
                configuracion.cambiarIdioma(new ConfiguracionEspañol());
                configuracionDePartida.cambiarIdioma(new ConfPartidaEspañol());
                scrumPlanning.cambiarIdioma(new ScrumPlanningEspañol());
                sprintPlanning.cambiarIdioma(new SprintPlanningEspañol());
                vistaSprint.cambiarIdioma(new SprintEspañol());
                unirseAPartida.cambiarIdioma(new UnirseEspañol());
                reunion.cambiarIdioma(new DailyEspañol());
                minijuegos.cambiarIdioma(new MinijuegoEspañol());
                resultados.cambiarIdioma(new ResultadosEspañol());
                retrospectiva.cambiarIdioma(new RetrospectivaEspañol());
                finDelJuego.cambiarIdioma(new FinEspañol());
                encuesta.cambiarIdioma(new EncuestaEspañol());
                panelHistorias.cambiarIdioma(new PanelHistoriasEspañol());
                dialogoGlobal.cambiarIdioma(new DialogoEspañol());
                vistaConfiguracionEnJuego.cambiarIdioma(new ConfiguracionEspañol());
                return;

            case "ingles":
                vistaPerfil.cambiarIdioma(new PerfilIngles());
                vistaMenuJugador.cambiarIdioma(new MenuJugadorIngles());
                vistaMenuInvestigador.cambiarIdioma(new MenuInvestigadorIngles());
                configuracion.cambiarIdioma(new ConfiguracionIngles());
                configuracionDePartida.cambiarIdioma(new ConfPartidaIngles());
                scrumPlanning.cambiarIdioma(new ScrumPlanningIngles());
                sprintPlanning.cambiarIdioma(new SprintPlanningIngles());
                vistaSprint.cambiarIdioma(new SprintIngles());
                unirseAPartida.cambiarIdioma(new UnirseIngles());
                reunion.cambiarIdioma(new DailyIngles());
                minijuegos.cambiarIdioma(new MinijuegoIngles());
                resultados.cambiarIdioma(new ResultadosIngles());
                retrospectiva.cambiarIdioma(new RetrospectivaIngles());
                finDelJuego.cambiarIdioma(new FinIngles());
                encuesta.cambiarIdioma(new EncuestaIngles());
                panelHistorias.cambiarIdioma(new PanelHistoriasEspañol());
                dialogoGlobal.cambiarIdioma(new DialogoIngles());
                vistaConfiguracionEnJuego.cambiarIdioma(new ConfiguracionIngles());
                return;
        }
    }

    public void inicializarVista() {
        idioma = new ClienteEspañol();
        cambiarIdioma(idioma);
    }

    void OnEnable() {
        inicializarVista();
    }
}
