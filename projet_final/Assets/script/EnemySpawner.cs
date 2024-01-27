using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);
        float randomY = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y, Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);

        return new Vector3(randomX, randomY, 0f);
    }
}
