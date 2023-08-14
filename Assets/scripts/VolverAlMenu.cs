using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenu : MonoBehaviour
{
    public Animator animator;

    private float tiempoEspera = 2f;

    private bool finalizar = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Volver al menu nivel");
            animator.SetBool("finalizado", true);
            finalizar = true;
            StartCoroutine(Volveralmenu());
        }
        
    }

    private IEnumerator Volveralmenu()
    {
        yield return new WaitForSeconds(tiempoEspera);
        // Volvemos a la posición inicial 0 del juego
        animator.SetBool("finalizado", false);
        SceneManager.LoadScene(0);
    }


    
    
}
