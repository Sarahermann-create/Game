using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    private int[] energiasObtenidas = new int[0];

    public void RecogerPowerUp(int cantidadEnergia, string nombre)
    {
        System.Array.Resize(ref energiasObtenidas, energiasObtenidas.Length + 1);
        energiasObtenidas[energiasObtenidas.Length - 1] = cantidadEnergia;
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RecogerColeccionable();
        }

        MostrarHistorialYEnergiaTotal();
    }

    private void MostrarHistorialYEnergiaTotal()
    {
        int energiaTotal = 0;
        Debug.Log($"Power-ups recolectados hasta ahora: {energiasObtenidas.Length}");

        for (int i = 0; i < energiasObtenidas.Length; i++)
        {
            int energiaActual = energiasObtenidas[i];
            energiaTotal += energiaActual;
            Debug.Log($"Power-up {i + 1}: {energiaActual} pts de energía.");
        }

        Debug.Log($"ENERGÍA TOTAL ACUMULADA: {energiaTotal} pts");
    }
}