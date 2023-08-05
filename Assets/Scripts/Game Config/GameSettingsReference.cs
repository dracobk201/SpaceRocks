using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "ScriptableObjects/Game Settings Data")]
public class GameSettingsReference : ScriptableObject
{
    public GameStatus Status;
    public int ActualLife;
    public int ActualPoints;
    public int AsteroidsDestroyed;
    public bool InCombo;
    public float PointsMultiplier;

    public void Restart()
    {
        Status = GameStatus.InMenu;
        ActualLife = 100;
        ActualPoints = 0;
        AsteroidsDestroyed = 0;
        InCombo = false;
        PointsMultiplier = 0;
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
}