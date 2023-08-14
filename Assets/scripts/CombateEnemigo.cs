using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateEnemigo : MonoBehaviour
{
    public float vidaMaxima;
    private float vidaActual;
    private Rigidbody2D rb;
    [SerializeField] private float fuerzaEmpuje; // Fuerza de empuje al recibir daño

    private Animator animator;

    private void Start()
    {
        vidaActual = vidaMaxima;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float cantidad)
    {
        
        vidaActual -= cantidad;
        animator.SetBool("recibir", true);

        Debug.Log("Vida actual: " + vidaActual);
        
        if (cantidad > vidaActual){
            //la cantidad de daño pasara a ser la mitad de la vida actual
            cantidad=vidaActual/2;

        }

        if (vidaActual <= 0)
        {
            Morir();
        }
        else
        {
            Empujar();
        }
    }

    public void Morir()
    {
        // Aquí puedes agregar cualquier lógica adicional cuando el enemigo muera
        Destroy(gameObject);
    }

    private void Empujar()
    {
        // Obtener la dirección opuesta al ataque
        Vector2 direccionEmpuje = -rb.velocity.normalized;

        // Aplicar la fuerza de empuje al enemigo
        rb.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode2D.Impulse);
    }
    public void DesactivarRecibirDaño()
    {
        animator.SetBool("recibir", false);
    }
}
