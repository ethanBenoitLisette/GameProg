using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBlock : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(-8f, 0f, 0f);
        }
    }
}
