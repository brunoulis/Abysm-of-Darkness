using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform[] Pose;
    public float speed;
    public int ID;
    public int suma;

    public Transform PosIni;
    public Transform PosFin;

    public Transform PosTarget;

    // Referencia al jugador
    private GameObject jugador;
    private bool siguiendoJugador;

    private void Start()
    {
        PosTarget = PosIni;
        jugador = GameObject.FindGameObjectWithTag("Player");
        siguiendoJugador = false;
    }

    private void Update()
    {
        if (siguiendoJugador)
        {
            jugador.transform.parent = transform;
        }

        // Comprobamos si llega al principio o al final de la plataforma

        if (Vector2.Distance(transform.position, PosIni.position) < 0.001 && PosTarget.position == PosIni.position)
        {
            PosTarget = PosFin;
        }

        if (Vector2.Distance(transform.position, PosFin.position) < 0.001 && PosTarget.position == PosFin.position)
        {
            PosTarget = PosIni;
        }

        transform.position = Vector3.MoveTowards(transform.position, PosTarget.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            siguiendoJugador = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            siguiendoJugador = false;
            jugador.transform.parent = null;
        }
    }
}
