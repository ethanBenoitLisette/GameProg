using UnityEngine;

public class CircleSpawnAndDestroy : MonoBehaviour
{
    public GameObject circlePrefab;
    public float spawnInterval = 1f;
    public float circleSpeed = 5f;

    void Start()
    {
        InvokeRepeating("SpawnCircle", 0f, spawnInterval);
    }

void SpawnCircle()
{
    if (circlePrefab != null)
    {

        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
        GameObject newCircle = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);

        // Vérifier si le composant Rigidbody2D est attaché avant d'accéder à velocity
        Rigidbody2D rb = newCircle.GetComponent<Rigidbody2D>();
        Debug.Log(rb);
        if (rb != null)
        {
            rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * circleSpeed;
        }
        else
        {
            Debug.LogError("Le Rigidbody2D n'est pas attaché à l'objet préfabriqué.");
        }
    }
    else
    {
        Debug.LogError("Le prefab de cercle n'est pas assigné dans l'inspecteur.");
    }
}


    void Update()
    { 
        while (true)
        { 
        GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
        foreach (var circle in circles)
        {
            if (circle != null && !IsObjectVisible(circle))
            {
                Destroy(circle);
            }
        }
    }

    bool IsObjectVisible(GameObject obj)
    {
        if (obj == null)
        {
            return false;
        }

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(obj.transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }
}
