using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float movementRange = 5f; // La distance totale que la plateforme parcourt
    public float movementSpeed = 2f; // La vitesse du mouvement

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float horizontalMovement = Mathf.PingPong(Time.time * movementSpeed, movementRange * 2) - movementRange;

        // Mettez à jour la position de la plateforme
        transform.position = new Vector3(initialPosition.x + horizontalMovement, transform.position.y, transform.position.z);
    }
}
