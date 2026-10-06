using UnityEngine;

public class LinearMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
private Rigidbody rg;
//private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rg= GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
     rg.linearVelocity = new Vector3(1f*speed,rg.linearVelocity.y, rg.linearVelocity.z);
    }
}
