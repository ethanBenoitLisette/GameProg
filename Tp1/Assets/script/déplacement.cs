using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);
    }
}
