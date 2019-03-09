using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class piezaDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public controladorNivelSocEsp controlador;
    private Vector3 posicionOriginal;
    private bool draggable=true;
    private bool piezaEnJuego= true;

    private void Start( )
    {
        posicionOriginal = GetComponent<RectTransform>().localPosition;
    }

    public void OnDrag( PointerEventData eventData )
    {
        if (draggable && piezaEnJuego)
        {
            transform.position = Input.mousePosition;
            transform.localScale = new Vector3( 2, 2, 2 );
        }
    }

    public void OnEndDrag( PointerEventData eventData )
    {
        if (draggable && piezaEnJuego)
        {
            GetComponent<RectTransform>().localPosition = posicionOriginal;
            transform.localScale = new Vector3( 1,1,1);
        }
        draggable = true;

    }

    private void OnTriggerEnter( Collider other )
    {
        if (other.gameObject.name.Equals( this.gameObject.name ))
        {
            GetComponent<RectTransform>().localPosition = other.GetComponent<RectTransform>().localPosition;
            draggable = false;
            piezaEnJuego = false;
            controlador.restarPieza();
        }
    }
    public void reiniciarNivel( )
    {
        GetComponent<RectTransform>().localPosition = posicionOriginal;
        transform.localScale = new Vector3( 1, 1, 1 );
        draggable = true;
        piezaEnJuego = true;
    }

    public void volverAlInicio( )
    {
        GetComponent<RectTransform>().localPosition = posicionOriginal;
    }


}
