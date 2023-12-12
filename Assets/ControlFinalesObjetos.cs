using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFinalesObjetos : MonoBehaviour
{
    public ControlFinalesTuto controlFinalesTuto;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controlFinalesTuto.ActivarDialogoEnColision();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controlFinalesTuto.DesactivarDialogoEnColision();
        }
    }
}
