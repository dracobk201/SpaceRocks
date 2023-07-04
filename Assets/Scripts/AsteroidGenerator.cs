using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    private Camera gameCamera;
    private float timer = 3f;
    private float actualTime;

    private void Awake()
    {
        gameCamera = Camera.main;
        actualTime = 0f;
    }

    private void Update()
    {
        actualTime += Time.deltaTime;
        if (actualTime > timer)
        {
            GenerateAsteroids(3);
            actualTime = 0f;
        }
    }

    private void GenerateAsteroids(int generationAmount = 1)
    {
        for (int i = 0; i < generationAmount; i++)
        {
            int randomIndex = Random.Range(0, asteroidPrefabs.Length);
            Vector3 randomPosition = GetRandomPosition();
            GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], randomPosition, Quaternion.identity, transform);
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 screenPosition = Vector3.zero;
        float margin = 20;
        
        if (Random.value > 0.5f)
        {
            screenPosition.y = Random.Range(-margin, Screen.height + margin);
            if (Random.value > 0.5f)
            {
                screenPosition.x = Screen.width + margin;
            }
            else
            {
                screenPosition.x = -margin;
            }
        }
        else
        {
            screenPosition.x = Random.Range(-margin, Screen.width + margin);
            if (Random.value > 0.5f)
            {
                screenPosition.y = Screen.height + margin;
            }
            else
            {
                screenPosition.y = -margin;
            }
        }
        screenPosition.z = gameCamera.farClipPlane / 2;
        Vector3 worldPosition = gameCamera.ScreenToWorldPoint(screenPosition);

        return worldPosition;
    }
}
