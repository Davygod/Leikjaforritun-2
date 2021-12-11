using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

// Klasinn fyrir hetjuna, þ.á.m. hreyfingu, árás og heilsustig
public class PlayerController : MonoBehaviour
{
    
    public int maxHealth = 100;
    private int currentHealth;
    public bool alive = true;
    
    public int health { get { return currentHealth; }}
    
    int offense;
    int range;
    Vector2 lookDirection = new Vector2(1, 0);
    Rigidbody2D rigidbody2d;
    Animator animator;
    
    // Start kallar upp teiknimyndir á hetjunni ásamt heilsustig fyrir uppfærslu
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update er kallaður einu sinni til þess að setja upp hreyfingaráttir hetjunnar
    void FixedUpdate()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(HorizontalInput, VerticalInput);
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * HorizontalInput;
        position.y = position.y + 0.1f * VerticalInput;
        transform.position = position;
        if (HorizontalInput == 0)
        {
            lookDirection.Set(move.x, move.y);
        }
        

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("MoveX", lookDirection.x);

        rigidbody2d.MovePosition(position);
       
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
    public void TakeDamage(int damage)
    {
        if (alive == true)
        {
            currentHealth -= damage;
            animator.SetTrigger("TakeDamage");

            if (currentHealth <= 0)
            {
                Die();
                animator.SetBool("Dead", true);
            }
        }

    }
    void Die()
    {
        Debug.Log("Hetjan dó");
        alive = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
