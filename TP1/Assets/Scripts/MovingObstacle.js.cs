using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 2f;            // Velocidad de movimiento
    public float moveDistance = 5f;     // Distancia que se moverá el obstáculo
    public bool moveVertically = false;  // Cambia a true si quieres que se mueva verticalmente

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial
    }

    void Update()
    {
        float newPosition = Mathf.PingPong(Time.time * speed, moveDistance);
        
        if (moveVertically)
        {
            // Movimiento vertical
            transform.position = startPosition + new Vector3(0, newPosition, 0);
        }
        else
        {
            // Movimiento horizontal
            transform.position = startPosition + new Vector3(newPosition, 0, 0);
        }
    }
}
