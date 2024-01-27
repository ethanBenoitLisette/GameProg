using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ennemi : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 500f;
    private float HitStun = 2f;
    private float currentPauseDuration = 4f;

    private Transform player;
    private bool isPlayerPaused = false;
    private Rigidbody2D rb;
    private Collider2D ennemiCollider;
    public float scoreDistance = 10f;
    public int scoreValue = 10;
    private ScoreManager scoreManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        ennemiCollider = GetComponent<Collider2D>();
        scoreManager = GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (!isPlayerPaused)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (IsOutsideScreen())
            {
                Destroy(gameObject);
                SceneManager.LoadScene("menuwin"); 
                if (scoreManager != null)
                {
                    scoreManager.IncreaseScoreFromEnemyExit();
                }
            }
        }
    }

    bool IsOutsideScreen()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        return screenPos.x < -5 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        currentPauseDuration = 2f;
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.PausePlayer(currentPauseDuration);
                PauseEnnemi(HitStun);
            }
        }
    }

    void PauseEnnemi(float duration)
    {
        isPlayerPaused = true;
        Invoke("ResumeEnnemi", duration);
        ennemiCollider.enabled = false;
        StartCoroutine(EnableColliderAfterDuration(1.5f));
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }

    void ResumeEnnemi()
    {
        isPlayerPaused = false;
        rb.isKinematic = false;
    }

    IEnumerator EnableColliderAfterDuration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ennemiCollider.enabled = true;
    }

    public void LaunchEnemy(float launchPower)
    {
        rb.velocity = (transform.position - player.position).normalized * launchPower;
        launchPower = 2f;
    }

    public void ChangePauseDuration(float newDuration)
    {
        currentPauseDuration = newDuration;
    }
}
