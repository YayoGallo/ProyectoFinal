using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalesMuertes : MonoBehaviour
{
    public ControlFinalesTuto controlFinalesTuto;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controlFinalesTuto.EmpezarDialogo();
        }
    }
}
