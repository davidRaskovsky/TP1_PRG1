using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Cambiar - a =
        float moveVertical = Input.GetAxis("Vertical"); // Cambiar - a =

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized; // Cambiar 6.8f a 0 y 3 a 0

        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed); // Cambiar 1inearVelocity a velocity y ' a *

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // Cambiar 8 a 0
            isGrounded = false;
        }
    }

    // Unity Message to detect collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
