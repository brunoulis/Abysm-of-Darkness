using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private float daño; // Daño que infligen los pinchos

    // Cuando el jugador colisiona con los pinchos
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto que ha colisionado con los pinchos es el jugador
        if (other.CompareTag("Player"))
        {   
            //Mostramos que jugador ha muerto
            Debug.Log("El jugador ha muerto");
            // Obtener el componente CombateJugador del jugador
            CombateJugador jugador = other.GetComponent<CombateJugador>();
            // Si el componente CombateJugador existe en el jugador
            if (jugador != null)
            {
                //recibimos el maximo de vida del jugador
                daño= jugador.vidaMaxima + 1;

                // Verificar si la posición del jugador está por encima de los pinchos
                if (jugador.transform.position.y > transform.position.y)
                {
                    Debug.Log("Pinchos detectados");
                    // Hacer que el jugador reciba daño en este caso el jugador muere
                    jugador.TomarDaño(daño);
                }
            }
        }
        // Si el objeto que ha colisionado con los pinchos es un enemigo
        else if (other.CompareTag("Enemigo"))
        {
            // Obtener el componente CombateEnemigo del enemigo
            CombateEnemigo enemigo = other.GetComponent<CombateEnemigo>();
            // Si el componente CombateEnemigo existe en el enemigo
            if (enemigo != null)
            {
                // Cogemos el maximo de vida del enemigo y le sumamos 1
                daño = enemigo.vidaMaxima + 1;

                // Verificar si la posición del enemigo está por encima de los pinchos
                if (enemigo.transform.position.y > transform.position.y)
                {
                    // Hacer que el enemigo reciba daño en este caso el enemigo muere
                    enemigo.TomarDaño(daño);
                }
            }
        }
    }
}
