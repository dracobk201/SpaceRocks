using System;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public event Action OnTimeEnded;
    [SerializeField] private GameSettingsReference gameStatus;

    private void Update()
    {
        if (gameStatus.Status.Equals(GameStatus.InGame))
        {
            gameStatus.ActualTime -= Time.deltaTime;
            if (gameStatus.ActualTime <= 0)
            {
                OnTimeEnded.Invoke();
            }
        }
    }
}
