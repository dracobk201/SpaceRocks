using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public event System.Action AsteroidHit;
    public event System.Action PlayerHit;
    [SerializeField] private GameSettingsReference gameStatus;
    [SerializeField] private GameObject[] asteroidPrefabs;
    private Camera gameCamera;
    private readonly float timer = 3f;
    private float actualTime;
    public float timeSpeedFactor;

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

        actualTime += Time.deltaTime * timeSpeedFactor;
        if (actualTime > timer)
        {
            int amount = (int)timeSpeedFactor * 3;
            GenerateAsteroids(amount);
            actualTime = 0f;
        }
        CheckTime();
    }

    private void CheckTime()
    {
        timeSpeedFactor = gameStatus.GetTimeStep();
    }

    private void GenerateAsteroids(int generationAmount = 1)
    {
        //TODO: Make this with a Object Pool and swappable sprites
        for (int i = 0; i < generationAmount; i++)
        {
            int randomIndex = Random.Range(0, asteroidPrefabs.Length);
            Vector3 randomPosition = GetRandomPositionOutsideScreen();
            GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], randomPosition, Quaternion.identity, transform);
            asteroid.name = $"{asteroidPrefabs[randomIndex].name} {i}";

            AsteroidData asteroidInfo = new AsteroidData();
            asteroidInfo.AsteroidLifespan = 10f;
            asteroidInfo.AsteroidMovementSpeed = Random.Range(0.00001f, 0.5f);
            asteroidInfo.AsteroidRotationSpeed = Random.Range(3f, 50f);
            asteroidInfo.GivenDirection = GetRandomPositionInsideScreen();

            int asteroidRotationOrientation;
            if (Random.value > 0.5f)
            {
                asteroidRotationOrientation = 1;
            }
            else
            {
                asteroidRotationOrientation = -1;
            }
            asteroidInfo.AsteroidOrientation = asteroidRotationOrientation;
            
            asteroid.GetComponent<AsteroidBehaviour>().Setup(this, asteroidInfo);
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

    public void AsteroidDestroyed()
    {
        AsteroidHit.Invoke();
    }

    public void PlayerCollission()
    {
        PlayerHit.Invoke();
    }
}
