using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaCorrecta : MonoBehaviour {
    public Animator AnimadorDeNivel;
    public string nombreTrigger;

	public void clic()
    {
        AnimadorDeNivel.SetTrigger(nombreTrigger);
        Invoke("Avanzar", 2.3f);
    }
    public void Avanzar()
    {
        GameObject.Find("ControladorHotelRoma").GetComponent<ControladorHotelRoma>().mostrarPantallaDeVictoria();
    }
}
