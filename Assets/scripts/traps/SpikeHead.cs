using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{

    [SerializeField] private float damage;

    [Header("Spike Head")]
    [SerializeField] private float speed;
    [SerializeField] private float range;

    [SerializeField] private float checkDelay;
    [SerializeField] private GameObject playerObject;
    private float checkTimer;
    private Vector3 destination;

    private bool attacking;

    private Vector3[] directions = new Vector3[4];

    private void OnEnable()
    {
        Stop();
    }
    private void Update()
    {
        //Move spikehead to destination only if attacking
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }
    private void CheckForPlayer()
    {
        CalculateDirections();

        //Check if spikehead sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range);

            if (hit.collider != null && hit.collider.gameObject == playerObject && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range; //Right direction
        directions[1] = -transform.right * range; //Left direction
        directions[2] = transform.up * range; //Up direction
        directions[3] = -transform.up * range; //Down direction
    }
    private void Stop()
    {
        destination = transform.position; //Set destination as current position so it doesn't move
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Buscamos el script combate jugador y le hacemos daño
            collision.GetComponent<CombateJugador>().TomarDaño(damage);
        }
        Stop();
        // paramos el movimiento de la cabeza

    }
}
