using UnityEngine;
using UnityEngine.EventSystems;

public class controladorPuntoTouch : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 posicionOriginal;

    private void Start( )
    {
        posicionOriginal = GetComponent<RectTransform>().localPosition;
    }
    public void OnDrag( PointerEventData eventData )
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag( PointerEventData eventData )
    {
        Debug.Log( "Termino el drag" );
    }

    private void OnTriggerEnter( Collider other )
    {
        if (other.gameObject.CompareTag( "muro" ))
        {
            volverAlInicio();
        }
    }

    public void volverAlInicio( )
    {
        GetComponent<RectTransform>().localPosition = posicionOriginal;
    }
}
