using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanelBehaviour : BaseUI
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button creditsButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(OnPlayButton);
        optionsButton.onClick.AddListener(OnOptionsButton);
        creditsButton.onClick.AddListener(OnCreditsButton);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(OnPlayButton);
        optionsButton.onClick.RemoveListener(OnOptionsButton);
        creditsButton.onClick.RemoveListener(OnCreditsButton);
    }

    private void OnPlayButton()
    {
        Debug.Log("Play");
        gameStatus.Status = GameStatus.InGame;
        uIController.ShowHidePanel(UIPanel.GameOverlay);
    }

    private void OnOptionsButton()
    {
        Debug.Log("Options");
        uIController.ShowHidePanel(UIPanel.Options);
    }

    private void OnCreditsButton()
    {
        Debug.Log("Credits");
        uIController.ShowHidePanel(UIPanel.Credits);
    }
}
