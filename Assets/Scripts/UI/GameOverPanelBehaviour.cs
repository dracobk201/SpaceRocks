using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelBehaviour : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_Text resultsText;
    private bool setupDone;

    private void Awake()
    {
        setupDone = false;
    }

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

    private void Update()
    {
        //TODO: Fix this awful validation
        if (gameStatus.Status.Equals(GameStatus.GameOver) && !setupDone)
        {
            ShowResults();
            setupDone = true;
        }
    }

    private void ShowResults()
    {
        resultsText.text = $"Points: {gameStatus.ActualPoints:n0}";
    }

    private void OnQuitButton()
    {
        Debug.Log("Quit");
        gameStatus.Status = GameStatus.InMenu;
        SceneManager.LoadScene(0);
    }
}
