using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public float miniGameDuration = 5f;
    private float miniGameTimer;
    private bool miniGameActive;
    private int playerScore;
    private Rigidbody2D playerRb;
    private Ennemi ennemiScript;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        ennemiScript = GetComponent<Ennemi>();
    }

    public void StartMiniGame()
    {
        miniGameTimer = miniGameDuration;
        miniGameActive = true;
        playerScore = 0;
    }

    void Update()
    {
        if (miniGameActive)
        {
            miniGameTimer -= Time.deltaTime;
            Debug.Log("MiniGame");

            playerRb.velocity = Vector2.zero;
            ennemiScript.FreezeEnemy();

            if (miniGameTimer <= 0f)
            {
                miniGameActive = false;

                ennemiScript.Launch(playerScore);
            }
        }
    }

    void LaunchEnemy(int launchPower)
    {
        // Implémente la logique pour lancer l'ennemi avec la puissance donnée
    }
}
