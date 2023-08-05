using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    [Header("Input and Player")]
    [SerializeField] private InputController inputController;
    [SerializeField] private AsteroidGenerator asteroidGenerator;
    [SerializeField] private PlayerWeapon playerWeapon;
    [SerializeField] private PlayerMovement playerMovement;
    [Header("UI")]
    [SerializeField] private UIController uiController;

    private void Awake()
    {
        gameStatus.Restart();
        uiController.ShowHidePanel(UIPanel.None);
    }

    private void Update()
    {
        if (gameStatus.ActualLife <=  0 && !gameStatus.Status.Equals(GameStatus.GameOver))
        {
            gameStatus.Status = GameStatus.GameOver;
            uiController.ShowHidePanel(UIPanel.GameOver);
        }
    }

    private void OnEnable()
    {
        inputController.shootAction += playerWeapon.Shoot;
        inputController.movementAction += playerMovement.Moving;
        inputController.aimAction += playerMovement.Aiming;
    }

    private void OnDisable()
    {
        inputController.shootAction -= playerWeapon.Shoot;
        inputController.movementAction -= playerMovement.Moving;
        inputController.aimAction -= playerMovement.Aiming;
    }

    private void Start()
    {
        uiController.ShowHidePanel(UIPanel.MainMenu);
    }
}
