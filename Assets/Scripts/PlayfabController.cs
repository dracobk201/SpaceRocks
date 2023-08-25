using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabController : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;

    public void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void UpdateDisplayName()
    {
        string playfabUsername = PlayerPrefs.GetString("username", string.Empty);

        if (playfabUsername.Equals(string.Empty))
        {
            return;
        }

        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = playfabUsername
        }, result => 
        {
            Debug.Log("The player's display name is now: " + result.DisplayName);
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void SendLeaderboard(int pointsObtained)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "BestScore",
                    Value = pointsObtained
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnLeaderboardError);
    }

    public void GetLearderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "BestScore",
            StartPosition = 0,
            MaxResultsCount = 8
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnLeaderboardGetError);
    }

    #region Callbacks

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log($"{SystemInfo.deviceUniqueIdentifier} has been logged");
        UpdateDisplayName();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your login call.");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    private void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log($"Successful Leaderboard sent> {result.ToJson()}");
        GetLearderboard();
    }

    private void OnLeaderboardError(PlayFabError error)
    {
        Debug.LogError("Something went wrong with Leadearboard Update.");
        Debug.LogError(error.GenerateErrorReport());
    }

    private void OnLeaderboardGet(GetLeaderboardResult result)
    {
        gameStatus.currentLeaderboard = new List<string>();
        foreach (var currentPosition in result.Leaderboard)
        {
            gameStatus.currentLeaderboard.Add($"{currentPosition.Position + 1}. {currentPosition.DisplayName} - {currentPosition.StatValue:n0}");
        }
        Debug.Log($"Successful Leaderboard get");
    }

    private void OnLeaderboardGetError(PlayFabError error)
    {
        Debug.LogError("Something went wrong with Leadearboard Get.");
        Debug.LogError(error.GenerateErrorReport());
    }

    #endregion
}
