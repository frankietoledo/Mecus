using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorDominos : MonoBehaviour {

    public int fichas=2;
    public ControladorCasaDeLaCultura ControladorCasaDeLaCultura;

    public void restarFicha( )
    {
        fichas-=1;
        if (fichas == 0)
        {
            ControladorCasaDeLaCultura.mostrarPantallaDeVictoria();
            reubicarPiezas();
        }
    }

    private void reubicarPiezas( )
    {
        foreach (esquinaDomino eq in GetComponentsInChildren<esquinaDomino>())
        {
            eq.setHabilitado( false );
        }
        foreach (DragScript d in GetComponentsInChildren<DragScript>())
        {
            d.reubicarPieza();
        }    
    }
}
