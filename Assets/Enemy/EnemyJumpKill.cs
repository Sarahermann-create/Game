using UnityEngine;

public class EnemyJumpKill : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint contacto = collision.contacts[0];

            if (contacto.point.y > transform.position.y + 0.3f)
            {
                Rigidbody rbJugador = collision.gameObject.GetComponent<Rigidbody>();
                if (rbJugador != null)
                {
                    rbJugador.linearVelocity = new Vector3(rbJugador.linearVelocity.x, 5f, rbJugador.linearVelocity.z);
                }

                Destroy(gameObject);
            }
        }
    }
}