 using UnityEngine;

public class GoalZone : MonoBehaviour
{

[SerializeField] private Transform goal;
private GameObject currentItem;

private void OnTriggerEnter(Collider other)
// uso por para detectar si el jugador entra en la zona
{  
    if(other.CompareTag("Player"))
    {  
        PickItem pickItem = other.GetComponent<PickItem>();// aqui hago referencia al script PickItem para hacer pickItem.Drop89
        if(pickItem!=null)
            {  
        // GameObject item = DropItem(); // Llama a tu función actual                           
            GameObject item = pickItem.DropItem();
                if(item != null)   // verifico si el item no se nulo
                {      
                       //si llega a la meta => victoria
                
                // Debug.Log("PERDISTE - LLEGASTE SIN EL ITEM");
                 Debug.Log("GANASTE - NIVEL COMPLETADO");
                ItemInZone(item);
                } 
                else 
                    { 
                         // Debug.Log("GANASTE - NIVEL COMPLETADO"); 
                    Debug.Log("PERDISTE - LLEGASTE SIN EL ITEM");
            }
        }
    }
}

private void ItemInZone(GameObject item)
{

 // Cambia el padre a la meta
    item.transform.SetParent(goal);  
    // POSICIÓN CORRECTA: Se acomoda exactamente donde está la meta
 //   item.transform.localPosition = goalPosition; // Asegura que el objeto esté en la posición local de la meta
  //item.transform.localPosition = Vector3.zero;
  //item.transform.localRotation = Quaternion.identity;
   item.transform.localPosition = goal.position;
   // item.transform.localRotation = goal.rotation;

    Collider col = item.GetComponent<Collider>();
    Rigidbody rb = item.GetComponent<Rigidbody>();

    if(col != null)  {  col.enabled = true;}
   // if(rb != null) rb.isKinematic = true; 
    if (rb != null)  { rb.isKinematic = true;} 
     //   rb.linearVelocity = Vector3.zero; // Frenamos cualquier movimiento heredado
}
}
// --------------------------------------  */
//item.transform.SetParent(goal);
//item.transform.localPosition = goal.position;
//item.transform.localRotation = goal.rotation;


//Collider col = item.GetComponent<Collider>();
//Rigidbody rb = item.GetComponent<Rigidbody>();

//verificadiones 
  //  if(col !=null) col.enabled = true;
  //  if(rb !=null) rb.isKinematic = true;
//----------------------------------------//
//private void ItemInZone(GameObject item)
//{
    // 1. Asignamos el nuevo padre (la meta)
 //   item.transform.SetParent(goal);
    
    // CORRECCIÓN: Usar posiciones globales del mundo para que coincida exactamente con la meta
 //   item.transform.position = goal.position;
 //   item.transform.rotation = goal.rotation;

 //   Collider col = item.GetComponent<Collider>();
 //   Rigidbody rb = item.GetComponent<Rigidbody>();

    // Verificaciones 
 //   if (col != null) col.enabled = true;
  //  if (rb != null) rb.isKinematic = true; // Está bien que sea kinematic para que no se caiga de la meta
// -------------------------------------------------//

//}
//}
//}

