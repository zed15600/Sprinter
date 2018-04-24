using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour {

    public Dialogo dialogo;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogo);
    }
}
