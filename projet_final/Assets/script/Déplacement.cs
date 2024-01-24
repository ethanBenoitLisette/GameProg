using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public float jumpForce = 15f;
    public LayerMask groundLayer ;
    private Rigidbody2D rb;
    private bool isGrounded;
    public float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    float horizontalInput = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

    isGrounded = Physics2D.OverlapCircle(transform.position, 1f, groundLayer);

    
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

        void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ennemi"))
        {
            MiniGameController miniGameController = other.gameObject.GetComponent<MiniGameController>();
            if (miniGameController != null)
            {
                Debug.Log("ui");
                miniGameController.StartMiniGame();
            }
        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
