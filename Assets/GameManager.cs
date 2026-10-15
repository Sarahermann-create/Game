using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Referencias del HUD")]
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoVidas;

    [Header("Configuración del Juego")]
    public int coleccionablesRecogidos = 0;
    public int metaColeccionables = 5; 
    public int vidas = 3;

    [Header("Efectos de Audio")]
    public AudioSource fuenteDeAudio; 
    public AudioClip sonidoColeccionable;
    public AudioClip sonidoGanar;
    public AudioClip sonidoGameOver;

    [Header("Referencia del Jugador")]
    public GameObject jugador; 

    private bool juegoTerminado = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        ActualizarHUD();

        if (fuenteDeAudio == null)
        {
            fuenteDeAudio = GetComponent<AudioSource>();
        }
    }

    public void RecogerColeccionable()
    {
        if (juegoTerminado) return;

        coleccionablesRecogidos++;
        ActualizarHUD();

        if (fuenteDeAudio != null && sonidoColeccionable != null)
        {
            fuenteDeAudio.PlayOneShot(sonidoColeccionable);
        }

        if (coleccionablesRecogidos >= metaColeccionables)
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

         
            Debug.Log("¡GAME OVER! Se acabaron las vidas.");

            if (fuenteDeAudio != null && sonidoGameOver != null)
            {
                fuenteDeAudio.PlayOneShot(sonidoGameOver);
            }

            if (jugador != null)
            {
                jugador.SetActive(false);
            }
        }
    }

    void ActualizarHUD()
    {
        if (textoPuntaje != null) 
            textoPuntaje.text = "Puntaje: " + coleccionablesRecogidos + "/" + metaColeccionables;
        
        if (textoVidas != null) 
            textoVidas.text = "Vidas: " + vidas;
    }
}
