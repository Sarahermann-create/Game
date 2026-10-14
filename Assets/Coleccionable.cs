using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    private void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.RecogerColeccionable();
            }

            Destroy(gameObject);
        }
    }
}
