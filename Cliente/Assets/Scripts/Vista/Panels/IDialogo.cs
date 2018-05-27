public interface IDialogo{
    string [] cargarDialogoImpedimento(string scrumMaster);
    string [] cargarDialogosIteracion(int indice, string scrumMaster);
    string [] cargarDialogoFinSprint(int indice, string scrumMaster);
}