using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isPaused = false;
    public static GameController Instance;

    public GameObject prefabToSpawn;
    public float spawnRate = 1f;

    private float screenWidth;
    private float screenHeight;

    void SpawnPrefab()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject newPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        Destroy(newPrefab, 10f);
    }

Vector3 GetRandomSpawnPosition()
{
    int sideIndex = Random.Range(0, 4);
    float x = 0f;
    float y = 0f;

    switch (sideIndex)
    {
        case 0:
            x = -screenWidth * 0.5f / 25 ;
            y = Random.Range(-screenHeight * 0.5f , screenHeight * 0.5f )/ 25 ;
            break ;
        case 1:
            x = screenWidth * 0.5f / 25 ;
            y = Random.Range(-screenHeight * 0.5f , screenHeight * 0.5f )/ 25 ;
            break;
        case 2:
            x = Random.Range(-screenWidth * 0.5f , screenWidth * 0.5f )/ 25 ;
            y = screenHeight * 0.5f / 25 ;
            break ;
        case 3:
            x = Random.Range(-screenWidth * 0.5f, screenWidth * 0.5f )/ 25 ;
            y = -screenHeight * 0.5f / 25 ;
            break;
    }

    return new Vector3(x, y, 0f);
}


    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        InvokeRepeating("SpawnPrefab", 0f, spawnRate);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
        }
    }

    void Awake()
    {
        // Assure-toi qu'il n'y a qu'une seule instance du GameController
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void QuitGame()
    {
        // Ajoute d'autres actions de quitter le jeu si nécessaire
        Debug.Log("Quitting the game");
        Application.Quit();
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
        }
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
