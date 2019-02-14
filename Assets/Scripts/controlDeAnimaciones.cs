using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlDeAnimaciones : MonoBehaviour {
    public Animator animadorDelMenu;
    public int paso;

    /// <summary>
    /// Funcion utilizada para generar un paso entre las animaciones establecidas para el menu principal, si recibe 1 avanza una posicion si recibe -1 retrocede.
    /// </summary>
    /// <param name="i">Utilizar solamente 1 o -1</param>
    public void sumar(int i)
    {
        if (paso == 9)
        {
            paso = -1;
        }
        paso += i;
        animadorDelMenu.SetInteger("paso", paso);
    }

    /// <summary>
    /// Esta funcion toma un nombre que se le pase por parametro para llamar al SceneManager y cargar dicha escena con ese nombre
    /// </summary>
    /// <param name="nivel">Nombre de la escena que se va a cargar</param>
    public void pasarPantalla(string nivel)
    {
        SceneManager.LoadScene(nivel);
    }
}
