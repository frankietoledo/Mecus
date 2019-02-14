using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonCorrectoBerini : MonoBehaviour {

    public ControladorBerini controller;

    public void presionado1()
    {

        controller.mostrarPantallaDeVictoria();
    }
}
