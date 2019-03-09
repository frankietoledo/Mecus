using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorNivelSocEsp : MonoBehaviour {

    public int piezas =2;
    public ControladorSocEspañola controlador;
    public piezaDrag pieza1,pieza2;

    public void restarPieza( )
    {
        piezas -= 1;
        if (piezas == 0)
        {
            Invoke( "siguienteNivel", 1f );
        }
    }

    public void siguienteNivel( )
    {
        piezas = 2;
        controlador.mostrarPantallaDeVictoria();
        pieza1.reiniciarNivel();
        pieza2.reiniciarNivel();
    }
}
