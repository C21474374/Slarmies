using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public AudioSource hurt;
    public AudioSource death;
    public AudioSource sword;
    public float speed;
    public float lineOfSite;
    public float attack_radius;
    private Transform player;
    private Transform minion;
    public Animator animator;
    public GameObject coin;
  
    private Vector3 startingPos;
    public Animator combat;
     public int maxHealth = 10;
    int currentHealth;
    public int attackDamage = 2;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private bool m_FacingRight = true;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public slimehealthbar healthBar;

    

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetFloat("Speed", 0);
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
       if (player.position.x > transform.position.x && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (player.position.x < transform.position.x && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
      
        if((distanceFromPlayer < lineOfSite) && (distanceFromPlayer > attack_radius))
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position,speed * Time.deltaTime);
            animator.SetFloat("Speed", speed);
        }
        else if ((distanceFromPlayer < lineOfSite) && (distanceFromPlayer < attack_radius))
        {
            if(Time.time >= nextAttackTime)
            {
            Attack();
            nextAttackTime = Time.time +1f / attackRate;
            }
            
        }
      
        else
        {
            return_to_start();
            
        }
    }
  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lineOfSite);
        Gizmos.DrawWireSphere(transform.position,attack_radius);
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    void Attack()
    {

        animator.SetFloat("Speed", 0);
        combat.SetTrigger("Attack");
        AudioSource.PlayClipAtPoint(sword.clip, Vector3.zero);
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, enemyLayers);
       foreach(Collider2D player in hitPlayers)
       {
        player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
       }
        
        
    }
    void return_to_start()
    {
            
             transform.position = Vector2.MoveTowards(this.transform.position, startingPos,speed * Time.deltaTime);
           
    }
      public void TakeDamage(int damage)
    {
        AudioSource.PlayClipAtPoint(hurt.clip, Vector3.zero);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        animator.SetTrigger("Hurt");

        if(currentHealth<= 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        //Die animation
        AudioSource.PlayClipAtPoint(death.clip, Vector3.zero);
        animator.SetBool("IsDead",true);
        combat.SetTrigger("death");
         Instantiate(coin, transform.position, transform.rotation);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
     private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
   
}
