using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoverPisoFalso : MonoBehaviour
{

    public int cuenta;
    [SerializeField] public int tamañoEsperado;

    void Update()
    {
        if (cuenta==tamañoEsperado){
            gameObject.SetActive(false); 
        }
    }
}
