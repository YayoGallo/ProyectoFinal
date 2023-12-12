using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalesSinObjetosClave : MonoBehaviour
{
    public Inventario inventory;
    public ControlFinalesTuto controlFinalesTuto;

    void Update()
    {
        if (inventory.ShowItem() != "Vacio" && Input.GetKeyDown(KeyCode.X)){
            controlFinalesTuto.EmpezarDialogo();
        }
    }
}
