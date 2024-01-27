using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public float pauseDuration = 5f;
    public Renderer playerRenderer; 
    private Ennemi ennemiScript;
    private bool isGrounded;
    private Rigidbody2D rb;
    private bool isPlayerPaused = false;
    private float launchPower = 2f;
    public TextMeshProUGUI launchPowerText;


    void Start()
{
    rb = GetComponent<Rigidbody2D>();
    ennemiScript = GameObject.FindGameObjectWithTag("Ennemi")?.GetComponent<Ennemi>();

    if (ennemiScript == null)
    {
        Debug.LogError("EnnemiScript is null. Make sure the Ennemi object is tagged correctly.");
        
    }
}

    void Update()
    {
        if (!isPlayerPaused)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

            isGrounded = Physics2D.OverlapCircle(transform.position, 1f, groundLayer);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IncreaseLaunchPower();
            }
            if (Input.GetKeyDown(KeyCode.E) && launchPower > 2f)
            {
                ResumePlayer();
            }
            if (playerRenderer.material.color == Color.red)
            {
                SceneManager.LoadScene("menulose"); 
            }
        }
        UpdateLaunchPowerText(); 

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

public void PausePlayer(float duration)
{
    StopAllCoroutines();
    isPlayerPaused = true;
    StartCoroutine(ColorLerp(playerRenderer.material.color, Color.red, 2f));
    Invoke("ResumePlayer", duration);
    rb.velocity = Vector2.zero;
    rb.isKinematic = true;
    InvokeRepeating("IncreaseLaunchPower", 0f, 0.1f);
}

void ResumePlayer()
{
    StopAllCoroutines();
    rb.isKinematic = false;
    isPlayerPaused = false;
    CancelInvoke("IncreaseLaunchPower");
    LaunchEnemy(launchPower);
    launchPower = 2f;
    StartCoroutine(ColorToWhiteCoroutine());
}
    private IEnumerator ColorLerp(Color startColor, Color endColor, float duration)
{
    float elapsedTime = 0f;

    while (elapsedTime < duration)
    {
        playerRenderer.material.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    playerRenderer.material.color = endColor;
}

private IEnumerator ColorToWhiteCoroutine()
{
    float elapsedTime = 0f;
    Color startColor = playerRenderer.material.color;
    Color endColor = Color.white;  
    float duration = 2f;  

    while (elapsedTime < duration)
    {
        playerRenderer.material.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    playerRenderer.material.color = endColor;
}
    void IncreaseLaunchPower()
    {
        if (isPlayerPaused && Input.GetKeyDown(KeyCode.Space))
        {
            launchPower += 1f;
        }
    }

    void LaunchEnemy(float power)
    {
        ennemiScript.LaunchEnemy(power);
    }

    void LoseGame()
    {
        SceneManager.LoadScene("menu"); 
    }

    void UpdateLaunchPowerText()
    {
        if (launchPowerText != null)
        {
            launchPowerText.text = "Launch Power: " + launchPower.ToString("F0");
        }
    }
}

