using System;
using System.Collections;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    private float lifespan;
    private float movementSpeed;
    private float rotationSpeed;
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
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 movement = movementSpeed * Time.deltaTime * targetDirection;
        transform.position += movement;
    }

    private void Rotate()
    {
        Vector3 newRotation = new Vector3(0, 0, rotationSpeed * Time.deltaTime * rotationOrientation);
        transform.Rotate(newRotation);
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
            gameObject.SetActive(false);
        }
    }
}
