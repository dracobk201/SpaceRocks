using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public event Action<Vector2> MovementAction;
    public event Action<Vector2> AimAction;
    public event Action ShootAction;
    private GameControls inputActions;
    private Camera mainCamera;

    private void Awake()
    {
        inputActions = new GameControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Game.Shoot.performed += context => CheckingShootAction(context);
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Game.Shoot.performed -= context => CheckingShootAction(context);
    }

    private void Update()
    {
        CheckingMovementAction();
        CheckingAimAction();
    }

    private void CheckingShootAction(InputAction.CallbackContext context)
    {
        ShootAction?.Invoke();
    }

    private void CheckingAimAction()
    {
        Vector2 aimValue = inputActions.Game.Look.ReadValue<Vector2>();
        aimValue = mainCamera.ScreenToWorldPoint(aimValue);
        AimAction?.Invoke(aimValue);
    }

    private void CheckingMovementAction()
    {
        Vector2 movementValue = inputActions.Game.Movement.ReadValue<Vector2>();
        MovementAction?.Invoke(movementValue);
    }
}
