using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    [SerializeField] private float movementSpeed;

    public void Moving(Vector2 movementAxis)
    {
        if (!gameStatus.Status.Equals(GameStatus.InGame))
        {
            return;
        }
        Vector2 movementWithRestrictions = CheckRestrictions(movementAxis);
        Vector3 restrictedMovement = Vector3.one;
        restrictedMovement.x *= movementWithRestrictions.x * movementSpeed;
        restrictedMovement.y *= movementWithRestrictions.y * movementSpeed;

        transform.position += restrictedMovement * Time.deltaTime;
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

    private Vector2 CheckRestrictions(Vector2 value)
    {
        if (gameStatus.leftLock && value.x < 0)
        {
            value.x = 0;
        }
        if (gameStatus.rightLock && value.x > 0)
        {
            value.x = 0;
        }
        if (gameStatus.upLock && value.y > 0)
        {
            value.y = 0;
        }
        if (gameStatus.downLock && value.y < 0)
        {
            value.y = 0;
        }
        return value;
    }
}
