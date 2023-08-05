using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverlayPanelBehaviour : BaseUI
{
    [SerializeField] private TMP_Text currentPointsText;
    [SerializeField] private TMP_Text currentLifeText;
    [SerializeField] private TMP_Text remainingTimeText;
    [SerializeField] private Button pauseButton;

    private void OnEnable()
    {
        pauseButton.onClick.AddListener(OnPauseButton);
    }

    private void OnDisable()
    {
        pauseButton.onClick.RemoveListener(OnPauseButton);
    }

    private void Update()
    {
        currentLifeText.text = gameStatus.ActualLife.ToString();
        currentPointsText.text = $"{gameStatus.ActualPoints:n0}";

        int seconds = (int)gameStatus.ActualTime % 60;
        int minutes = (int)gameStatus.ActualTime / 60;
        remainingTimeText.text = $"{minutes}:{seconds}";
    }

    private void OnPauseButton()
    {
        Debug.Log("Pause");
        gameStatus.Status = GameStatus.InPause;
    }
}
