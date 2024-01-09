using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Déplacement horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Déplacement vertical
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);
    }
}
