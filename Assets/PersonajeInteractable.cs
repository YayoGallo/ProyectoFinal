using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonajeInteractable : MonoBehaviour
{
    private string palabra;
    private bool inicio;
    [SerializeField, TextArea(4,6)] private string[] arrayTextos;
    [SerializeField] private TMP_Text texto;
    [SerializeField] private GameObject cuadroTexto;
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private string defaultDialogo;
    public Queue<string> colaTextos = new Queue<string>(); 
    public PersonajeEvento evento;
    public bool isPlayerInRange;

    private void Start() {
        foreach (string textoGuardar in arrayTextos){
            colaTextos.Enqueue(textoGuardar);
        }
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.T))
        {
            if(!inicio){
                EmpezarDialogo();
            }else{
                if (Input.GetKeyDown(KeyCode.T)){
                    cuadroTexto.SetActive(false);
                    inicio=false;
                }
            }
        }
    }

    private void EmpezarDialogo(){
        inicio=true;
        cuadroTexto.SetActive(true);
        palabra=obtenerPalabra();
        StartCoroutine(Linea());
    }

    private IEnumerator Linea(){
        texto.text=string.Empty;
        foreach(char ch in palabra){
            texto.text+=ch;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }

    private string obtenerPalabra(){
        if(colaTextos.Count != 0){
            return colaTextos.Dequeue();
        }
        return defaultDialogo;
    }
}


