using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameStatusReference gameStatus;
    [Header("Input and Player")]
    [SerializeField] private InputController inputController;
    [SerializeField] private PlayerWeapon playerWeapon;
    [SerializeField] private PlayerMovement playerMovement;
    [Header("UI")]
    [SerializeField] private UIController uiController;

    private void Awake()
    {
        uiController.ShowHidePanel(UIPanel.None);
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
