using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    [SerializeField] private float distancia;
    public Vector3 posicionInicial;
    private Animator anim;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        posicionInicial = transform.position;
        sprite=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Si el jugador no es nulo comprobar la distancia
        distancia = Vector2.Distance(transform.position, jugador.position);
        anim.SetFloat("Distancia", distancia);
    }
    public void Girar(Vector3 objetivo)
    {
        if(transform.position.x<objetivo.x)
        {
            sprite.flipX=true;
        }
        else
        {
            sprite.flipX=false;
        }
    }
}
