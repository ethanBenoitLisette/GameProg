using UnityEngine;
using UnityEngine.UI;

public class SquareSpawner : MonoBehaviour
{
    public GameObject squarePrefab;
    public GameObject goldenSquarePrefab;
    public GameObject blackSquarePrefab;
    public float initialSpawnRate = 1f;
    public float accelerationRate = 20f;
    public float timeBetweenAccelerations = 5f;
    public TMPro.TextMeshProUGUI scoreText;



    private float spawnRate;
    private float elapsedTime;
    private int score; 

    void Start()
    {
        spawnRate = initialSpawnRate;
        InvokeRepeating("SpawnSquare", 0f, 1f / spawnRate);

        score = 0;

        UpdateScoreText();
    }

void SpawnSquare()
{
    float randomY = Random.Range(-4f, 0f);
    Vector3 spawnPosition = new Vector3(12f, randomY, 0f);

    GameObject squareToSpawn;

    if (Random.value < 0.02f)
    {
        squareToSpawn = goldenSquarePrefab;
    }
    else if (Random.value < 0.02f)
    {
        squareToSpawn = blackSquarePrefab;  
    }
    else
    {
        squareToSpawn = squarePrefab;
    }

    GameObject newSquare = Instantiate(squareToSpawn, spawnPosition, Quaternion.identity);
    Destroy(newSquare, 5f);

    score += squareToSpawn.GetComponent<SquareMovement>().isGolden ? 1 : 1;
    UpdateScoreText();

    if (transform.position.x < -15f)
    {
        Destroy(gameObject);
    }
}


    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timeBetweenAccelerations)
        {
            spawnRate += accelerationRate;
            CancelInvoke("SpawnSquare");
            InvokeRepeating("SpawnSquare", 0f, 1f / spawnRate);
            elapsedTime = 0f;
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}