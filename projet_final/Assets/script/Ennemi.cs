using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    private bool miniGameActive;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (miniGameActive)
        {
            return;
        }

        Vector2 direction = player.position - transform.position;
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void Launch(int launchPower)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = (player.position - transform.position).normalized * launchPower;

        miniGameActive = true;
    }
    public void FreezeEnemy()
{
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    rb.velocity = Vector2.zero;
    rb.isKinematic = true;
}

}
