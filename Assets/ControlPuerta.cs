using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPuerta : MonoBehaviour
{
    public string requiredKeyName; // El nombre necesario para abrir la puerta
    public Inventario inventory;
    private bool isPlayerInRange;


    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Y))
        {
            TryOpen();
        }
    }

    private void TryOpen()
    {
            if (inventory.items.Count > 0)
            {
                string lastItem = inventory.items.Peek(); // Obtiene el último ítem sin eliminarlo de la pila
                if (lastItem == requiredKeyName)
                {
                    inventory.RemoveItem();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                }
                else
                {
                    Debug.Log("No tienes la llave necesaria para abrir esta puerta.");
                }
            }
            else
            {
                Debug.Log("El inventario está vacío, necesitas la llave para abrir esta puerta.");
            }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}
