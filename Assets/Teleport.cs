using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destino; 
    public Inventario inventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            other.transform.position = destino.position; 
        }
    }

    void Update()
    {
        if (inventory.items.Count == 6)
        {
            gameObject.SetActive(false); 
        }
    }

}

