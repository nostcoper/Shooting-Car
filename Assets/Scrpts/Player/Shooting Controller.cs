using UnityEngine;

// public enum PowerUp
// {
//     DisparoUnico,
//     MunicionLimitada,
//     BalaLargoAlcance,
//     Impulse,
//     None,
// }

public class PowerUpController : MonoBehaviour
{
//     [Header("Bullet Prefabs")]
//     public GameObject normalBulletPrefab;
//     public GameObject longRangeBulletPrefab;

//     [Header("Fire Point")]
//     public Transform firePoint;

//     [SerializeField] 
//     private PowerUp currentPowerUp;
//     [SerializeField] 
//     private int remainingShots;
//     [SerializeField] 
//     private bool hasPowerUp;

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             TryShoot();
//         }
//     }

//     private void TryShoot()
//     {
//         if (!hasPowerUp)
//             return;

//         switch (currentMode)
//         {
//             case ShootingMode.DisparoUnico:
//                 HandleSingleShot();
//                 break;
                
//             case ShootingMode.MunicionLimitada:
//                 HandleLimitedAmmoShot();
//                 break;
                
//             case ShootingMode.BalaLargoAlcance:
//                 HandleLongRangeShot();
//                 break;
//         }
//     }

//     private void HandleSingleShot()
//     {
//         ShootNormalBullet();
//         DisablePowerUp();
//     }

//     private void HandleLimitedAmmoShot()
//     {
//         if (remainingShots <= 0)
//         {
//             DisablePowerUp();
//             return;
//         }

//         ShootNormalBullet();
//         remainingShots--;

//         if (remainingShots <= 0){
//             DisablePowerUp();
//         }
            
//     }

//     private void HandleLongRangeShot()
//     {
//         ShootLongRangeBullet();
//         DisablePowerUp();
//     }

//     private void ShootNormalBullet()
//     {
//         Instantiate(normalBulletPrefab, firePoint.position, firePoint.rotation);
//     }


//     private void ShootLongRangeBullet()
//     {
//         Instantiate(longRangeBulletPrefab, firePoint.position, firePoint.rotation);
//     }


//     public void SetMode(ShootingMode mode)
//     {
//         currentMode = mode;
//         hasPowerUp = true;
//         remainingShots = (mode == ShootingMode.MunicionLimitada) ? 3 : -1;
//     }
//     private void DisablePowerUp()
//     {
//         hasPowerUp = false;
//         remainingShots = -1;
//     }

//     public bool HasPowerUp(){
//         return hasPowerUp;
//     }


}