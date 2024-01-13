using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab;
    public float spawnRate = 1f;

    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController not found!");
        }

        InvokeRepeating("SpawnCircleUp", 0f, 1f / spawnRate);
    }

    void SpawnCircleUp()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 10f, 0f);
        GameObject newCircle = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
        Destroy(newCircle, 5f);
    }
    void SpawnCircleDown()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), -5f, 0f);
        GameObject newCircle = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
        Destroy(newCircle, 5f);
    }
}
