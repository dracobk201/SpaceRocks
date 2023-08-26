using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "ScriptableObjects/Game Settings Data")]
public class GameSettingsReference : ScriptableObject
{
    [Header("Base")]
    public float MaxTime;
    public int MaxLife;
    public float MaxMultiplier;

    [Header("Updatable Variables")]
    public GameStatus Status;
    public float ActualTime;
    public int ActualLife;
    public int ActualPoints;
    public int AsteroidsDestroyed;
    public bool InCombo;
    public float PointsMultiplier;
    
    public List<string> currentLeaderboard;

    public bool upLock;
    public bool downLock;
    public bool rightLock;
    public bool leftLock;

    public void Restart()
    {
        Status = GameStatus.InMenu;
        ActualTime = MaxTime;
        ActualLife = MaxLife;
        ActualPoints = 0;
        AsteroidsDestroyed = 0;
        InCombo = false;
        PointsMultiplier = 0;
        upLock = false;
        downLock = false;
        rightLock = false;
        leftLock = false;
    }

    public void CutCombo()
    {
        InCombo = false;
        PointsMultiplier = 0f;
    }

    public void UpdateLife(int damage)
    {
        ActualLife -= damage;
    }

    public void UpdatePoints(int points)
    {
        var combo = (InCombo) ? 1 : 0;
        float comboPoints = points * PointsMultiplier * combo;
        int pointsToAdd = points + (int)comboPoints;
        ActualPoints += pointsToAdd;
    }

    public void UpdateAsteroidCounter()
    {
        AsteroidsDestroyed++;
        InCombo = true;
        PointsMultiplier = (float) AsteroidsDestroyed / 100;
    }

    public float GetTimeStep()
    {
        var step = ActualTime / MaxTime;
        return Mathf.Lerp(MaxMultiplier, 1, step);
    }
}
