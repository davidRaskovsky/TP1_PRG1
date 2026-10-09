using UnityEngine;

public class PickItem : MonoBehaviour
{
    [SerializeField] private Transform hand;

    private GameObject currentItem = null;
    private GameObject itemInRange = null; // Guarda el ítem que tienes cerca

    void Update()
    {
        // Si hay un ítem cerca, no tienes nada cargado, y presionas la E
        if (itemInRange != null && currentItem == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pick(itemInRange);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta cuando te acercas al cubo
        if (other.CompareTag("Item"))
        {
            itemInRange = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detecta cuando te alejas del cubo
        if (other.CompareTag("Item") && itemInRange == other.gameObject)
        {
            itemInRange = null;
        }
    }

    private void Pick(GameObject item)
    {
        currentItem = item;
        itemInRange = null; 

        // 1. Pegamos el ítem a la mano
        item.transform.SetParent(hand);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        // 2. Desactivamos la gravedad del Rigidbody
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null) 
        {
            rb.isKinematic = true; 
        }
        
        // 3. APAGAMOS LOS DOS COLLIDERS AL MISMO TIEMPO
        Collider[] todosLosColliders = item.GetComponents<Collider>();
        foreach (Collider col in todosLosColliders)
        {
            col.enabled = false; 
        }
    }

    public GameObject DropItem()
    {
        if (currentItem != null)
        {
            GameObject temp = currentItem;
            
            // 1. Separamos el objeto del jugador
            temp.transform.SetParent(null);
            
            // 2. Le devolvemos la gravedad al Rigidbody
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            if (rb != null) 
            {
                rb.isKinematic = false; 
                
                // CORRECCIÓN AQUÍ: Cambiamos rb.velocity por rb.linearVelocity para tu versión de Unity
                rb.linearVelocity = Vector3.zero; 
            }
            
            // 3. ENCENDEMOS LOS DOS COLLIDERS AL MISMO TIEMPO
            Collider[] todosLosColliders = temp.GetComponents<Collider>();
            foreach (Collider col in todosLosColliders)
            {
                col.enabled = true; 
            }
            
            currentItem = null; 
            return temp;
        }
        return null;
    }
}



/*




*/