using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxmMultiplier;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;
    //private Vector3 lastCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x)* parallaxmMultiplier;
        transform.Translate(new Vector3(deltaX, 0f, 0f));
        previousCameraPosition = cameraTransform.position;
    }
}
