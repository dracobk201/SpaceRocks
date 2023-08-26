using UnityEngine;

public class BorderBehaviour : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    [SerializeField] private BorderDirection borderDirection;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LockUnlockDirection(borderDirection, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LockUnlockDirection(borderDirection, false);
        }
    }

    private void LockUnlockDirection(BorderDirection borderSide, bool enterToLock)
    {
        switch (borderSide)
        {
            case BorderDirection.Left:
                gameStatus.leftLock = enterToLock;
                break;
            case BorderDirection.Right:
                gameStatus.rightLock = enterToLock;
                break;
            case BorderDirection.Up:
                gameStatus.upLock = enterToLock;
                break;
            case BorderDirection.Down:
                gameStatus.downLock = enterToLock;
                break;
        }
    }
}
