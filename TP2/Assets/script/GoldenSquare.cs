using UnityEngine;

public class GoldenSquare : MonoBehaviour
{
    public bool isGolden = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isGolden && other.CompareTag("Player"))
        {
            Debug.Log("ui");

            other.transform.position = new Vector3(6f, 0f, 0f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
