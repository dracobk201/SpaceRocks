using System.Collections;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    [SerializeField] private int damageToGive;
    [SerializeField] private int pointsToGive;
    private AsteroidGenerator asteroidGenerator;
    private AsteroidData asteroidData;
    public float timeSpeedFactor;

    public void Setup(AsteroidGenerator generator, AsteroidData data)
    {
        asteroidData = new AsteroidData();
        asteroidGenerator = generator;
        asteroidData.AsteroidLifespan = data.AsteroidLifespan;
        asteroidData.AsteroidMovementSpeed = data.AsteroidMovementSpeed;
        asteroidData.AsteroidRotationSpeed = data.AsteroidRotationSpeed;
        asteroidData.GivenDirection = data.GivenDirection - transform.position;
        asteroidData.AsteroidOrientation = data.AsteroidOrientation;

        StopCoroutine(SelfDestroyAsteroid());
        StartCoroutine(SelfDestroyAsteroid());
    }

    private void Update()
    {
        if (!gameStatus.Status.Equals(GameStatus.InGame))
        {
            return;
        }
        Move();
        Rotate();
        CheckTime();
    }

    private void Move()
    {
        Vector3 movement = asteroidData.AsteroidMovementSpeed * Time.deltaTime * asteroidData.GivenDirection * timeSpeedFactor;
        transform.position += movement;
    }

    private void Rotate()
    {
        Vector3 newRotation = new Vector3(0, 0, asteroidData.AsteroidRotationSpeed * Time.deltaTime * asteroidData.AsteroidOrientation * timeSpeedFactor);
        transform.Rotate(newRotation);
    }

    private void CheckTime()
    {
        timeSpeedFactor = gameStatus.GetTimeStep();
    }

    private IEnumerator SelfDestroyAsteroid()
    {
        yield return new WaitForSeconds(asteroidData.AsteroidLifespan);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("ProjectilePlayer"))
        {
            gameStatus.UpdateAsteroidCounter();
            gameStatus.UpdatePoints(pointsToGive);
            asteroidGenerator.AsteroidDestroyed();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            gameStatus.UpdateLife(damageToGive);
            asteroidGenerator.PlayerCollission();
        }
        
        gameObject.SetActive(false);
    }
}
