using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string nombrePowerUp = "Energía";
    public int valorEnergia = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPowerUps recolector = other.GetComponent<PlayerPowerUps>();

            if (recolector != null)
            {
                recolector.RecogerPowerUp(valorEnergia, nombrePowerUp);
                Destroy(gameObject);
            }
        }
    }
}