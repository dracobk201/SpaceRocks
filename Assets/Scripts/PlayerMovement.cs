using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private float movementSpeed;

    private void OnEnable()
    {
        inputController.movementAction += Moving;
        inputController.aimAction += Aiming;
    }

    private void OnDisable()
    {
        inputController.movementAction -= Moving;
        inputController.aimAction -= Aiming;
    }

    private void Moving(Vector2 movementAxis)
    {
        Vector3 movement = movementAxis * movementSpeed;
        transform.position += movement * Time.deltaTime;
    }

    private void Aiming(Vector2 mousePosition)
    {
        Vector3 targetDirection = (Vector3)mousePosition - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
