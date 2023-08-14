using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rinoceronte : MonoBehaviour
{
    public Transform sueloControlador;

    public Transform posInicial;

    public Transform posFinal;
    public Transform jugador;
    public float velocidad;
    public float distanciaPersecucion;
    public float alturaPersecucion;
    public float alturaMinima;
    public float vidaMaxima;
    public float dañoAlJugador;
    public float dañoRecibido;
    public Animator animator;

    private Rigidbody2D rb;
    private bool enMovimiento;
    private float vida;
    private Transform PosTarget;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        vida = vidaMaxima;
        PosTarget = posInicial;
    }

    private void Update()
    {
        if (!enMovimiento)
        {
            animator.SetBool("iddle", true);
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
        }
        //Comprobamos si el jugador es nulo
        float distanciaHorizontal = Mathf.Abs(transform.position.x - jugador.position.x);
        float distanciaVertical = Mathf.Abs(transform.position.y - jugador.position.y);

        if (distanciaHorizontal < distanciaPersecucion && distanciaVertical < alturaPersecucion && transform.position.y >= alturaMinima)
        {
            enMovimiento = true;

            if (distanciaHorizontal < 0.5f && distanciaVertical < 0.5f)
            {
                // Jugador está suficientemente cerca y a la misma altura, atropellarlo
                animator.SetBool("iddle", false);
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
                AtropellarJugador();
            }
            else
            {
                // Jugador está cerca pero no lo suficiente, perseguirlo
                animator.SetBool("iddle", false);
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
                PerseguirJugador();
            }
        }
        else
        {
            enMovimiento = true;

            // Jugador está lejos o a una altura no alcanzable, caminar por la plataforma
            animator.SetBool("iddle", false);
            animator.SetBool("walk", true);
            animator.SetBool("run", false);
            Mover();
        }
    }

    private void Mover()
    {
        //Debug.Log("mover");

        float distanciaVertical = Mathf.Abs(transform.position.y - PosTarget.position.y);
        float distanciaHorizontal = Mathf.Abs(transform.position.x - PosTarget.position.x);

        if (distanciaVertical < 0.1f && distanciaHorizontal < 0.1f)
        {
            if (PosTarget == posInicial)
            {
                PosTarget = posFinal;
            }
            else
            {
                PosTarget = posInicial;
            }
        }

    Vector2 direccion = PosTarget.position - transform.position;
    direccion.Normalize();

    rb.velocity = direccion * velocidad;
        // Girar el sprite según la dirección
        if (direccion.x > 0)
        {
            // Mirando hacia la derecha
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (direccion.x < -0)
        {
            // Mirando hacia la izquierda
            transform.localScale = new Vector3(1f, 1f, 1f);
           
        }
    }


    private void PerseguirJugador()
    {
        Debug.Log("perseguir jugador");
        Vector2 direccion = jugador.position - transform.position;
        direccion.Normalize();

        rb.velocity = direccion * velocidad;

        // Girar el sprite según la dirección
        if (direccion.x > 0.5)
        {
            // Mirando hacia la derecha
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (direccion.x < 0.5)
        {
            // Mirando hacia la izquierda
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void AtropellarJugador()
    {
        // Detener el movimiento del rinoceronte
        rb.velocity = Vector2.zero;

        // Verificar si el jugador está a la misma altura que el rinoceronte
        float alturaDiferencia = Mathf.Abs(jugador.position.y - transform.position.y);
        if (alturaDiferencia <= 0.5f)
        {
            // Aplicar daño al jugador
            CombateJugador jugadorScript = jugador.GetComponent<CombateJugador>();
            if (jugadorScript != null)
            {
                jugadorScript.TomarDaño(dañoAlJugador);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Colisión con el jugador, quitar vida al jugador y recibir daño
            CombateJugador jugador = collision.GetComponent<CombateJugador>();
            jugador.TomarDaño(dañoAlJugador);
            // TomarDaño(dañoRecibido);
        }
    }
}
