using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControlFinalesTuto : MonoBehaviour
{
    [SerializeField] private TMP_Text texto;
    [SerializeField] private GameObject final;
    [SerializeField, TextArea(4,6)] private string[] arrayTextos;
    public Inventario inventory;
    public string objetoActivarFinal;
    private bool inicio;
    private string palabra;
    private Queue<string> colaTextos = new Queue<string>(); 
    string lastItem;
    public ControlFinalesObjetos controlFinalesObjetos;
    private bool puedeIniciarDialogo = false;

    private void Start() {
        foreach (string textoGuardar in arrayTextos){
            colaTextos.Enqueue(textoGuardar);
        }
    }

    void Update()
    {
        if (inventory.items.Count > 0)
        {
            lastItem = inventory.items.Peek(); 
            if (SceneManager.GetActiveScene().buildIndex == 1){
                if (lastItem == objetoActivarFinal&&Input.GetKeyDown(KeyCode.Y))
                { 
                    if (!inicio)
                    {
                        EmpezarDialogo();
                    }
                }
            }else{
                if (lastItem == objetoActivarFinal&&Input.GetKeyDown(KeyCode.Y) && puedeIniciarDialogo){
                    EmpezarDialogo();
                    puedeIniciarDialogo = false;
                }
            }
        }
    }

    public void ActivarDialogoEnColision()
    {
        puedeIniciarDialogo = true;
    }

    public void DesactivarDialogoEnColision()
        {
            puedeIniciarDialogo = false;
        }

    public void EmpezarDialogo()
    {
        inicio = true;
        final.SetActive(true);
        palabra = obtenerPalabra();
        StartCoroutine(Linea());
    }

    private IEnumerator Linea()
    {
        texto.text = string.Empty;
        foreach (char ch in palabra)
        {
            texto.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f); 
        IniciarFinal();
    }

    private void IniciarFinal()
    {
        // Verifica si hay más textos en la cola para mostrar
        if (colaTextos.Count == 0)
        {
            final.SetActive(false);
            SceneManager.LoadScene(0);
        }
        else
        {
            // Obtiene el siguiente texto y comienza a mostrarlo
            palabra = obtenerPalabra();
            StartCoroutine(Linea());
        }
    }

    private string obtenerPalabra(){
        if(colaTextos.Count != 0){
            return colaTextos.Dequeue();
        }
        return "adios";
    }

}
