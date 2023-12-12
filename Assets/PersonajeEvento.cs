using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonajeEvento : MonoBehaviour
{
    public PersonajeInteractable personaje;

    void Update()
    {
        if (personaje.isPlayerInRange && personaje.colaTextos.Count == 0 && Input.GetKeyDown(KeyCode.Y)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
