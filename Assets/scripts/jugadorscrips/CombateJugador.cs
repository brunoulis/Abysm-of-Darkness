using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] public float vidaMaxima;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private float fuerzaEmpuje; // Fuerza de empuje al recibir daño
    private Rigidbody2D rb;

    public GameManagerScript gameManagerScript; // Referencia al script GameManagerScript

    public PlayerController playerController; // Referencia al script PlayerController

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMaxima;
        barraDeVida.InicializarBarraDeVida(vida);
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>(); // Obtener referencia al script PlayerController
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            Morir();
        }
        else
        {
            Empujar();
            playerController.DeshabilitarMovimiento(); // Llama al método para deshabilitar el movimiento en PlayerController
        }
    }

    public void Curar(float cantidadVida)
    {
        vida += cantidadVida;
        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
            barraDeVida.CambiarVidaMaxima(vidaMaxima);
        }
    }

    public void Morir()
    {
        gameManagerScript.GameOver();
        Destroy(gameObject);
    }

    private void Empujar()
    {
        // Empujar al jugador en la dirección opuesta al movimiento con addForce
        rb.AddForce(new Vector2(-fuerzaEmpuje * transform.localScale.x, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
