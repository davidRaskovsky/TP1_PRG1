using UnityEngine;

public class PickItem : MonoBehaviour
{
    
  [SerializeField] private Transform hand;
    private GameObject currentItem = null;
  //  private GameObject itemInRange = null; // Guarda el ítem que tienes cerca


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
            

        
    }




/*




*/