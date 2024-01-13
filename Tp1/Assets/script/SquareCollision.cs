using UnityEngine;
using UnityEngine.SceneManagement;

public class SquareCollision : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            SceneManager.LoadScene("menu");
        }
    }
}
