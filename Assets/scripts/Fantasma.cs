using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour
{
    public Transform jugador;
    public float velocidad;
    public float rangoPersecucion;
    public float dañoAlJugador;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool aparecer = false; // Booleano para controlar la animación de aparecer
    private bool desaparecer = true; // Booleano para controlar la animación de desaparecer

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Calcular la distancia entre el fantasma y el jugador
        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia < rangoPersecucion)
        {
            // Calcular la dirección hacia el jugador
            Vector2 direccion = jugador.position - transform.position;
            direccion.Normalize();

            // Mover el fantasma hacia el jugador
            rb.velocity = direccion * velocidad;

            // Girar el sprite hacia la dirección del movimiento
            if (direccion.x > 0)
                spriteRenderer.flipX = true;
            else if (direccion.x < 0)
                spriteRenderer.flipX = false;

            // Activar la animación de aparecer y desactivar la animación de desaparecer
            if (!aparecer)
            {
                aparecer = true;
                desaparecer = false;
                animator.SetBool("aparecer", true);
                animator.SetBool("desaparecer", false);
            }
        }
        else
        {
            // Detener el movimiento del fantasma
            rb.velocity = Vector2.zero;

            // Activar la animación de desaparecer y desactivar la animación de aparecer
            if (!desaparecer)
            {
                desaparecer = true;
                aparecer = false;
                animator.SetBool("desaparecer", true);
                //animator.SetBool("aparecer", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Colisión con el jugador, quitar vida al jugador y recibir daño
            CombateJugador jugador = collision.GetComponent<CombateJugador>();
            if (jugador != null)
            {
                // Hacer que el jugador reciba daño
                jugador.TomarDaño(dañoAlJugador);
            }
        }
    }

    public void DesactivarAparecerAnim()
    {
        animator.SetBool("aparecer", false);
    }
}
