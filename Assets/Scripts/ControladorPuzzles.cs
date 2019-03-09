using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorPuzzles : MonoBehaviour {

    private int canje1, canje2, canje3, canje4;
    public GameObject canje1Img, canje2Img, canje3Img, canje4Img;
    public Animator movimiento;
    private int pienasint;
    private int estrellaint;
    public Text estrellas, piezasPuzzle;

    private void Start( )
    {
        canje1 = PlayerPrefs.GetInt( "canje1", 0 );
        canje2 = PlayerPrefs.GetInt( "canje2", 0 );
        canje3 = PlayerPrefs.GetInt( "canje3", 0 );
        canje4 = PlayerPrefs.GetInt( "canje4", 0 );

        restaurarCompras();

        pienasint = PlayerPrefs.GetInt( "piezas", 0 );
        estrellaint = PlayerPrefs.GetInt( "estrellas", 0 );
        estrellas.text = estrellaint.ToString();
        piezasPuzzle.text = pienasint.ToString();
    }

    private void restaurarCompras( )
    {
        canje1Img.SetActive( canje1 == 1 );
        canje2Img.SetActive( canje2 == 1 );
        canje3Img.SetActive( canje3 == 1 );
        canje4Img.SetActive( canje4 == 1 );
    }

    public void avanzar( )
    {
        movimiento.SetInteger("pagina", 1 );
    }
    public void retroceder( )
    {
        movimiento.SetInteger( "pagina", 0 );
    }
    public void volverAlHome( )
    {
        SceneManager.LoadScene( "MainMenu", LoadSceneMode.Single );
    }
    public void irCompraEstrellas( )
    {
        SceneManager.LoadScene( "RecompensasEstrellas", LoadSceneMode.Single);
    }
}
