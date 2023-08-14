using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private float horizontalMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (horizontalMove < 0.0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalMove > 0.0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        anim.SetBool("isRunning", horizontalMove != 0.0f);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        if (isGrounded && rb.velocity.y < 0.1f) // Comprueba si el jugador está en el suelo y no se está moviendo hacia arriba
        {
            rb.velocity = new Vector2(horizontalMove, 0.0f); // Establece la velocidad en el eje y a 0 para evitar saltos adicionales
        }
        else
        {
            rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void Attack()
    {
        anim.SetTrigger("isAttacking");
    }
}
