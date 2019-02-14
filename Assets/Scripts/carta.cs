using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carta : MonoBehaviour {
    public float tiempoRetardo;
    public Image elementoInterior;
    public bool Disponible = true;
    public controlNivelParejas controladorNivel;
    public int id;
    public string nombreNivel;
    public Color32 colorInicio, colorFin;

    private void Start()
    {
        Invoke("inicio", tiempoRetardo);
        controladorNivel = GameObject.Find(nombreNivel).GetComponent<controlNivelParejas>();
    }
    public void inicio()
    {
        Disponible = true;
        elementoInterior.color = colorFin;
    }

    public void voltearCarta()
    {
        Invoke("ocultarCarta", tiempoRetardo);
        controladorNivel.disponible = false;
        Disponible = true;
    }
    public void ocultarCarta()
    {
        Disponible = true;
        controladorNivel.disponible = true;
        elementoInterior.color = colorFin;
    }
    public void mostrarCarta()
    {
        if (Disponible && controladorNivel.disponible){
            Disponible = false;
            elementoInterior.color = colorInicio;
            controladorNivel.hacerClic(this);
        }
    }

    public int getId()
    {
        return this.id;
    }
}
