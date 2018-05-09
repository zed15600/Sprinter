using UnityEngine;

public class ClientElement : MonoBehaviour {
	public ClienteControlador controlador { get { return GameObject.FindObjectOfType<ClienteControlador>(); }}
}


