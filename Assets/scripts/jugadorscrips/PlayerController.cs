using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject groundCheck;

    private IMovable horizontalMover;
    private Jumper jumper;
    private Attacker attacker;
    

    private float horizontalMove;

    private bool movimientoHabilitado = true;

    

    private void Start()
    {
        horizontalMover = new HorizontalMover(GetComponent<Rigidbody2D>(), moveSpeed);
        jumper = GetComponent<Jumper>();
        attacker = GetComponent<Attacker>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        horizontalMover.Move(horizontalMove);
        if (horizontalMove < 0.0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalMove > 0.0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }


        if (Input.GetButtonDown("Jump"))
        {
            jumper.Jump();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            attacker.Attack();
        }
    }
    public void DeshabilitarMovimiento()
    {
        movimientoHabilitado = false;
    }

    public void HabilitarMovimiento()
    {
        movimientoHabilitado = true;
    }
}
