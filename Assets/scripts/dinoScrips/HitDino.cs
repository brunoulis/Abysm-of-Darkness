using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDino : MonoBehaviour
{
    public int Daño;
    private bool atacando;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            atacando = true;
          // Recibimos el script CombateJugador y los usamos para llamar a la funcion tomar daño
            CombateJugador jugador = coll.GetComponent<CombateJugador>();
            jugador.TomarDaño(Daño);
            Debug.Log("hacer daño");
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        atacando = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

