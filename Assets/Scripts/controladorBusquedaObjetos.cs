using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorBusquedaObjetos : MonoBehaviour {


    public int cantidadObjetos;
    public bool buscarEnHuerto = false;
    public void restarObjetos()
    {
        cantidadObjetos -= 1;
        if (cantidadObjetos == 0)
        {
            Invoke("PasarNivel", 2f);
        }
    }
    public void PasarNivel()
    {
        if (buscarEnHuerto)
        {
            GameObject.FindObjectOfType<ControladorHuerto>().mostrarPantallaDeVictoria();
        }
        else
        {
            GameObject.FindObjectOfType<ControladorMunicipalidad>().mostrarPantallaDeVictoria();
        }
    }
}
