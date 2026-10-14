using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Referencias del HUD")]
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoVidas;

    [Header("Configuracion del Juego")]
    public int puntaje = 0;
    public int vidas = 3;
    public int metaColeccionables = 5;

    [Header("Efectos de Audio")]
    public AudioSource fuenteDeAudio;
    public AudioClip sonidoColeccionable;
    public AudioClip sonidoGanar;
    public AudioClip sonidoPerder;

    private bool juegoTerminado = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        ActualizarHUD();
    }

    public void RecogerColeccionable()
    {
        if (juegoTerminado) return;

        puntaje++;
        ActualizarHUD();

        if (fuenteDeAudio != null && sonidoColeccionable != null)
        {
            fuenteDeAudio.PlayOneShot(sonidoColeccionable);
        }

        if (puntaje >= metaColeccionables)
        {
            juegoTerminado = true;
            Debug.Log("¡Ganaste el juego!");

            if (fuenteDeAudio != null && sonidoGanar != null)
            {
                fuenteDeAudio.PlayOneShot(sonidoGanar);
            }
        }
    }

    public void PerderVida()
    {
        if (juegoTerminado) return;

        vidas--;
        ActualizarHUD();

        if (vidas <= 0)
        {
            juegoTerminado = true;
            Debug.Log("Game Over");

            if (fuenteDeAudio != null && sonidoPerder != null)
            {
                fuenteDeAudio.PlayOneShot(sonidoPerder);
            }
        }
    }

    void ActualizarHUD()
    {
        if (textoPuntaje != null) textoPuntaje.text = "Puntaje: " + puntaje + "/" + metaColeccionables;
        if (textoVidas != null) textoVidas.text = "Vidas: " + vidas;
    }
}
