using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameStatusReference gameStatus;
    [SerializeField] private float movementSpeed;

    public void Moving(Vector2 movementAxis)
    {
        if (!gameStatus.Status.Equals(GameStatus.InGame))
        {
            return;
        }
        Vector3 movement = movementAxis * movementSpeed;
        transform.position += movement * Time.deltaTime;
    }

    public void Aiming(Vector2 mousePosition)
    {
        if (!gameStatus.Status.Equals(GameStatus.InGame))
        {
            return;
        }
        Vector3 targetDirection = (Vector3)mousePosition - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
