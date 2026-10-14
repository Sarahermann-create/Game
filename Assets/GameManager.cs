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
    public AudioClip sonidoColeccionable;
    public AudioClip sonidoGanar;
    public AudioClip sonidoGameOver;

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

        coleccionablesRecogidos++;
        ActualizarHUD();

        if (sonidoColeccionable != null)
        {
            AudioSource.PlayClipAtPoint(sonidoColeccionable, Camera.main.transform.position);
        }

        if (coleccionablesRecogidos >= metaColeccionables)
        {
            juegoTerminado = true;
            Debug.Log("¡Ganaste el juego!");

            if (sonidoGanar != null)
            {
                AudioSource.PlayClipAtPoint(sonidoGanar, Camera.main.transform.position);
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

            if (sonidoGameOver != null)
            {
                AudioSource.PlayClipAtPoint(sonidoGameOver, Camera.main.transform.position);
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
