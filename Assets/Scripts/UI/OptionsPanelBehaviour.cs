using UnityEngine;
using UnityEngine.UI;

public class OptionsPanelBehaviour : BaseUI
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

    public void ChangeVolumenAlert()
    {
        uIController.SettingsChanged();
    }

    private void OnBackButton()
    {
        gameStatus.Status = GameStatus.InMenu;
        uIController.ShowHidePanel(UIPanel.MainMenu);
    }
}
