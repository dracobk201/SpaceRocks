using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private GameStatusReference gameStatus;
    [SerializeField] private GameObject[] asteroidPrefabs;
    private Camera gameCamera;
    private readonly float timer = 3f;
    private float actualTime;

    private void Awake()
    {
        gameCamera = Camera.main;
        actualTime = 0f;
    }

    private void Update()
    {
        if (!gameStatus.Status.Equals(GameStatus.InGame))
        {
            return;
        }

        actualTime += Time.deltaTime;
        if (actualTime > timer)
        {
            GenerateAsteroids(3);
            actualTime = 0f;
        }
    }

    private void GenerateAsteroids(int generationAmount = 1)
    {
        //TODO: Make this with a Object Pool and swappable sprites
        for (int i = 0; i < generationAmount; i++)
        {
            int randomIndex = Random.Range(0, asteroidPrefabs.Length);
            Vector3 randomPosition = GetRandomPositionOutsideScreen();
            GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], randomPosition, Quaternion.identity, transform);

            float asteroidMovementSpeed = Random.Range(0.00001f, 0.5f);
            float asteroidRotationSpeed = Random.Range(3f, 50f);
            int asteroidRotationOrientation;
            if (Random.value > 0.5f)
            {
                asteroidRotationOrientation = 1;
            }
            else
            {
                asteroidRotationOrientation = -1;
            }

            asteroid.GetComponent<AsteroidBehaviour>().Setup(10f,asteroidMovementSpeed, asteroidRotationSpeed, asteroidRotationOrientation, GetRandomPositionInsideScreen());
        }
    }

    private Vector3 GetRandomPositionOutsideScreen()
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

    private Vector3 GetRandomPositionInsideScreen()
    {
        Vector3 screenPosition = Vector3.zero;

        screenPosition.y = Random.Range(0, Screen.height);
        screenPosition.x = Random.Range(0, Screen.width);
        screenPosition.z = gameCamera.farClipPlane / 2;
        Vector3 worldPosition = gameCamera.ScreenToWorldPoint(screenPosition);

        return worldPosition;
    }
}
