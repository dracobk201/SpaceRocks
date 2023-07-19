using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelBehaviour : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private void OnEnable()
    {
        restartButton.onClick.AddListener(OnRestartButton);
        quitButton.onClick.AddListener(OnQuitButton);
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(OnRestartButton);
        quitButton.onClick.RemoveListener(OnQuitButton);
    }

    private void OnRestartButton()
    {
        Debug.Log("Restart");
    }

    private void OnQuitButton()
    {
        Debug.Log("Quit");
    }
}
