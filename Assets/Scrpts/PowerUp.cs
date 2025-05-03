using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ShootingController shooting = other.GetComponent<ShootingController>();
        if (shooting != null)
        {
            float randomValue = Random.value;

            if (randomValue < 0.5f)
            {
                shooting.SetMode(ShootingMode.DisparoUnico);
                Debug.Log("Power-up activado: Disparo Único");
            }
            else if (randomValue < 0.75f)
            {
                shooting.SetMode(ShootingMode.MunicionLimitada);
                Debug.Log("Power-up activado: Munición limitada (3)");
            }
            else
            {
                shooting.SetMode(ShootingMode.BalaLargoAlcance);
                Debug.Log("Power-up activado: Bala de largo alcance");
            }

            Destroy(gameObject);
        }
    }
}
