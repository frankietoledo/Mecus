using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public bool draggable = true;
    public esquinaDomino izquierda,derecha;

    private bool ondrag = false;
    private controladorDominos parent;
    private Vector3 posicionOriginal;

    private void Start( )
    {
        parent = GetComponentInParent<controladorDominos>();
        posicionOriginal = GetComponent<RectTransform>().localPosition;
    }
    public void OnPointerClick( PointerEventData eventData )
    {
        if (!ondrag && draggable)
        {
            transform.Rotate( 0, 0, 90 );
        }
        verificarColliders();
    }

    internal void reubicarPieza( )
    {
        RectTransform rt =  GetComponent<RectTransform>();
        rt.localPosition=posicionOriginal;
        rt.rotation = new Quaternion( 0, 0, 0, 0 );
        draggable = true;
        Debug.Log( "Reubicada " + gameObject.name );
    }

    public void OnBeginDrag( PointerEventData eventData )
    {
        ondrag = true;
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
        if (ondrag == false)
        {
            verificarColliders();
        }
        ondrag = false;
    }



    public void verificarColliders( )
    {

        bool i,d;
        i = false;
        d = false;
        if (draggable)
        {

            if (izquierda.verificarCollision())
            {
                i = true;
                izquierda.avisarAlOtro();
                draggable = false; 
                parent.restarFicha();
            }
            if (derecha.verificarCollision())
            {
                d = true;
                derecha.avisarAlOtro();
                draggable = false;
                parent.restarFicha();
            }
        }
    }

}