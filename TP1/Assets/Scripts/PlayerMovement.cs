                                                                                                                                                                                                                                                                                                                                                                                                                                                    using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody rb;
    private bool isGrounded;
    private PickItem pickItemScript; // Guardamos una referencia al script de agarrar

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Buscamos automáticamente el script PickItem dentro del mismo Player
        pickItemScript = GetComponent<PickItem>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        
        // Usamos rb.velocity para máxima compatibilidad entre versiones de Unity
        rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);
        
        // Sistema de Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // Impulse le da un salto más reactivo
            isGrounded = false;
        }

        // NUEVO: Sistema para soltar el ítem con la tecla G
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (pickItemScript != null)
            {
                pickItemScript.DropItem();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detecta que tocamos el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
