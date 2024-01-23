using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    public float initialSpeed = 2f;
    public float accelerationRate = 20f;

    private float currentSpeed;
    public bool isGolden = true;
    public bool isBlack = true;

    void Start()
    {
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        currentSpeed += accelerationRate * Time.deltaTime;
    }
}