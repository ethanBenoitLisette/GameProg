using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{
    public delegate void PlatformSpawnedEventHandler(GameObject platform);
    public static event PlatformSpawnedEventHandler OnPlatformSpawned;

    public GameObject platformPrefab;
    public float spawnInterval = 2f;
    public float minY = 1f;
    public float maxY = 5f;
    public float destroyTime = 3f;

    private void Start()
    {
        InvokeRepeating("SpawnPlatform", 0f, spawnInterval);
    }

    void SpawnPlatform()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(-5f, randomY, transform.position.z);

        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

        if (OnPlatformSpawned != null)
        {
            OnPlatformSpawned(platform);
        }

        StartCoroutine(DestroyPlatformAfterDelay(platform, destroyTime));
    }

    IEnumerator DestroyPlatformAfterDelay(GameObject platform, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (platform != null)
        {
            Destroy(platform);
        }
    }
}
