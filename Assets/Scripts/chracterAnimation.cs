using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class chracterAnimation : MonoBehaviour
{
    private CharacterMovement characterMovement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        Walking();
        Running();
        Attacking();
    }

    private void Walking()
    {
        if (characterMovement.isWalking == false)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            spriteRenderer.flipX = characterMovement.move > 0;
        }
    }

    private void Running()
    {
        if (characterMovement.isRunning == false)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = characterMovement.move > 0;
        }
    }

    private void Attacking()
    {
        if (characterMovement.isAttacking == false)
        {
            animator.SetBool("isAttacking", false);
        }
        else
        {
            animator.SetBool("isAttacking", true);
        }
    }
     
    //private void Jump()
    //{
    //   if(characterMovement.isJumping == false)
    //    {
    //        animator.SetBool("isJumping", false);
    //    }
    //    else
    //    {
    //        animator.SetBool("isJumping", true);
    //    }
    //}
}
