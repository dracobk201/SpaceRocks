using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanelBehaviour : BaseUI
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private TMP_InputField nameInputfield;

    private void Start()
    {
        nameInputfield.text = PlayerPrefs.GetString("username");
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(OnPlayButton);
        optionsButton.onClick.AddListener(OnOptionsButton);
        creditsButton.onClick.AddListener(OnCreditsButton);
        nameInputfield.onValueChanged.AddListener(OnNameChange);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(OnPlayButton);
        optionsButton.onClick.RemoveListener(OnOptionsButton);
        creditsButton.onClick.RemoveListener(OnCreditsButton);
        nameInputfield.onValueChanged.AddListener(OnNameChange);
    }

    private void OnPlayButton()
    {
        if (nameInputfield.text.Equals(string.Empty))
        {
            return;
        }
        uIController.BeginGame();
        gameStatus.Status = GameStatus.InGame;
        uIController.ShowHidePanel(UIPanel.GameOverlay);

    }

    private void OnOptionsButton()
    {
        uIController.ShowHidePanel(UIPanel.Options);
    }

    private void OnCreditsButton()
    {
        uIController.ShowHidePanel(UIPanel.Credits);
    }

    private void OnNameChange(string value)
    {
        PlayerPrefs.SetString("username", nameInputfield.text);
    }
}
