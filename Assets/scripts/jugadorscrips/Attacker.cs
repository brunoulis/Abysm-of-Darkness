using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private Animator anim;
    private Collider attackRangeCollider;
    public GameObject hit;

    public float daño; // Daño que inflige el jugador

    public bool isAttacking;

    public bool appliedDamage;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isAttacking = false;
    }

    public void Attack()
    {
        if (!isAttacking) // Verificar si ya no se está atacando
        {
            anim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    // Método para detectar colisiones con el rango de ataque
    public void OnTriggerStay2D(Collider2D other)
    {
        if (isAttacking) // Verificar si todavía se está atacando
        {
            if (other.CompareTag("Enemigo")&& appliedDamage)
            {
                Debug.Log("Enemigo detectado");
                CombateEnemigo enemigo = other.GetComponent<CombateEnemigo>();
                // Llama a la función "TomarDaño" del enemigo
                if (enemigo != null)
                {
                    enemigo.TomarDaño(daño);
                }
            }
        }
    }

    public void ApliedDamage()
    {
        appliedDamage = true;
        
    }

    public void DesappliedDamage()
    {
        appliedDamage = false;
    }

    // Evento de animación para indicar que el ataque ha terminado
    public void AttackAnimationFinished()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }
}
