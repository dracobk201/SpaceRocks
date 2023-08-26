using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    [Header("Controllers")]
    [SerializeField] private TimeController timeController;
    [SerializeField] private InputController inputController;
    [SerializeField] private AudioController audioController;
    [SerializeField] private ScreenshakeController screenshakeController;
    [SerializeField] private PlayFabController playFabController;
    [SerializeField] private AsteroidGenerator asteroidGenerator;
    [SerializeField] private PlayerWeapon playerWeapon;
    [SerializeField] private PlayerMovement playerMovement;
    [Header("UI")]
    [SerializeField] private UIController uiController;

    private void Awake()
    {
        gameStatus.Restart();
        uiController.ShowHidePanel(UIPanel.None);
        playFabController.Login();
    }

    private void Start()
    {
        uiController.ShowHidePanel(UIPanel.MainMenu);
        audioController.PlayBGMGame();
    }

    private void Update()
    {
        if (gameStatus.ActualLife <=  0 && !gameStatus.Status.Equals(GameStatus.GameOver))
        {
            gameStatus.Status = GameStatus.GameOver;
            audioController.PlaySFXDead();
            uiController.ShowHidePanel(UIPanel.GameOver);
            playFabController.SendLeaderboard(gameStatus.ActualPoints);
        }
    }

    private void OnEnable()
    {
        inputController.ShootAction += playerWeapon.Shoot;
        inputController.ShootAction += audioController.PlaySFXShoot;
        inputController.MovementAction += playerMovement.Moving;
        inputController.AimAction += playerMovement.Aiming;
        timeController.OnTimeEnded += TimeEndedHandle;
        asteroidGenerator.AsteroidHit += audioController.PlaySFXAsteroidImpact;
        asteroidGenerator.PlayerHit += audioController.PlaySFXPlayerImpact;
        asteroidGenerator.PlayerHit += screenshakeController.TriggerSimpleShake;
        uiController.OnBeginGame += playFabController.Login;
    }

    private void OnDisable()
    {
        inputController.ShootAction -= playerWeapon.Shoot;
        inputController.ShootAction -= audioController.PlaySFXShoot;
        inputController.MovementAction -= playerMovement.Moving;
        inputController.AimAction -= playerMovement.Aiming;
        timeController.OnTimeEnded -= TimeEndedHandle;
        asteroidGenerator.AsteroidHit -= audioController.PlaySFXAsteroidImpact;
        asteroidGenerator.PlayerHit -= audioController.PlaySFXPlayerImpact;
        asteroidGenerator.PlayerHit -= screenshakeController.TriggerSimpleShake;
        uiController.OnBeginGame -= playFabController.Login;
    }

    private void TimeEndedHandle()
    {
        gameStatus.Status = GameStatus.GameOver;
        uiController.ShowHidePanel(UIPanel.GameOver);
    }
}
