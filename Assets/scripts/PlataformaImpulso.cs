using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlataformaImpulso : MonoBehaviour
{
    public Animator animator;
    private string animacionImpulso = "impulsar";
    private float fuerzaImpulso = 8f;

    private bool activado = false;

    private void Start()
    {
        // Asegúrate de asignar el componente Animator en el Inspector
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activado = true;
            animator.SetBool("impulsar", true);

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direccionImpulso = transform.up * fuerzaImpulso;
                rb.AddForce(direccionImpulso, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desactivar la animación después de 0.20 segundos
            activado = false;
            animator.SetBool("impulsar", false);
            
        }
    }
    
    
}