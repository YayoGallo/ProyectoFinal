using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonerObjetos : MonoBehaviour
{
    [SerializeField] private GameObject objeto;
    public string objetoNecesario;
    public Inventario inventory;
    string lastItem;

    void Update()
    {
        if (inventory.items.Count > 0)
        {
            lastItem = inventory.items.Peek(); 
            if (lastItem == objetoNecesario&&Input.GetKeyDown(KeyCode.Y))
                { 
                    TryPut();
                    inventory.RemoveItem();
                }
        }
    }

    private void TryPut(){
        objeto.SetActive(true);
    }
}
