using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoNivelUno : MonoBehaviour
{
    [SerializeField] private GameObject MafiOSO;
    [SerializeField] private GameObject Troca;

     void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el jugador ha entrado en el BoxCollider
        if (other.CompareTag("Pilar"))
        {
            DesaparecerYReaparecer();
        }
    }

    void DesaparecerYReaparecer()
    {
        MafiOSO.SetActive(false);
        Troca.SetActive(true);
    }
}
