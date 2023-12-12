using UnityEngine;

public class PilarCaida : MonoBehaviour
{
    bool playerInside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void Update()
    {
        if (playerInside && Input.GetMouseButtonDown(0))
        {
            transform.Rotate(Vector3.forward * 100f * Time.deltaTime); 
        }
    }
}





