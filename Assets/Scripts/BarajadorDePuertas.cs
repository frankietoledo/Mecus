using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarajadorDePuertas : MonoBehaviour {
    public Animator animNivel1;
    public string animacionEntrada;
    
    public void iniciarNivel()
    {
        animNivel1.SetTrigger(animacionEntrada);	
    }
}
