using UnityEngine;
using UnityEngine.EventSystems;

public class controladorPuntoTouch : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public ControladorFerrocarril controlador;
    private Vector3 posicionOriginal;
    private bool draggable=true;

    private void Start( )
    {
        posicionOriginal = GetComponent<RectTransform>().localPosition;
    }
    public void OnDrag( PointerEventData eventData )
    {
        if (draggable)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag( PointerEventData eventData )
    {
        if (draggable)
        {
            GetComponent<RectTransform>().localPosition = posicionOriginal;
        }
        draggable = true;

    }

    private void OnTriggerEnter( Collider other )
    {
        if (other.gameObject.CompareTag( "muro" ))
        {
            volverAlInicio();
            draggable = false;

        }
        if (other.gameObject.name.Equals( "fin" ))
        {
            controlador.mostrarPantallaDeVictoria();
            volverAlInicio();
        }
    }

    public void volverAlInicio( )
    {
        GetComponent<RectTransform>().localPosition = posicionOriginal;
    }
}
