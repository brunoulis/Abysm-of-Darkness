using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage; // Daño que hace la trampa
    [Header("Firetrap timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    

    private Animator animator;

    private bool triggered; // Variable para saber si la trampa recibe el trigger
    private bool active; // Variable para saber si la trampa está activa y puede dañar al jugador
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (!triggered)
            {
                //triggered the firetrap
                StartCoroutine(ActivateFireTrap());
            }
            if(active){
                other.GetComponent<CombateJugador>().TomarDaño(damage);// Obtenemos el script CombateJugador del jugador y le hacemos daño
            }
        }
    }
    private IEnumerator ActivateFireTrap(){

        // Activar la animación de la trampa 
        triggered = true;
        // Esperar un tiempo y activar la trampa
        yield return new WaitForSeconds(activationDelay);
        active = true;
        animator.SetBool("activated", true);
        // Esperar un tiempo y desactivar la trampa
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        animator.SetBool("activated", false);


    }
}
