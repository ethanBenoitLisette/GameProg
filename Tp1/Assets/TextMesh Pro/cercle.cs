using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float speed = 40f;

    void Update()
    {
        // Déplacement vers le bas
        transform.Translate(Vector2.down * speed * Time.deltaTime * 2f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si la collision a lieu avec une autre entité (par exemple, le carré)
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ui");
            // Quitte le jeu
            GameController.Instance.QuitGame();
        }
    }
}