using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float movementRange = 5f; 
    public float movementSpeed = 2f; 

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float horizontalMovement = Mathf.PingPong(Time.time * movementSpeed, movementRange * 2) - movementRange;

        transform.position = new Vector3(initialPosition.x + horizontalMovement, transform.position.y, transform.position.z);
    }
}
