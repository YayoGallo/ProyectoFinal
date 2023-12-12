using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartelInventario : MonoBehaviour
{
    [SerializeField] private TMP_Text texto;
    public Inventario inventory;
    public string objeto;

    void Update()
    {
        objeto= inventory.ShowItem();
        texto.text=objeto;
    }
}
