using UnityEngine;

public class ClientElement : MonoBehaviour {
	public ClientApplication app { get { return GameObject.FindObjectOfType<ClientApplication>(); }}
}

public class ClientApplication : MonoBehaviour {

	public ClienteModelo modelo;
	public ClienteVista vista;
	public ClienteControlador controlador;

	// Use this for initialization
	void Start () {
        modelo = new ClienteModelo();
        vista = new ClienteVista();
        controlador = new ClienteControlador();
	}
}
