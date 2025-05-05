using UnityEngine;

public enum ShootingMode
{
    DisparoUnico,
    MunicionLimitada,
    BalaLargoAlcance
}

public class ShootingController : MonoBehaviour
{
    [Header("Bullet Prefabs")]
    public GameObject normalBulletPrefab;
    public GameObject longRangeBulletPrefab;

    [Header("Fire Point")]
    public Transform firePoint;

    private ShootingMode currentMode;
    private int remainingShots;
    private bool hasPowerUp;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryShoot();
        }
    }

    private void TryShoot()
    {
        if (!hasPowerUp)
            return;

        if (currentMode == ShootingMode.MunicionLimitada)
        {
            if (remainingShots <= 0)
            {
                DisablePowerUp();
                return;
            }

            Shoot();
            remainingShots--;

            if (remainingShots <= 0)
                DisablePowerUp();
        }
        else
        {
            Shoot();
            DisablePowerUp();
        }
    }

    private void Shoot()
    {
        GameObject bulletPrefab = currentMode == ShootingMode.BalaLargoAlcance
            ? longRangeBulletPrefab
            : normalBulletPrefab;

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void SetMode(ShootingMode mode)
    {
        currentMode = mode;
        hasPowerUp = true;

        remainingShots = (mode == ShootingMode.MunicionLimitada) ? 3 : -1;
    }

    public bool HasPowerUp() => hasPowerUp;

    private void DisablePowerUp()
    {
        hasPowerUp = false;
        remainingShots = -1;
    }
}
