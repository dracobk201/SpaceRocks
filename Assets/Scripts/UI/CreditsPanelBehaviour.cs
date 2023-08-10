using UnityEngine;
using UnityEngine.UI;

public class CreditsPanelBehaviour : BaseUI
{
    [SerializeField] private Button backButton;

    private void OnEnable()
    {
        backButton.onClick.AddListener(OnBackButton);
    }

    private void OnDisable()
    {
        backButton.onClick.RemoveListener(OnBackButton);
    }

    private void OnBackButton()
    {
        gameStatus.Status = GameStatus.InMenu;
        uIController.ShowHidePanel(UIPanel.MainMenu);
    }
}
