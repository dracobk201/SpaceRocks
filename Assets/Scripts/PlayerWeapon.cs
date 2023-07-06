using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform shipGun;
    [SerializeField] private InputController inputController;
    [SerializeField] private ObjectPool projectilePool;
    [SerializeField] private float weaponCooldownTimer;
    private bool canShoot;

    private void OnEnable()
    {
        inputController.shootAction += Shoot;
        canShoot = true;
    }

    private void OnDisable()
    {
        inputController.shootAction -= Shoot;
    }

    private void Shoot()
    {
        if (!canShoot)
        {
            return;
        }
        projectilePool.ActivateValidObject(shipGun.transform.position, shipGun.transform.rotation);
        StartCoroutine(SetWeaponCooldown());
    }

    private IEnumerator SetWeaponCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(weaponCooldownTimer);
        canShoot = true;
    }
}
