using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public Stack<string> items = new Stack<string>(); 

    public void AddItem(string itemName)
    {
        items.Push(itemName); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            RemoveItem();
        }
    }

    public void RemoveItem()
    {
        if (items.Count > 0)
        {
            string removedItem = items.Pop(); 
            Debug.Log("Ítem " + removedItem + " eliminado del inventario.");
        }
        else
        {
            Debug.Log("El inventario está vacío.");
        }
    }

    public string ShowItem()
    {
        if (items.Count > 0)
        {
            return items.Peek(); // Devuelve el elemento en la cima de la pila sin eliminarlo
        }
        else
        {
            return "Vacio"; // Si la pila está vacía, devuelve "vacio"
        }
    }

}

