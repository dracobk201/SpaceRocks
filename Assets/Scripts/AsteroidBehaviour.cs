using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    private float movementSpeed;
    private float rotationSpeed;
    private float rotationOrientation;
    private Vector3 targetDirection;

    public void Setup(float asteroidMovementSpeed, float asteroidRotationSpeed, int asteroidOrientation, Vector3 givenDirection)
    {
        movementSpeed = asteroidMovementSpeed;
        rotationSpeed = asteroidRotationSpeed;
        targetDirection = givenDirection - transform.position;
        rotationOrientation = asteroidOrientation;
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
}
