using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasi fyrir stýringu óvina leiksins sem er festur á óvina-GameObject
public class EnemyController : MonoBehaviour
{
    
    // Uppsetning gilda e.o. heilsustig, hraði, staða...
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    
    public GameObject itself;
    public int EnemyMaxHealth;
    public float AttackDelay = 1.0f;
    public float cooldown = 2.0f;
    private bool alive = true;
    public int currentHealth;
    private bool isDead = false;
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float timer = 0.0f;
    Vector2 lookDirection = new Vector2(1, 0);
    Animator animator;
    private bool boom = false;

    // Start er kallaður á undan fyrsta uppfærslu-rammann og setur upp hámarkslíf eftirfarandi tegund óvina sem heilsustig og eftirfarandi teiknimynda
    void Start()
    {
        currentHealth = EnemyMaxHealth;

        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update er kallaður einu sinni á ramma og sér um hreyfingar eftirfarandi óvina
    
    void Update()
    {
        
        //Debug.Log(Mathf.Abs(player.position.x * 100 - transform.position.x * 100));
        
        timer -= Time.deltaTime;
        if (alive == true)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
            animator.SetFloat("MoveX", movement.x);
            if (Mathf.Abs(player.position.y * 100 - transform.position.y * 100) < 100 && Mathf.Abs(player.position.x * 100 - transform.position.x * 100) < 100 && timer <= 0)
            {
                //Debug.Log(Mathf.Abs(player.position.y * 100 - transform.position.y * 100));
                // Debug.Log(itself +"kominn");
                animator.SetBool("Attack", true);
                boom = true;

                timer += cooldown;
            }
            else
            {
                animator.SetBool("Attack", false);
                boom = false;
            }
        }
    }
    // FixedUpdate heldur Update í gangi eins lengi og óvinurinn sé lifandi
    private void FixedUpdate()
    {
        if(alive == true)
        {
            moveCharacter(movement);
        }
    }

    // moveCharacter stýrir áttina sem óvinurinn á að fara og í hvaða hraða
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    // TakeDamage fær óvinina til að taka skaða og/eða deyja ef hetjan nær að lemja þá
    public void TakeDamage(int damage)
    {
        if(alive == true){
            currentHealth -= damage;
            animator.SetTrigger("TakeDamage");
            
            if (currentHealth <= 0)
            {
                Die();
            }
        }

    }

    // Die lætur óvini deyja og eyðast eftir nokkrar sekúndur
    void Die()
    {
        Debug.Log("enemy died");
        animator.SetBool("Dead",true);
        alive = false;
        Destroy(itself,2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (boom = true)
        {
            Debug.Log("Búmmmmmmmmmmm");
        }
        
    }
}