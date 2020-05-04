using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyAnimations : MonoBehaviour
{

    private Enemy enemy;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void Die()
    {
        if (enemy.currentHealth <= 0)
        {
            animator.SetTrigger("skeletonIsDead");

            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }
      
}
