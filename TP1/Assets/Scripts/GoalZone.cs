 using UnityEngine;

public class GoalZone : MonoBehaviour
{

[SerializeField] private Transform goal;

private void OnTriggerEnter(Collider other)
// uso por para detectar si el jugador entra en la zona
{  
    if(other.CompareTag("Player"))
    {  
        PickItem pickItem = other.GetComponent<PickItem>();// aqui hago referencia al script PickItem para hacer pickItem.Drop89
        if(pickItem!=null)
            {                     
            GameObject item = pickItem.DropItem();
                if(item != null)   // verifico si el item no se nulo
                {      

                       //si lega a la meta => victoria
                 ItemInZone(item);
                 Debug.Log("NIVEL COMPLETADO");

                }
                else 
                    {  
                    Debug.Log("DERROTA - LLEGASTE SIN EL ITEM");
            }
        }
    }
}

private void ItemInZone(GameObject item)
{
item.transform.SetParent(goal);
item.transform.localPosition = goal.position;
item.transform.localRotation = goal.rotation;


Collider col = item.GetComponent<Collider>();
Rigidbody rb = item.GetComponent<Rigidbody>();

//verificadiones 
    if(col !=null) col.enabled = true;
    if(rb !=null) rb.isKinematic = true;

}
}

