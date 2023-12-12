using UnityEngine;

public class DarObjetosOrdenados : MonoBehaviour
{
    [SerializeField] public string[] objetosEsperados; 
    private int indiceActual = 0;
    public Inventario inventory;
    public RemoverPisoFalso remover;
    private bool isPlayerInRange;
    [SerializeField] private GameObject correcto;
    [SerializeField] private GameObject incorrecto;
    [SerializeField] private GameObject completado;
    public float duracionVisible = 1f; 


    public void RecibirObjeto()
    {
        if (inventory.ShowItem() == objetosEsperados[indiceActual])
        {
            MostrarCarita(correcto);
            inventory.RemoveItem();
            if (indiceActual < objetosEsperados.Length - 1)
            {
                indiceActual++;
            }
            else
            {
                remover.cuenta++;
                completado.SetActive(true);
            }
        }
        else
        {
            MostrarCarita(incorrecto);
            Debug.Log("Objeto incorrecto. Este NPC espera otro objeto.");
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Y))
        {
            RecibirObjeto();
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

     private void MostrarCarita(GameObject carita)
    {
        if (carita != null)
        {
            carita.SetActive(true);
            Invoke("OcultarCarita", duracionVisible);
        }
    }

    private void OcultarCarita()
    {
        if (correcto != null)
        {
            correcto.SetActive(false);
        }
        if (incorrecto != null)
        {
            incorrecto.SetActive(false);
        }
    }

}
