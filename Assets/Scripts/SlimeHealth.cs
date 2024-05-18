using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth<= 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        //Die animation
        animator.SetBool("IsDead",true);
        
        this.enabled = false;
    }
}
