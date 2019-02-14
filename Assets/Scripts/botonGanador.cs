using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botonGanador : MonoBehaviour {
    public ControladorPuenteFierro controller;
    public float retardoVictoria=2.5f;

	public void presionado1()
    {
        controller = GameObject.FindGameObjectWithTag("ControladorPuenteFierro").GetComponent<ControladorPuenteFierro>();
        Invoke( "avanzando", retardoVictoria );
    }

    public void avanzando( )
    {
        controller.mostrarPantallaDeVictoria();
    }
}
