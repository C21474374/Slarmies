using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
  

    public float speed;
    public float lineOfSite;
    public float attack_radius;
    public static Transform slime;
    private Transform player;
    public Animator animator;
    public Animator combat;
    public static GameObject[] AllSlimes;
    public GameObject NearestSlime;
    float distance;
    float nearestDistance;
    
    
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Collider2D col;
    private float current_speed;
    
    public int minionDamage = 2;
    
    
    
    

    // Start is called before the first frame update
    void Start()
    {
         
         player = GameObject.FindGameObjectWithTag("Player").transform;
         FindSlime();
        
        
     
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
          
      
                FindSlime();
          
                animator.SetTrigger("NotRunning");
                float distanceFromSlime = Vector2.Distance(NearestSlime.transform.position, transform.position);
                
                if((distanceFromSlime < lineOfSite) && (distanceFromSlime > attack_radius))
                {
                
                    transform.position = Vector2.MoveTowards(transform.position, NearestSlime.transform.position,speed * Time.deltaTime);
                    animator.SetTrigger("Running");

                
                }
                else if ((distanceFromSlime < lineOfSite) && (distanceFromSlime < attack_radius))
                {
                        
                Attack();
                }
                else
                {
                    follow_player();
                }
            
        

    }
  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineOfSite);
        Gizmos.DrawWireSphere(transform.position,attack_radius);
    }
  
 

    void Attack()
    {
        
        animator.SetTrigger("NotRunning");
        combat.SetTrigger("Attack");
        slime.GetComponent<SlimeHealth>().TakeDamage(minionDamage);
        
        
    }
    void follow_player()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer > attack_radius)
        {

        transform.position = Vector2.MoveTowards(transform.position, player.position,speed * Time.deltaTime);

        }
        else
        {
            animator.SetTrigger("NotRunning");
        }
    }
    public void FindSlime()
    {
         for(int i = 0; i < AllSlimes.Length;i++)
         {
            distance = Vector3.Distance(this.transform.position,AllSlimes[i].transform.position);
            if(distance < nearestDistance)
            {
                NearestSlime = AllSlimes[i];
            }
         }
    }
   

}
