using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorCanje : MonoBehaviour
{

    /// <summary>
    /// Las variables canjeX corresponde con los 4 personajes que hay, 1 laru, 2 rome, 3 mem, 4 luca
    /// </summary>
    private int canje1, canje2, canje3, canje4;
    public Button btnCanje1, btnCanje2, btnCanje3, btnCanje4, btnPiezasPuzzle;
    public Image imgCanje1, imgCanje2, imgCanje3, imgCanje4, personajeComprado;
    public Animator grilla;
    public Text piezasPuzzle, estrellas;
    public GameObject grillaDePersonajes, PantallaDeCompra;
    public Sprite[] personajes;
    public AudioClip sonidoError,sonidoSubirNivel;

    private int pienasint;
    private int estrellaint;
    private AudioSource parlante;

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
        parlante = GetComponent<AudioSource>();
    }

    private void restaurarCompras( )
    {
        if (canje1 == 1)
        {
            btnCanje1.interactable = false;
            imgCanje1.color = new Color32( 200, 200, 200, 198 );
        }
        if (canje2 == 1)
        {
            btnCanje2.interactable = false;
            imgCanje2.color = new Color32( 200, 200, 200, 198 );
        }
        if (canje3 == 1)
        {
            btnCanje3.interactable = false;
            imgCanje3.color = new Color32( 200, 200, 200, 198 );
        }
        if (canje4 == 1)
        {
            btnCanje4.interactable = false;
            imgCanje4.color = new Color32( 200, 200, 200, 198 );
        }
    }

    /// <summary>
    /// este metodo activa la animacion de cambiar a la pagina 2
    /// </summary>
    public void avanzarGrilla( )
    {
        grilla.SetInteger( "pagina", 2 );
    }

    /// <summary>
    /// este metodo activa la animacion para volver a la pagina 1
    /// </summary>
    public void retrocederGrilla( )
    {
        grilla.SetInteger( "pagina", 1 );
    }

    public void volverAlHome( )
    {
        SceneManager.LoadScene( "MainMenu", LoadSceneMode.Single );
    }

    public void scenasPiezasPuzzle( )
    {
        SceneManager.LoadScene( "RecompensasPiezas", LoadSceneMode.Single );
    }

    public void comprarPersonaje( int numero )
    {
        if (ComprobarMonedas( numero ))
        {

            grillaDePersonajes.SetActive( false );
            PantallaDeCompra.SetActive( true );

            switch (numero)
            {
                case 1:
                    btnCanje1.interactable = false;
                    imgCanje1.color = new Color32( 200, 200, 200, 198 );
                    personajeComprado.sprite = personajes[0];
                    PlayerPrefs.SetInt( "canje1", 1 );
                    break;
                case 2:
                    btnCanje2.interactable = false;
                    imgCanje2.color = new Color32( 200, 200, 200, 198 );
                    personajeComprado.sprite = personajes[1];
                    PlayerPrefs.SetInt( "canje2", 1 );
                    break;
                case 3:
                    btnCanje3.interactable = false;
                    imgCanje3.color = new Color32( 200, 200, 200, 198 );
                    personajeComprado.sprite = personajes[2];
                    PlayerPrefs.SetInt( "canje3", 1 );
                    break;
                case 4:
                    btnCanje4.interactable = false;
                    imgCanje4.color = new Color32( 200, 200, 200, 198 );
                    personajeComprado.sprite = personajes[3];
                    PlayerPrefs.SetInt( "canje4", 1 );
                    break;
            }
            Invoke( "cerrarCompra", 3.5f );
        }
    }
    /// <summary>
    /// Comprueba si se tienen las monedas necesarias para realizar la compra del personaje deseado
    /// </summary>
    /// <param name="numero">numero de personaje para el canje, por el momento solo es 1,2,3 o 4</param>
    /// <returns></returns>
    private bool ComprobarMonedas( int numero )
    {
        switch (numero)
        {
            case 1:
                return cantidades( 15, 4 );
                break;
            case 2:
                return cantidades( 15, 10 );
                break;
            case 3:
                //TODO cambiar por los verdaderos valores de la compra de el pajaro naranja
                return cantidades( 30, 15 );
                break;
            case 4:
                return cantidades( 30, 15 );
                break;
            default:
                return false;
                break;
        }
    }

    /// <summary>
    /// metodo para generar una capa mas de abstracción
    /// </summary>
    /// <param name="estrellas">estrellas a comprobar</param>
    /// <param name="piezas">piezas de puzzle a comprobar</param>
    /// <returns></returns>
    private bool cantidades( int estrellas, int piezas)
    {
        if (estrellaint >= estrellas && pienasint >= piezas)
        {
            estrellaint -= estrellas;
            pienasint -= piezas;

            piezasPuzzle.text = pienasint.ToString();
            this.estrellas.text = estrellaint.ToString();

            PlayerPrefs.SetInt( "piezas", pienasint );
            PlayerPrefs.SetInt( "estrellas", estrellaint );

            parlante.PlayOneShot( sonidoSubirNivel );
            return true;
        }
        else
        {
            parlante.PlayOneShot( sonidoError );
            return false;
        }
    }

    private void cerrarCompra( )
    {
        grillaDePersonajes.SetActive( true );
        PantallaDeCompra.SetActive( false );
    }

    public void sumarpuntos( )
    {
        estrellaint += 10;
        pienasint += 10;
        piezasPuzzle.text = pienasint.ToString();
        this.estrellas.text = estrellaint.ToString();
        PlayerPrefs.SetInt( "piezas", pienasint );
        PlayerPrefs.SetInt( "estrellas", estrellaint );

    }
}
