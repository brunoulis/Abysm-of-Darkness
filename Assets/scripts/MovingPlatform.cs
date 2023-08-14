using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1f;

    private Vector3 nextPosition;
    private bool movingToEndPoint = true;

    void Start()
    {
        nextPosition = endPoint.position;
    }

    void FixedUpdate()
    {
        if (movingToEndPoint)
        {
            MovePlatform(nextPosition);

            if (transform.position == nextPosition)
            {
                nextPosition = startPoint.position;
                movingToEndPoint = false;
            }
        }
        else
        {
            MovePlatform(nextPosition);

            if (transform.position == nextPosition)
            {
                nextPosition = endPoint.position;
                movingToEndPoint = true;
            }
        }
    }

    void MovePlatform(Vector3 targetPosition)
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        transform.position = newPosition;

        // Detectar si el jugador está encima de la plataforma
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                collider.transform.SetParent(transform);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
