using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterMovement : MonoBehaviour
{
    public float walkingSpeed;
    public float normalSpeed;
    public float runSpeed;
    public float jump;
    public float move;

    public int damage;

    public bool isWalking = false;
    public bool isRunning = false;
    public bool isJumping = false;
    public bool isAttacking = false;
 
    public Transform attackHitZone;
    public float attackRange;
    public LayerMask enemyLayers;



    private Rigidbody2D rb;
    private characterGrounding characterGrounding;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<characterGrounding>();
    }

    private void Update()
    {
        Walking();
        Attacking();
        Running();
    }

    private void Walking()
    {
        //move = Input.GetAxis("Horizontal");

        move = 0f;
        if (Keyboard.current.aKey.isPressed) move = -1f;
        if (Keyboard.current.dKey.isPressed) move = 1f;

        rb.velocity = new Vector2(move * walkingSpeed, rb.velocity.y);

        if (move > 0 || move < 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void Running()
    {
        //if (Input.GetKey(KeyCode.LeftShift) && isWalking == true)

        if (Keyboard.current.leftShiftKey.isPressed && isWalking)
        {
            isRunning = true;
            walkingSpeed = runSpeed;
        }
        else
        {
            isRunning = false;
            walkingSpeed = normalSpeed;
        }
    }

    //private void Jump()
    //{
    //    if (Input.GetButton("Jump") && characterGrounding.isGrounded)
    //    {
    //        rb.AddForce(new Vector2(rb.velocity.x, jump));
    //        isJumping = true;
    //    }
    //    else
    //    {
    //        isJumping = false;
    //    }
    //}

    private void Attacking()
    {
        //if (Input.GetButtonDown("Space"))
        if (Keyboard.current.spaceKey.IsActuated())
        {
            isAttacking = true;

            Collider2D[] hitEmnemies = Physics2D.OverlapCircleAll(attackHitZone.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEmnemies)
            {
                enemy.GetComponent<Enemy>().takeDamage(damage);
            }
        }
        else
        {
            isAttacking = false;
        }
    }

    private void OnDrawGizmosSelected()
    {

        if (attackHitZone == null)
            return;


        Gizmos.DrawWireSphere(attackHitZone.position, attackRange);
    }

}
