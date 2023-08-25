using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelBehaviour : BaseUI
{
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_Text playerResultsText;
    [SerializeField] private TMP_Text rankingResultsText;
    private bool setupDone;

    private void Awake()
    {
        setupDone = false;
    }

    private void OnEnable()
    {
        quitButton.onClick.AddListener(OnQuitButton);
    }

    private void OnDisable()
    {
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
        playerResultsText.text = $"Points: {gameStatus.ActualPoints:n0}";
        rankingResultsText.text = string.Empty;

        foreach (var leadeboardResult in gameStatus.currentLeaderboard)
        {
            rankingResultsText.text += $"{leadeboardResult}\n";
        }
    }

    private void OnQuitButton()
    {
        Debug.Log("Quit");
        gameStatus.Status = GameStatus.InMenu;
        SceneManager.LoadScene(0);
    }
}
