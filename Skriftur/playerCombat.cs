using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{

    public Animator animator;
    public float attackDelay = 1.0f;
    public float time;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int AttackDamage = 50;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            if (attackDelay <= 0){
                Attack();
                attackDelay = 1.0f;
            }
        
        }
        if (attackDelay > 0)
        {
            attackDelay -= Time.deltaTime;
        }
        
    }

    void Attack()
    {
        
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D Enemy in hitEnemies)
        {
            Debug.Log(Enemy.name);
            Enemy.GetComponent<EnemyController>().TakeDamage(AttackDamage);
                
            
            
        }

    }
    

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
