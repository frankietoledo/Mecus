using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorCasaDeLaCultura : MonoBehaviour
{

    public GameObject pantallaDeVictoria,pantallasDeSeleccion;
    public GameObject juego1, juego2,juego3,juego20;
    public GameObject[] niveles;
    public Text piezasPuzzle, estrellas, textNivelGanado;
    public Animator animGrilla;

    /// <summary>
    /// Esta variable la uso para el seguimiento del nivel actual
    /// </summary>
    private int nivelActual;
    private int maximoNivelAlcanzado;
    //usadas para llevar la cuenta de cuantas cosas tiene
    private int pienasint;
    private int estrellaint;

    private void Start( )
    {
        nivelActual = 1;
        pienasint = PlayerPrefs.GetInt( "piezas", 0 );
        estrellaint = PlayerPrefs.GetInt( "estrellas", 0 );
        estrellas.text = estrellaint.ToString();
        piezasPuzzle.text = pienasint.ToString();

        maximoNivelAlcanzado = PlayerPrefs.GetInt( "maximoNivelAlcanzadoCasaCultura", 1 );
        repintar();
    }

    public void repintar( )
    {
        foreach (GameObject i in niveles)
        {
            if (int.Parse( i.name ) <= maximoNivelAlcanzado)
            {
                i.GetComponent<Image>().color = new Color32( 199, 224, 221, 255 );
            }
        }
    }

    public void AvanzarGrilla( int paginaGrilla )
    {
        animGrilla.SetInteger( "paginaGrilla", paginaGrilla );
    }
    public void iniciarNivel( int numeroDeNivel )
    {
        if (numeroDeNivel <= maximoNivelAlcanzado || numeroDeNivel == 20)
        {
            pantallasDeSeleccion.SetActive( false );
            switch (numeroDeNivel)
            {
                case 1:
                    iniciarNivel1();
                    nivelActual = 1;
                    break;
                case 2:
                    iniciarNivel2();
                    nivelActual = 2;
                    break;
                case 3:
                    iniciarNivel3();
                    nivelActual = 3;
                    break;
                case 20:
                    iniciarNivel20();
                    nivelActual = 20;
                    break;
                default:
                    pantallasDeSeleccion.SetActive( true );
                    break;
            }

        }
    }

    private void iniciarNivel20( )
    {
        juego20.SetActive( true );
    }
    private void iniciarNivel3( )
    {
        juego3.SetActive( true );
    }
    private void iniciarNivel2( )
    {
        juego2.SetActive( true );
    }
    private void iniciarNivel1( )
    {
        juego1.SetActive( true );
    }
    public void volverAlHome( )
    {
        SceneManager.LoadScene( "MainMenu", LoadSceneMode.Single );
    }
    public void mostrarPantallaDeVictoria( )
    {
        juego1.SetActive( false );
        juego2.SetActive( false );
        juego3.SetActive( false );
        juego20.SetActive( false );
        pantallaDeVictoria.SetActive( true );
        textNivelGanado.text = "NIVEL " + nivelActual;

        if (nivelActual == 4)
        {
            nivelActual = 20;
        }
        else
        {
            nivelActual += 1;
        }

        if (maximoNivelAlcanzado < nivelActual && nivelActual <= 4)
        {
            actualizarItems( 1, 2 );
            maximoNivelAlcanzado += 1;
            PlayerPrefs.SetInt( "maximoNivelAlcanzadoCasaCultura", maximoNivelAlcanzado );
        }
    }

    /// <summary>
    /// Funcion para actualizar los datos de la barra superior y guardarlos en playerprefs.
    /// </summary>
    /// <param name="sumarPiezasPuzzles">Cantidad de piezas de puzzle a sumar</param>
    /// <param name="sumarEstrellas">Cantidad de estrellas a sumar</param>
    private void actualizarItems( int sumarPiezasPuzzles, int sumarEstrellas )
    {
        pienasint += sumarPiezasPuzzles;
        estrellaint += sumarEstrellas;
        estrellas.text = estrellaint.ToString();
        piezasPuzzle.text = pienasint.ToString();
        PlayerPrefs.SetInt( "piezas", pienasint );
        PlayerPrefs.SetInt( "estrellas", estrellaint );
    }

    public void avanzarSiguienteNivel( )
    {
        if (nivelActual == 4)
        {
            iniciarNivel( 20 );
        }
        else
        {
            iniciarNivel( nivelActual );
        }

        pantallaDeVictoria.SetActive( false );
    }
    public void irRecompensasEstrellas( )
    {
        SceneManager.LoadScene( "RecompensasEstrellas", LoadSceneMode.Single );
    }

    public void irRecompensasPiezas( )
    {
        SceneManager.LoadScene( "RecompensasPiezas", LoadSceneMode.Single );
    }
}
