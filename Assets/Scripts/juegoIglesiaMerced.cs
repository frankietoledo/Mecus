using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juegoIglesiaMerced : MonoBehaviour {
    public ControladorIglesiaMerced control;
	public void avanzar()
    {
        Invoke("LlamarSiguienteNivel", 1);
    }
    private void Start()
    {
        control = GameObject.FindObjectOfType<ControladorIglesiaMerced>();       
    }
    public void LlamarSiguienteNivel()
    {
        control.mostrarPantallaDeVictoria();
    }
}
