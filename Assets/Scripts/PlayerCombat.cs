using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public AudioSource hurt;
    public AudioSource death;
    public AudioSource sword;
    public GameObject deathMenuUI;
    public int attackDamage = 10;
    private Transform slime;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    
    
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public playerhealthbar healthBar;

    
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(PlayerPrefs.GetInt("playerHealth", 0));
       PlayerPrefs.SetInt("currentHealth",PlayerPrefs.GetInt("playerHealth",0));
        attackDamage = PlayerPrefs.GetInt("playerDamage",0);
       
       
       

      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time >= nextAttackTime)
            {
            Attack();
            nextAttackTime = Time.time +1f / attackRate;
            }
        }
        
    }
    void Attack()
    {
        
        
        animator.SetTrigger("Attack");
        AudioSource.PlayClipAtPoint(sword.clip, Vector3.zero);
        Collider2D[] hitSlimes =Physics2D.OverlapCircleAll(attackPoint.position,attackRange, enemyLayers);
       foreach(Collider2D slime in hitSlimes)
       {
        slime.GetComponent<Slime>().TakeDamage(attackDamage);
       }
      
        

    
        
        
    }
     private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

        public void TakeDamage(int damage)
    {
        AudioSource.PlayClipAtPoint(hurt.clip, Vector3.zero);
        PlayerPrefs.SetInt("currentHealth", PlayerPrefs.GetInt("currentHealth", 0)-damage);
        healthBar.SetHealth(PlayerPrefs.GetInt("currentHealth", 0));

        animator.SetTrigger("Hurt");

        if(PlayerPrefs.GetInt("currentHealth", 0) <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        //Die animation
        AudioSource.PlayClipAtPoint(death.clip, Vector3.zero);
        animator.SetBool("IsDead",true);
        Time.timeScale = 0f;
        deathMenuUI.SetActive(true);
       
        
        
    }
}
