using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public string itemName; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventario inventory = collision.GetComponent<Inventario>();
            if (inventory != null)
            {
                inventory.AddItem(itemName); 
                gameObject.SetActive(false); 
                Destroy(gameObject);
            }
        }
    }
}


