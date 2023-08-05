using System.Collections;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    [SerializeField] private int damageToGive;
    [SerializeField] private int pointsToGive;
    private float lifespan;
    private float movementSpeed;
    private float rotationSpeed;
    public float timeSpeedFactor;
    private float rotationOrientation;
    private Vector3 targetDirection;

    public void Setup(float asteroidLifespan, float asteroidMovementSpeed, float asteroidRotationSpeed, int asteroidOrientation, Vector3 givenDirection)
    {
        lifespan = asteroidLifespan;
        movementSpeed = asteroidMovementSpeed;
        rotationSpeed = asteroidRotationSpeed;
        targetDirection = givenDirection - transform.position;
        rotationOrientation = asteroidOrientation;

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
        Vector3 movement = movementSpeed * Time.deltaTime * targetDirection * timeSpeedFactor;
        transform.position += movement;
    }

    private void Rotate()
    {
        Vector3 newRotation = new Vector3(0, 0, rotationSpeed * Time.deltaTime * rotationOrientation * timeSpeedFactor);
        transform.Rotate(newRotation);
    }

    private void CheckTime()
    {
        timeSpeedFactor = gameStatus.GetTimeStep();
    }

    private IEnumerator SelfDestroyAsteroid()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("ProjectilePlayer"))
        {
            gameStatus.UpdateAsteroidCounter();
            gameStatus.UpdatePoints(pointsToGive);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            gameStatus.UpdateLife(damageToGive);
        }

        gameObject.SetActive(false);
    }
}
