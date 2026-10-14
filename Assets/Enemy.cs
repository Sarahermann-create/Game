using UnityEngine;

public class EnemigoPatrullaYPerseguir : MonoBehaviour
{
    public Transform jugador;
    public Transform puntoA;
    public Transform puntoB;

    [Header("Ajustes")]
    public float speed = 3f;
    public float detectionRange = 5f;

    private Transform destino;

    void Start()
    {
        if (jugador == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                jugador = playerObj.transform;
            }
        }

        if (puntoA != null && puntoB != null)
        {
            destino = puntoB;
        }
    }

    void Update()
    {
        if (jugador != null)
        {
            float distancia = Vector3.Distance(transform.position, jugador.position);

            if (distancia <= detectionRange)
            {
                Vector3 destinoJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    destinoJugador,
                    speed * Time.deltaTime
                );
                
                if (destinoJugador != transform.position)
                {
                    transform.LookAt(destinoJugador);
                }
                return;
            }
        }

        if (puntoA != null && puntoB != null && destino != null)
        {
            Vector3 destinoPatrulla = new Vector3(destino.position.x, transform.position.y, destino.position.z);
            transform.position = Vector3.MoveTowards(
                transform.position,
                destinoPatrulla,
                speed * Time.deltaTime
            );

            if (destinoPatrulla != transform.position)
            {
                transform.LookAt(destinoPatrulla);
            }

            if (Vector3.Distance(transform.position, destinoPatrulla) < 0.2f)
            {
                if (destino == puntoA)
                    destino = puntoB;
                else
                    destino = puntoA;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}