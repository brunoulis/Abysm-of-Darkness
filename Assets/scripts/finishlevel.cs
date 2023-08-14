using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishlevel : MonoBehaviour
{
    public Animator animator;
    private float tiempoEspera = 2f;
    private bool finalizar = false;


   

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("entra aqui..");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Finalizar nivel");
            animator.SetBool("finalizado", true);
            finalizar = true;
            StartCoroutine(EsperarYAvanzarSiguienteNivel());
        }
        
    }

    private IEnumerator EsperarYAvanzarSiguienteNivel()
    {
        yield return new WaitForSeconds(tiempoEspera);
        animator.SetBool("finalizado", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
