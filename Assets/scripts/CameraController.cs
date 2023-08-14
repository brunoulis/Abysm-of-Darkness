using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Etiqueta (tag) del objeto que queremos seguir
    public string playerTag = "Player";

    // Velocidad de movimiento de la cámara
    public float smoothSpeed = 0.125f;

    // Distancia entre el objeto que seguimos y la cámara
    public Vector3 offset;

    // Transform del objeto que queremos seguir
    private Transform target;

    void Start()
    {
        // Buscamos el objeto con la etiqueta "playerTag"
        target = GameObject.FindGameObjectWithTag(playerTag).transform;

        // Calculamos la distancia entre el objeto que queremos seguir y la cámara
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Imprimimos en consola el nombre del objeto que estamos siguiendo
        //Debug.Log("Siguiendo a: " + target.name);

        // Si el objeto que queremos seguir existe y está activo...
        if (target != null && target.gameObject.activeSelf)
        {
            // Calculamos la posición que queremos que tenga la cámara
            Vector3 desiredPosition = target.position + offset;

            // Movemos suavemente la cámara hacia la posición deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
