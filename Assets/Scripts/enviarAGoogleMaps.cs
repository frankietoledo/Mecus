using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class enviarAGoogleMaps : MonoBehaviour, IPointerClickHandler{
    public string direccion;

    public void OnPointerClick( PointerEventData eventData )
    {
        Application.OpenURL( "http://maps.google.com/maps?q="+direccion+" pergamino buenos aires");
    }
   
}
