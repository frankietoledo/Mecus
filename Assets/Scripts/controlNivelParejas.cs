using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlNivelParejas : MonoBehaviour {

    public float tiempo;
    public carta[] cartas;
    public bool disponible = true;
    public int pares;
    public ControladorApref controladorDelApref;

    private carta cartaAnterior;

    public void hacerClic(carta _carta)
    {
        if (cartaAnterior == null)
        {
            cartaAnterior = _carta;
        }
        else
        {
            if (compararCartas(cartaAnterior,_carta))
            {
                cartaAnterior.GetComponent<Button>().interactable = false;
                _carta.GetComponent<Button>().interactable = false;
                restarPar();
            }
            else
            {
                _carta.voltearCarta();
                cartaAnterior.voltearCarta();
            }
            cartaAnterior = null;
        }
    }

    private void restarPar()
    {
        pares -= 1;
        if (pares == 0)
        {
            foreach (carta c in cartas){
                c.GetComponent<Button>().interactable = true;
            }
            controladorDelApref.mostrarPantallaDeVictoria();
        }
    }

    private bool compararCartas(carta cartaAnterior, carta carta)
    {
        return (cartaAnterior.getId() == carta.getId());
    }
}
