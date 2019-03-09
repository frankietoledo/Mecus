using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esquinaDomino : MonoBehaviour {

    public string pieza;
    private DragScript parent;
    private bool habilitado = false;
    private esquinaDomino eq;

    public string getPieza( )
    {
        return pieza;
    }
    public void setHabilitado(bool valor )
    {
        this.habilitado = valor;
    }

    public void Start( )
    {
        parent = GetComponentInParent<DragScript>(); 
    }
    private void OnTriggerExit( Collider other )
    {
        habilitado = false;
    }
    private void OnTriggerStay( Collider collision )
    {
        eq = collision.GetComponent<esquinaDomino>();
        if (eq.getPieza().Equals( pieza ))
        {
            habilitado = true;
        }
    }

    public bool verificarCollision( )
    {
        return habilitado;
    }

    public void avisarAlOtro( )
    {
        eq.GetComponentInParent<DragScript>().draggable = false;
    }
}
