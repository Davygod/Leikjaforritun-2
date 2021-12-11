using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;

    void start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (attackTime <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("SLASH");
                animator.SetBool("isAttacking", true);
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);

                for (int i = 0; i < damage.Length; i++)
                {
                    Destroy(damage[i].gameObject);
                }
                attackTime = startTimeAttack;
            }
            
        }
        else
        {
            
            if (attackTime > 0.1 || attackTime < 0)
            {
                attackTime = 0;
            }
            else
            {
                attackTime -= Time.deltaTime;
            }
            
            animator.SetBool("isAttacking", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}

