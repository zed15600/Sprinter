public class PanelDialogoGlobal : ClientElement {

    IDialogo dialogo;
    public DialogTrigger trigger;
    private string nombreScrumMaster;
    private string[] lineasDeDialogo;

    private bool dialogosFinales = true;
    private bool dialogosIteracion = true;
    private bool dialogoImpedimento = true;

    public void cargarDialogosIteracion(int indice) {
        if (dialogosIteracion) {
            lineasDeDialogo = dialogo.cargarDialogosIteracion(indice , controlador.obtenerScrumMaster());
            if (indice == 9) {
                dialogosIteracion = false;
                trigger.dialogo.lineasDeDialogo = lineasDeDialogo;
            }
        }

        if (dialogosIteracion) {
            trigger.dialogo.lineasDeDialogo = lineasDeDialogo;
        }
    }

    public void cargarDialogoImpedimento() {
        if (dialogoImpedimento) {
            lineasDeDialogo = dialogo.cargarDialogoImpedimento(controlador.obtenerScrumMaster());
            dialogoImpedimento = false;
            trigger.dialogo.lineasDeDialogo = lineasDeDialogo;
        }
    }

    public void cargarDialogoFinSprint(int indice) {
        lineasDeDialogo = dialogo.cargarDialogoFinSprint(indice, controlador.obtenerScrumMaster());
        if(indice == 12) {
            dialogosFinales = false;
        }
        trigger.dialogo.lineasDeDialogo = lineasDeDialogo;
    }

    public bool getDialogosFinales() {
        return dialogosFinales;
    }

    public bool getDialogosIteracion() {
        return dialogosIteracion;
    }

    public bool getDialogosImpedimento() {
        return dialogoImpedimento;
    }

    public void cambiarIdioma(IDialogo dialogo) {
        this.dialogo = dialogo;
    }

    void OnEnable() {
        trigger.TriggerDialog();
    }

    void Update() {
        if (controlador.verificarDialogoVacio()) {
            gameObject.SetActive(false);
        }
    }

    public bool dialogoVacio() {
        return FindObjectOfType<DialogManager>().dialogoEstaVacio();
    }

    public void mostrarDialogo() {
        gameObject.SetActive(true);
    }
}
