using UnityEngine;

public class PickItem : MonoBehaviour
{
    
  [SerializeField] private Transform hand;
    private GameObject currentItem = null;
  //  private GameObject itemInRange = null; // Guarda el ítem que tienes cerca


  //  void Update()
  //  {
        // Si hay un ítem cerca, no tienes nada cargado, y presionas la E
    //    if (itemInRange != null && currentItem == null)
  //     {
 //           if (Input.GetKeyDown(KeyCode.E))
  //          {
 //               Pick(itemInRange);
 //           }
 //       }
 //   }

   // private void OnTriggerEnter(Collider other)
    private void OnTriggerStay(Collider other)
    {
        // Detecta cuando te acercas al cubo
        if (other.CompareTag("Item")&& currentItem == null)
        {
// CAPTURA EL OBJETO
    

         //   itemInRange = other.gameObject;
         if(Input.GetKeyDown(KeyCode.E))
            
              Pick(other.gameObject);
            
        }
    }
 
   

    private void Pick(GameObject item)
    {
    //    currentItem = item;
      //  itemInRange = null; 
    currentItem = item;
        // 1. Pegamos el ítem a la mano
        item.transform.SetParent(hand); // si no esta da error de null refernce 
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
  // VERIFICACION PARA EVITAR CONFLICTOS CON EL JUGADOR
       Rigidbody rb = item.GetComponent<Rigidbody>();
        
        Collider collider = item.GetComponent<Collider>();
        
       if (rb != null)   rb.isKinematic = false;
       if(collider != null) collider.enabled = false;
    }
        
     public GameObject DropItem()
    {
        GameObject temp = currentItem;
            currentItem = null;
            return temp; 
    
    }
            // 1. Separamos el objeto del jugador
         //   temp.transform.SetParent(null);
            
            // 2. Le devolvemos la gravedad al Rigidbody
          //  Rigidbody rb = temp.GetComponent<Rigidbody>();
           // if (rb != null) 
           // { rb.isKinematic = false;                 
                // CORRECCIÓN AQUÍ: Cambiamos rb.velocity por rb.linearVelocity para tu versión de Unity
          //      rb.linearVelocity = Vector3.zero; 
           // }
            
            // 3. ENCENDEMOS LOS DOS COLLIDERS AL MISMO TIEMPO
          
          /*
            Collider[] todosLosColliders = temp.GetComponents<Collider>();
            foreach (Collider col in todosLosColliders)
            {
                col.enabled = true; 
            }
            
            currentItem = null; 
            return temp;
        }
*/

        
    }




/*




*/