using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float fallThreshold = -10f; 

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            SceneManager.LoadScene("menu");
        }
    }
}